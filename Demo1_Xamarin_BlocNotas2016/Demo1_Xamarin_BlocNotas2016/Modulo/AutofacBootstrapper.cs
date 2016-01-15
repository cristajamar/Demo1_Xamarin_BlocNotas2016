using Autofac;
using Demo1_Xamarin_BlocNotas2016.Factorias;

namespace Demo1_Xamarin_BlocNotas2016.Modulo
{
    public abstract class AutofacBootstrapper
    {
        public void Run()
        {
            var builder = new ContainerBuilder();
            ConfigureContainer(builder);
            var cont = builder.Build();
            var viewFactory = cont.Resolve<IViewFactory>();
            RegisterViews(viewFactory);
            ConfigureApplication(cont);
        }

        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacModule>();
        }

        protected abstract void RegisterViews(IViewFactory viewFactory);

        protected abstract void ConfigureApplication(IContainer container);
    }
}