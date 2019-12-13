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

                  new Article
                {
                    Image = "picture2.jpg",
                    Title = "How can I be me?",
                    ShortDescription = "Solution?",
                    NavigationPath = "",

                },

                    new Article
                {
                    Image = "picture2.jpg",
                    Title = "Atleast you're not dead",
                    ShortDescription = "It's good!",
                    NavigationPath = "",

                },
            };
        }
    }
}
