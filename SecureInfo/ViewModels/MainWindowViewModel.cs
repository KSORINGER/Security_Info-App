
using SecureInfo.Infrastructure.Commands;
using SecureInfo.Models;
using SecureInfo.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SecureInfo.ViewModels
{
    internal class MainWindowViewModel : Base.BaseViewModel
    {

        #region Title
        private string _Title = "SecurityInfo";
        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion
        private SecurityInfoService Service;

        #region Antiviruses
        public List<AntiVirusProduct> _antiviruses;
        public List<AntiVirusProduct> Antiviruses { get => _antiviruses; set { Set(ref _antiviruses, value); OnPropertyChanged(); } }
        #endregion

        #region FirewallRules
        public List<FirewallRule> _firewallRules;
        public List<FirewallRule> FirewallRules { get => _firewallRules; set { Set(ref _firewallRules, value); OnPropertyChanged(); } }
        #endregion
        #region Updates
        public List<Update> _updates;
        public List<Update> Updates { get => _updates; set { Set(ref _updates, value); OnPropertyChanged(); } }
        #endregion

        #region SoftwareInfo
        private SystemInfo _systemInfo;
        public SystemInfo SystemInfo { get => _systemInfo; set { Set(ref _systemInfo, value); OnPropertyChanged(); } }
        #endregion


        #region HardwareInfo
        private HardwareInfo _hardwareInfo;
        public HardwareInfo HardwareInfo { get => _hardwareInfo; set { Set(ref _hardwareInfo, value); OnPropertyChanged(); } }

        #endregion

        #region Current view
        private object _currentView;
        public object CurrentView
        {
            get => _currentView; set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        #endregion



        #region AboutSystem
        public ICommand AboutSystemCommand { get; set; }
        private void AboutSystem(object obj)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Minimized)
            {
                Application.Current.MainWindow.Show();
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            CurrentView = new AboutSystemViewModel(SystemInfo, HardwareInfo);
        }

        #endregion
        #region Security
        public ICommand SecurityCommand { get; set; }
        private void Security(object obj)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Minimized)
            {
                Application.Current.MainWindow.Show();
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            CurrentView = new SecurityViewModel(Antiviruses);
        }
        #endregion
        #region Firewall
        public ICommand FirewallCommand { get; set; }
        private void Firewall(object obj)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Minimized)
            {
                Application.Current.MainWindow.Show();
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            CurrentView = new FirewallViewModel(FirewallRules);
        }
        #endregion

        #region Update
        public ICommand UpdateCommand { get; set; }
        private void Update(object obj)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Minimized)
            {
                Application.Current.MainWindow.Show();
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            CurrentView = new UpdatesViewModel(Service);
        }
        #endregion
        #region Help
        public ICommand HelpCommand { get; set; }
        private void Help(object obj)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Minimized)
            {
                Application.Current.MainWindow.Show();
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            CurrentView = new HelpViewModel();
        }
        #endregion

        public MainWindowViewModel()
        {

            #region Commands
            SecurityCommand = new RelayCommands(Security);
            FirewallCommand = new RelayCommands(Firewall);
            AboutSystemCommand = new RelayCommands(AboutSystem);
            UpdateCommand = new RelayCommands(Update);
            HelpCommand = new RelayCommands(Help);
            #endregion

             Service = new SecurityInfoService();

            Task.Run(() =>
            {
                
                FirewallRules = Service.GetFirewallRules();
                Antiviruses = Service.GetAntivirucesInformation();
                SystemInfo = Service.GetOSInfo();
                HardwareInfo = Service.GetHardwareInfo();
            }).Wait();
            CurrentView = new AboutSystemViewModel(SystemInfo, HardwareInfo);
        }
    }
}
