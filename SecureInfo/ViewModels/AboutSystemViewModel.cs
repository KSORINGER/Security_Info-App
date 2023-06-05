using SecureInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureInfo.ViewModels
{
    class AboutSystemViewModel : Base.BaseViewModel
    {

        private SystemInfo _systemInfo;
        public SystemInfo SystemInfo { get => _systemInfo; set { Set(ref _systemInfo, value); OnPropertyChanged(); } }


        private HardwareInfo _hardwareInfo; 
        public HardwareInfo HardwareInfo { get => _hardwareInfo; set { Set(ref _hardwareInfo, value); OnPropertyChanged(); } }


        public AboutSystemViewModel()
        {

        }
        public AboutSystemViewModel(SystemInfo systemInfo, HardwareInfo hardwareInfo)
        {
            SystemInfo = systemInfo;
            HardwareInfo = hardwareInfo;
        }
       
    }
}
