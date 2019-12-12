using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveAble.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private DelegateCommand _signOutCommand;
        public DelegateCommand SignOutCommand =>
            _signOutCommand ?? (_signOutCommand = new DelegateCommand(ExecuteSignOutCommand));

        async void ExecuteSignOutCommand()
        {
            await _navigationService.NavigateAsync("MainPageMasterDetail/LoginPage");
        }

        public SettingsViewModel(INavigationService navigationService)
        : base(navigationService)
        {
            Title = "Settings";
            _navigationService = navigationService;
        }
    }
}
