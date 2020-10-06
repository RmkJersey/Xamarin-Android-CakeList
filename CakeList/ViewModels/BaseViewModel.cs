using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CakeList.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool _isBusy;
        public bool IsNotBusy => !IsBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                    return;
                _isBusy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        private bool _statusMessageVisible;
        public bool StatusMessageVisible
        {
            get => _statusMessageVisible;
            set
            {
                _statusMessageVisible = value;
                OnPropertyChanged();
            }
        }

        private string _statusMessage;
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}