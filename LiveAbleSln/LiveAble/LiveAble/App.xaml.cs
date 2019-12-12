using Prism;
using Prism.Ioc;
using LiveAble.ViewModels;
using LiveAble.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LiveAble.Services.Interfaces;
using PlyOn.Services;
using LiveAble.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LiveAble
{
    public partial class App
    {
       
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MainPageMasterDetail/NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDatabase, LiveableDatabase > ();
            containerRegistry.RegisterSingleton<ISecurityService, SecurityService>();


            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<MainPageMasterDetail, MainPageMasterDetailViewModel>();
            containerRegistry.RegisterForNavigation<AboutUs, AboutUsViewModel>();
            containerRegistry.RegisterForNavigation<SeeAllPage, SeeAllPageViewModel>();
        }
    }
}
