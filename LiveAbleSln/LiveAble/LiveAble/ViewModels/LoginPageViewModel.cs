using LiveAble.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveAble.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
     
        private readonly INavigationService _navigationService;

        private DelegateCommand _signUpCommand;
        public DelegateCommand SignUpCommand =>
            _signUpCommand ?? (_signUpCommand = new DelegateCommand(ExecuteSignUpCommand));

        async void ExecuteSignUpCommand()
        {
            await _navigationService.NavigateAsync("SignUpPage");
        }


        private DelegateCommand _loginCompleteCommand;
        public DelegateCommand LoginCompleteCommand =>
            _loginCompleteCommand ?? (_loginCompleteCommand = new DelegateCommand(ExecuteLoginCompleteCommand));

        async void ExecuteLoginCompleteCommand()
        {
            await _navigationService.NavigateAsync("HomePage");
        }
        public LoginPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Login Page";
            _navigationService = navigationService;
        }
    }
}
