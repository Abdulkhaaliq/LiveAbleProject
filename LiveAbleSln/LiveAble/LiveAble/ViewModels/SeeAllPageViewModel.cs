using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveAble.ViewModels
{

    public class SeeAllPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public SeeAllPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Content";
            _navigationService = navigationService;

        }
    }
}
