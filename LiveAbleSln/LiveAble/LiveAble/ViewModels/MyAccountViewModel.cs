using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveAble.ViewModels
{
    public class MyAccountViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MyAccountViewModel(INavigationService navigationService)
        : base(navigationService)
        {
            Title = "Settings";
            _navigationService = navigationService;
        }
    }
}
