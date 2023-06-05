using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SecureInfo.Models
{
    internal class HardwareInfo : ViewModels.Base.BaseViewModel
    {
        public string PhysicalMemory { get; set; }
        public string ProcessorInformation { get; set; }
        public string GPU { get; set; }
        public string BIOScaption { get; set; }
        public string MACAddress { get; set; }

    }
}
