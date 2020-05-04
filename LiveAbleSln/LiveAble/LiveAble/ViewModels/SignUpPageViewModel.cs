using LiveAble.Model;
using LiveAble.Services.Interfaces;
using LiveAble.ViewModels;
using Newtonsoft.Json;
using PlyOn.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Http;

namespace LiveAble.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
   
        public List<People> User { get; set; }



        private People _person;
        public People Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }

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

         async void ExecuteSignUpCompleteCommand()
         {
            Post();

            await _database.SaveItemAsync(Person);
         
            await _navigationService.NavigateAsync("LoginPage");
         }

        public async void Post()
        {
            var client = new HttpClient();
            var url = "http://10.0.2.2:5000/Users";

            var info = _database;

            var json = JsonConvert.SerializeObject(Person);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);

            }
            catch (Exception)
            {
               
            }
        }
          


        public SignUpPageViewModel(INavigationService navigationService, IDatabase database)
            : base(navigationService)
        {
            Title = "Sign Up Page";
           
            _navigationService = navigationService;

            _database = database;

            Person = new People();

   
        }
    }
}
