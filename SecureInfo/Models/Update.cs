using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureInfo.Models
{
    internal class Update : ViewModels.Base.BaseViewModel
    {
        public string Title { get; set; }
        public string ClientApplicationID { get; set; }
        public string Description { get; set; }
        public string SupportUrl { get; set; }
        public DateTime Date { get; set; }

    }
}
