using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPBUSCACEP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.BairroPorCidade());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
