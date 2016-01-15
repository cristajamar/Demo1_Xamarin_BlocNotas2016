using Autofac;
using Demo1_Xamarin_BlocNotas2016.Factorias;
using Demo1_Xamarin_BlocNotas2016.View;
using Demo1_Xamarin_BlocNotas2016.ViewModel;
using Xamarin.Forms;

namespace Demo1_Xamarin_BlocNotas2016.Modulo
{
    public class Startup:AutofacBootstrapper
    {

        private readonly App _application;

        public Startup(App application)
        {
            _application = application;
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<BlocNotasModulo>();
        }

        /*Cada vista nueva, debe estar registarada aquí, ya que es ViewFactory es de donde recuperamos las referencias*/
        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<LoginViewModel,Login>();
            viewFactory.Register<RegistroViewModel,Registro>();
            viewFactory.Register<PrincipalViewModel,Principal>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            var main = viewFactory.Resolve<LoginViewModel>();
            var np=new NavigationPage(main);
            _application.MainPage = np;
        }
    }
}