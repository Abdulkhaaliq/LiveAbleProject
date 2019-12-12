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

    public class SeeAllPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ObservableCollection<Article> Articles { get; set; }

        public SeeAllPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Content";
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
                    Title = "Side Effects?",
                    ShortDescription = "The outcoemes may come as a suprise",
                    NavigationPath = "",
                },

                new Article
                {
                    Image = "picture2.jpg",
                    Title = "What is Happiness?",
                    ShortDescription = "It's bad",
                    NavigationPath = "",

                },

                  new Article
                {
                    Image = "picture2.jpg",
                    Title = "Can anyone achieve Happiness?",
                    ShortDescription = "It's bad",
                    NavigationPath = "",

                },

                    new Article
                {
                    Image = "picture2.jpg",
                    Title = "What is Happiness",
                    ShortDescription = "It's bad",
                    NavigationPath = "",

                },
            };
        }
    }
}
