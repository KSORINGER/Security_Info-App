using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureInfo.Models
{
    class SystemInfo : ViewModels.Base.BaseViewModel
    {
        public string Caption { get; set; }
        public string Version { get; set; }
        public string CSName { get; set; }
        public string OSArchitecture { get; set; }
        public string RegisteredUser { get; set; }
        public string SerialNumber { get; set; }
        
    }
}
