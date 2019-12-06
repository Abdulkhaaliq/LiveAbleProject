using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveAble.ViewModels
{
    public class MainPageMasterDetailViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private DelegateCommand _aboutUsCommand;
        public DelegateCommand AboutUsCommand =>
            _aboutUsCommand ?? (_aboutUsCommand = new DelegateCommand(ExecuteAboutUsCommand));

        async void ExecuteAboutUsCommand()
        {
            await _navigationService.NavigateAsync("NavigationPage/AboutUs");
        }

        private DelegateCommand _loginPageCommand;
        public DelegateCommand LoginPageCommand =>
         _loginPageCommand ?? (_loginPageCommand = new DelegateCommand(ExecuteLoginPageCommand));

        async void ExecuteLoginPageCommand()
        {
            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        public MainPageMasterDetailViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Sign Up Page";
            _navigationService = navigationService;
        }
    }
}
