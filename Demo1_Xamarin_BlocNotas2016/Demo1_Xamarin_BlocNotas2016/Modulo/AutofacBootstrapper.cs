﻿using Autofac;
using Demo1_Xamarin_BlocNotas2016.Factorias;

namespace Demo1_Xamarin_BlocNotas2016.Modulo
{
    public abstract class AutofacBootstrapper
    {

        //Configuramos el builder
        public void Run()
        {
            var builder = new ContainerBuilder();
            ConfigureContainer(builder);
            var cont = builder.Build();
            var viewFactory = cont.Resolve<IViewFactory>();
            RegisterViews(viewFactory);
            ConfigureApplication(cont);
        }

        //Configuramos el contenedor
        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacModule>();
        }

        //Configuramos el registro de vistas que despues se utilizara en el Startup
        protected abstract void RegisterViews(IViewFactory viewFactory);

        protected abstract void ConfigureApplication(IContainer container);
    }
}