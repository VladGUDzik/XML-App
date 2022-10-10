using Design.Core;
using Design.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.MVVM.ViewModel
{
    class MainViewModel:ObservableObject
    {
        public RelayComand HomeViewComand { get; set; }
        public RelayComand DiscoveryViewComand { get; set; }
        public HomeViewModel HomeVm { get; set; }

        public DiscoveryViewModel DiscoveryVm { get; set; }
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPropertyChanged();
            }
        }
       
        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            DiscoveryVm = new DiscoveryViewModel();
            CurrentView = HomeVm;

            HomeViewComand = new RelayComand(o=> {
                CurrentView = HomeVm;
            }); 
            DiscoveryViewComand = new RelayComand(o=> {
                CurrentView = DiscoveryVm;
            }); 
        }
    }
}
