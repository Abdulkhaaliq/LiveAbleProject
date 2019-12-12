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

        private DelegateCommand _articleCommand;
        public DelegateCommand ArticleCommand =>
            _articleCommand ?? (_articleCommand = new DelegateCommand(ExecuteArticleCommand));

        void ExecuteArticleCommand()
        {

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
                    ShortDescription = "Emotional, psychological, and social well-being.",
                    NavigationPath = "",
              
                },

                new Article
                {
                    Image = "picture2.jpg",
                    Title = "Happy",
                    ShortDescription = "It's bad",
                    NavigationPath = "",
                },

                new Article
                {
                    Image = "picture2.jpg",
                    Title = "Confused",
                    ShortDescription = "It's bad",
                    NavigationPath = "",

                },
            };
        }
    }
}
