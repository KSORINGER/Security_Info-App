using SecureInfo.Models;

using System.Collections.Generic;


namespace SecureInfo.ViewModels
{
    class SecurityViewModel : Base.BaseViewModel 
    {
        private List<AntiVirusProduct> _antiVirusProducts;
        public List<AntiVirusProduct> AntiVirusProducts { get => _antiVirusProducts; set { Set(ref _antiVirusProducts, value); OnPropertyChanged(); } }

        public SecurityViewModel() : this(null) { }
        public SecurityViewModel(List<AntiVirusProduct> antiVirusProducts)
        {
            AntiVirusProducts = antiVirusProducts;
        }
    }
}
