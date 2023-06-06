namespace TicTacToe
{
    public class TicTacToeGame
    {
        public string[,] board; // Spielfeld des Tic-Tac-Toe-Spiels, ein 2D-Array (Array mit zwei Dimensionen)
        public bool GameEnded { get; set; } // gibt an, ob das Spiel beendet ist

        public TicTacToeGame()
        {
            board = new string[3, 3]; // Spielfeld wird initialisiert

            GameEnded = false;  // Spiel beginnt, noch nicht beendet
        }

        public bool MakeMove(int row, int column, string player) // Methode, um einen Zug zu machen
        {
            if (board[row, column] == null) // wenn das Feld leer ist, kann der Zug gemacht werden
            {
                board[row, column] = player; // das Feld wird mit dem Spielstein des Spielers belegt
                return true; // Zug erfolgreich
            }

            return false; // Zug fehlgeschlagen, das Feld ist bereits belegt
        }

        public bool CheckForWin(string player) // Methode, um zu überprüfen, ob ein Spieler gewonnen hat
        {
            for (int row = 0; row < 3; row++) // Überprüfung der Zeilen
            {
                if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player) // Wenn alle Felder einer Zeile mit dem Spielstein des Spielers belegt sind
                    return true; // Spieler hat gewonnen
            }

            for (int column = 0; column < 3; column++) // Überprüfung der Spalten
            {
                if (board[0, column] == player && board[1, column] == player && board[2, column] == player)
                    return true; // Spieler hat gewonnen
            }

            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
                return true; // Spieler hat gewonnen

            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
                return true; // Spieler hat gewonnen

            return false; // Spieler hat nicht gewonnen
        }

        public bool CheckForDraw()// Methode, um zu überprüfen, ob das Spiel unentschieden endet
        {
            for (int row = 0; row < 3; row++) // Überprüfung aller Felder
            {
                for (int column = 0; column < 3; column++)
                {
                    if (board[row, column] == null) // Wenn es ein leeres Feld gibt
                        return false; // Spiel ist noch nicht beendet
                }
            }

            return true; // Alle Felder sind belegt, das Spiel endet unentschieden
        }
    }
}