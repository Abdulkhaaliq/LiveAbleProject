using LiveAble.Model;
using LiveAble.Services.Interfaces;
using LiveAble.ViewModels;
using Prism.Commands;
using Prism.Navigation;
using SQLite;
using System;
using System.IO;


namespace LiveAble.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {

        private readonly IDatabase _database;
        private readonly INavigationService _navigationService;

        private DelegateCommand _signUpCompleteCommand;
        public DelegateCommand SignUpCompleteCommand =>
            _signUpCompleteCommand ?? (_signUpCompleteCommand = new DelegateCommand(ExecuteSignUpCompleteCommand));

        private DelegateCommand _loginPageCommand;
        public DelegateCommand LoginPageCommand =>
            _loginPageCommand ?? (_loginPageCommand = new DelegateCommand(ExecuteLoginPageCommand));

         async void ExecuteLoginPageCommand()
        {
            await NavigationService.GoBackAsync();
        }
        
         void ExecuteSignUpCompleteCommand()
        {

            var item = ;
            _database.SaveItemAsync(item);
        }


        public SignUpPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Sign Up Page";
            _navigationService = navigationService;
           
        }
    }
}
