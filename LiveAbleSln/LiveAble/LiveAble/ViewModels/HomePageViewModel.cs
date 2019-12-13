using LiveAble.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LiveAble.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ObservableCollection<Article> Articles { get; set; }


        private DelegateCommand<Article> _navigateCommand;
        public DelegateCommand<Article> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<Article>(ExecuteNavigateCommand));

        public async void ExecuteNavigateCommand(Article article)
        {
            await NavigationService.NavigateAsync("NavigationPage/PdfView");
        }

        private DelegateCommand _navigateSeeAllCommand;
        public DelegateCommand NavigateSeeAllCommand =>
            _navigateSeeAllCommand ?? (_navigateSeeAllCommand = new DelegateCommand(ExecuteNavigateSeeAllCommand));

        async void ExecuteNavigateSeeAllCommand()
        {

            await _navigationService.NavigateAsync("SeeAllPage");
        }

        public HomePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

            Title = "Sign Up Page";
            _navigationService = navigationService;

            Articles = new ObservableCollection<Article>
            {
                new Article
                {
                    Image = "picture2.jpg",
                    Title = "What Is Depression?",
                    ShortDescription = "Emotional well-being.",
                    NavigationPath = "NavigationPage/PdfView",

                },

                new Article
                {
                    Image = "Image1.jpg",
                    Title = "Side Effects?",
                    ShortDescription = "The outcoemes may come as a suprise",
                    NavigationPath = "",
                },

                new Article
                {
                    Image = "Image2.jpg",
                    Title = "What is Happiness?",
                    ShortDescription = "Is it Bad?",
                    NavigationPath = "https://www.quora.com/Can-a-depressed-person-ever-feel-happiness",

                },
            };
        }
    }
}
