using SecureInfo.Models;
using SecureInfo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureInfo.ViewModels
{
    class UpdatesViewModel : Base.BaseViewModel
    {
        private List<Update> _updates;
        public List<Update> Updates { get => _updates; set { Set(ref _updates, value); OnPropertyChanged(); } }

        public SecurityInfoService SecurityInfoService { get; private set; }

        public UpdatesViewModel():this(null)
        {

        }
        public UpdatesViewModel(SecurityInfoService securityInfoService)
        {
            SecurityInfoService = securityInfoService;

            Task.Run(() =>
            {
                Updates = SecurityInfoService.GetUpdates();
            });
        }
    }
}
