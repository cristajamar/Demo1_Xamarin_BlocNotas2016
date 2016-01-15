using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo1_Xamarin_BlocNotas2016.Modulo;
using Xamarin.Forms;

namespace Demo1_Xamarin_BlocNotas2016
{
    /*El APP se encarga de gestionar la pagina principal, de iniciar la aplicación*/
    public class App : Application
    {
        public App()
        {
            var start=new Startup(this);
            start.Run();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
