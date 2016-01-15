using Autofac;
using Demo1_Xamarin_BlocNotas2016.Factorias;
using Xamarin.Forms;

namespace Demo1_Xamarin_BlocNotas2016.Modulo
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();
            builder.Register<INavigation>(ctx => App.Current.MainPage.Navigation).SingleInstance();
        }
    }
}