using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureInfo.Models
{
    internal class FirewallRule : ViewModels.Base.BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public string Direction { get; set; }
        public int Protocol { get; set; }
        public string ApplicationName { get; set; }

    }
}
