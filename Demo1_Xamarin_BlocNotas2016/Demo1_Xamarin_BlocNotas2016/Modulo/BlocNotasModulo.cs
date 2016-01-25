using System;
using Autofac;
using Demo1_Xamarin_BlocNotas2016.Service;
using Demo1_Xamarin_BlocNotas2016.Util;
using Demo1_Xamarin_BlocNotas2016.View;
using Demo1_Xamarin_BlocNotas2016.ViewModel;
using Xamarin.Forms;

namespace Demo1_Xamarin_BlocNotas2016.Modulo
{
    public class BlocNotasModulo:Module
    {
        /*Detecta el tipo de pagina que es y devuelve la pagina principal*/


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServicioDatosImpl>().As<IServicioDatos>().SingleInstance();
            builder.RegisterType<Session>().SingleInstance(); //¿?

            builder.RegisterType<Login>();
            builder.RegisterType<Login>();
            builder.RegisterType<Principal>();
            builder.RegisterType<Registro>();
            builder.RegisterType<NuevoBloc>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<PrincipalViewModel>();
            builder.RegisterType<RegistroViewModel>();
            builder.RegisterType<NuevoBlocViewModel>();
            

            builder.RegisterInstance<Func<Page>>(() =>
            {
                var masterP = App.Current.MainPage as MasterDetailPage;
                var page = masterP != null ? masterP.Detail : App.Current.MainPage;
                var navigation = page as IPageContainer<Page>;
                return navigation != null ? navigation.CurrentPage : page;
            });
        }
    }
}