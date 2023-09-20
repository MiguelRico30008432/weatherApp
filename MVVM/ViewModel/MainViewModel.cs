using WheaterApp.Core;

namespace WheaterApp.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public HomeViewModel homeVM { get; set; }
        public LogsViewModel logsVM { get; set; }
        public AboutViewModel aboutVM { get; set; }

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand LogsViewCommand { get; set; }
        public RelayCommand AboutViewCommand { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            homeVM = new HomeViewModel();
            logsVM = new LogsViewModel();
            aboutVM = new AboutViewModel();

            CurrentView = homeVM;

            HomeViewCommand = new RelayCommand(changeViewHome);
            LogsViewCommand = new RelayCommand(changeViewLogs);
            AboutViewCommand = new RelayCommand(changeAboutLogs);
        }


        private void changeViewHome(object paramerte) {CurrentView = homeVM;}
        private void changeViewLogs(object paramerte) { CurrentView = logsVM; }
        private void changeAboutLogs(object paramerte) { CurrentView = logsVM; }
    }
}
