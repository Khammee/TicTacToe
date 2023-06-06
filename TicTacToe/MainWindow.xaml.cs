using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;


namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private ButtonStateUpdater buttonStateUpdater; // Eine Instanz des ButtonStateUpdater zur Aktualisierung der Schaltflächenzustände
        private TicTacToeGame game; // Eine Instanz des TicTacToe-Spiels
        private string currentPlayer; // Der aktuelle Spieler

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded; // Event-Handler für das Loaded-Ereignis der MainWindow-Klasse hinzufügen
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeButtonStateUpdater(); // Initialisiert den ButtonStateUpdater
            SaveInitialGameState(); // Speichert den anfänglichen Zustand des Spielfelds
        }

        private void SaveInitialGameState()
        {
            var initialBoardState = new string[9]; // Ein Array zum Speichern des anfänglichen Zustands der Schaltflächen
            int index = 0;

            foreach (Button button in gameGrid.Children)
            {
                initialBoardState[index] = button.Content.ToString(); // Speichert den Inhalt der Schaltfläche im Array
                index++;
            }
        }

        private void InitializeButtonStateUpdater()
        {
            buttonStateUpdater = new ButtonStateUpdater(); // Erstellt eine Instanz des ButtonStateUpdater
            DataContext = buttonStateUpdater; // Setzt den DataContext auf den ButtonStateUpdater

            // Bindet die Eigenschaften des ButtonStateUpdater an die IsEnabled-Eigenschaften der Schaltflächen
            btn0.SetBinding(Button.IsEnabledProperty, new Binding(nameof(ButtonStateUpdater.Button0Enabled)));
            btn1.SetBinding(Button.IsEnabledProperty, new Binding(nameof(ButtonStateUpdater.Button1Enabled)));
            btn2.SetBinding(Button.IsEnabledProperty, new Binding(nameof(ButtonStateUpdater.Button2Enabled)));
            btn3.SetBinding(Button.IsEnabledProperty, new Binding(nameof(ButtonStateUpdater.Button3Enabled)));
            btn4.SetBinding(Button.IsEnabledProperty, new Binding(nameof(ButtonStateUpdater.Button4Enabled)));
            btn5.SetBinding(Button.IsEnabledProperty, new Binding(nameof(ButtonStateUpdater.Button5Enabled)));
            btn6.SetBinding(Button.IsEnabledProperty, new Binding(nameof(ButtonStateUpdater.Button6Enabled)));
            btn7.SetBinding(Button.IsEnabledProperty, new Binding(nameof(ButtonStateUpdater.Button7Enabled)));
            btn8.SetBinding(Button.IsEnabledProperty, new Binding(nameof(ButtonStateUpdater.Button8Enabled)));
        }

        private void NewGame()
        {
            currentPlayer = "X"; // Setzt den Startspieler auf "X"
            game = new TicTacToeGame(); // Erstellt ein neues TicTacToe-Spiel

            // Setzt den Inhalt, die Aktivität und den Hintergrund aller Schaltflächen zurück
            foreach (Button button in gameGrid.Children.OfType<Button>())
            {
                button.Content = "";
                button.IsEnabled = true;
                button.Background = Brushes.White;
            }

            lblStatus.Content = "Spieler X ist an der Reihe"; // Aktualisiert den Spielstatus
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender; // Das auslösende Objekt als Schaltfläche casten

            if (button.Content.ToString() != "" || game.GameEnded)
                return; // Wenn die Schaltfläche bereits belegt ist oder das Spiel beendet ist, abbrechen

            button.Content = currentPlayer; // Setzt das Symbol des aktuellen Spielers auf die Schaltfläche

            int row = Grid.GetRow(button); // Ermittelt die Zeile der Schaltfläche im Raster
            int column = Grid.GetColumn(button); // Ermittelt die Spalte der Schaltfläche im Raster

            if (game.MakeMove(row, column, currentPlayer)) // Führt den Zug im TicTacToe-Spiel aus
            {
                if (game.CheckForWin(currentPlayer)) // Überprüft auf einen Gewinn
                {
                    lblStatus.Content = "Spieler " + currentPlayer + " hat gewonnen!"; // Aktualisiert den Spielstatus
                    game.GameEnded = true; // Setzt das Spielende auf true
                    DisableAllButtons(); // Deaktiviert alle Schaltflächen
                }
                else if (game.CheckForDraw()) // Überprüft auf ein Unentschieden
                {
                    lblStatus.Content = "Unentschieden!"; // Aktualisiert den Spielstatus
                    game.GameEnded = true; // Setzt das Spielende auf true
                    DisableAllButtons(); // Deaktiviert alle Schaltflächen
                }
                else
                {
                    currentPlayer = (currentPlayer == "X") ? "O" : "X"; // Wechselt den aktuellen Spieler
                    lblStatus.Content = "Spieler " + currentPlayer + " ist an der Reihe"; // Aktualisiert den Spielstatus
                }
            }
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame(); // Startet ein neues Spiel
            EnableAllButtons(); // Aktiviert alle Schaltflächen
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame(); // Startet ein neues Spiel
            DisableAllButtons(); // Deaktiviert alle Schaltflächen
        }

        private void EnableAllButtons()
        {
            foreach (Button button in gameGrid.Children)
            {
                button.IsEnabled = true; // Aktiviert alle Schaltflächen
            }
        }

        private void DisableAllButtons()
        {
            foreach (Button button in gameGrid.Children)
            {
                button.IsEnabled = false; // Deaktiviert alle Schaltflächen
            }
        }
    }
}