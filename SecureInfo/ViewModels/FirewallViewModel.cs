using SecureInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureInfo.ViewModels
{
    class FirewallViewModel : Base.BaseViewModel
    {
        private List<FirewallRule> _firewallRules;
        public List<FirewallRule> FirewallRules { get => _firewallRules; set { Set(ref _firewallRules, value); OnPropertyChanged(); } }

        public FirewallViewModel():this(null)
        {

        }
        public FirewallViewModel(List<FirewallRule> firewallRules)
        {
            FirewallRules = firewallRules;
        }

    }
}
