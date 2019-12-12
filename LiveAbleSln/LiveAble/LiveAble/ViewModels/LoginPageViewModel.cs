using LiveAble.Messages;
using LiveAble.Model;
using LiveAble.Services.Interfaces;
using LiveAble.Views;
using Prism.Commands;
using Prism.Events;
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

        private IEventAggregator _eventAggregator;


 

        private People _person;
        public People Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }
        private readonly IDatabase _database;
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



            var userProfile  = await _database.GetPeopleByEmail(_person.Email);
           
                if (userProfile.Password == _person.Password && userProfile.Email == _person.Email)
               {

                _eventAggregator.GetEvent<LoginMessage>().Publish(userProfile);

                    await _navigationService.NavigateAsync("MainPageMasterDetail/HomePage");
               }
               else
               {
                  await _navigationService.NavigateAsync("LoginPage");
               }
        }


        public LoginPageViewModel(INavigationService navigationService, IDatabase database, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            _database = database;
            _eventAggregator = eventAggregator;
            Title = "Login Page";
            _navigationService = navigationService;
            Person = new People();
        }
    }
}
