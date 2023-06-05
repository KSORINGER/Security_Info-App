using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureInfo.Models
{
    internal class AntiVirusProduct : ViewModels.Base.BaseViewModel
    {
        public string instanceGuid { get; set; }
        public string displayName { get; set; }
        public uint productState { get; set; }
        public string pathToSignedProductExe { get; set; }
        public string pathToSignedReportingExe { get; set; }
        public string timestamp { get; set; }
    }
}
