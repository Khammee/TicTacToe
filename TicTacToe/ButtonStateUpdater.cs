using System.ComponentModel;

namespace TicTacToe
{
    public class ButtonStateUpdater : INotifyPropertyChanged
    {
        private bool button0Enabled;
        private bool button1Enabled;
        private bool button2Enabled;
        private bool button3Enabled;
        private bool button4Enabled;
        private bool button5Enabled;
        private bool button6Enabled;
        private bool button7Enabled;
        private bool button8Enabled;
        public event PropertyChangedEventHandler PropertyChanged;

        // Eine Eigenschaft, die den Aktivierungszustand des Buttons 0 repräsentiert.
        public bool Button0Enabled
        {
            get { return button0Enabled; }
            set
            {
                button0Enabled = value;
                OnPropertyChanged(nameof(Button0Enabled));
            }
        }

        // Eine Eigenschaft, die den Aktivierungszustand des Buttons 1 repräsentiert.
        public bool Button1Enabled
        {
            get { return button1Enabled; }
            set
            {
                button1Enabled = value;
                OnPropertyChanged(nameof(Button1Enabled));
            }
        }

        // Eine Eigenschaft, die den Aktivierungszustand des Buttons 2 repräsentiert.
        public bool Button2Enabled
        {
            get { return button2Enabled; }
            set
            {
                button2Enabled = value;
                OnPropertyChanged(nameof(Button2Enabled));
            }
        }

        // Eine Eigenschaft, die den Aktivierungszustand des Buttons 3 repräsentiert.
        public bool Button3Enabled
        {
            get { return button3Enabled; }
            set
            {
                button3Enabled = value;
                OnPropertyChanged(nameof(Button3Enabled));
            }
        }

        // Eine Eigenschaft, die den Aktivierungszustand des Buttons 4 repräsentiert.
        public bool Button4Enabled
        {
            get { return button4Enabled; }
            set
            {
                button4Enabled = value;
                OnPropertyChanged(nameof(Button4Enabled));
            }
        }

        // Eine Eigenschaft, die den Aktivierungszustand des Buttons 5 repräsentiert.
        public bool Button5Enabled
        {
            get { return button5Enabled; }
            set
            {
                button5Enabled = value;
                OnPropertyChanged(nameof(Button5Enabled));
            }
        }

        // Eine Eigenschaft, die den Aktivierungszustand des Buttons 6 repräsentiert.
        public bool Button6Enabled
        {
            get { return button6Enabled; }
            set
            {
                button6Enabled = value;
                OnPropertyChanged(nameof(Button6Enabled));
            }
        }

        // Eine Eigenschaft, die den Aktivierungszustand des Buttons 7 repräsentiert.
        public bool Button7Enabled
        {
            get { return button7Enabled; }
            set
            {
                button7Enabled = value;
                OnPropertyChanged(nameof(Button7Enabled));
            }
        }

        // Eine Eigenschaft, die den Aktivierungszustand des Buttons 8 repräsentiert.
        public bool Button8Enabled
        {
            get { return button8Enabled; }
            set
            {
                button8Enabled = value;
                OnPropertyChanged(nameof(Button8Enabled));
            }
        }

        // Auslöser für das PropertyChanged-Ereignis, um Änderungen an den Eigenschaften anzukündigen.
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
