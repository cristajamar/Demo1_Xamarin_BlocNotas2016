using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Demo1_Xamarin_BlocNotas2016.ViewModel.Base;
using Xamarin.Forms;

namespace Demo1_Xamarin_BlocNotas2016.Factorias
{
    public class ViewFactory:IViewFactory
    {
        
        //Tenemos un diccionario que guarda todas las referencias/relaciones de los (clave)ViewModel y (valor)View
        //El Register trabajar sobre _map
        readonly IDictionary<Type,Type> _map=new Dictionary<Type, Type>();
        private readonly IComponentContext _componentContext;


        //El componentContext es el contexto de ejecución del Autofac
        //Es un objeto que necesitamos para poder almacenarlo en autoFac, ya que esto no funciona sin la inyccion de depndencias. 
        //La informacion donde puede recuperar todos los objetos
        public ViewFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }


        public void Register<TViewModel, TView>() where TViewModel : class, IViewModel where TView : Page
        {
            _map[typeof (TViewModel)] = typeof (TView);
        }

        public Page Resolve<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            return Resolve<TViewModel>(out viewModel, action);
        }

        //Con la factoria creamos la refencia entre cada Vista con su ViewModel.
        //Con el BindingContext obtenemos esa referencia
        public Page Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> action = null) where TViewModel : class, IViewModel
        {
            //del Context recuperamos el ViewModel vacio, si no existe lo crea
            viewModel = _componentContext.Resolve<TViewModel>();
            //recupera el Tipo de la Vista (loginView, AltaVista....) -- la clase que implementa la vista (el xaml, que cuando lo compila lo transforma en codigo)
            var tipoVista = _map[typeof(TViewModel)];
            //recupera el objeto de la vista, que tiene los datos
            var vista = _componentContext.Resolve(tipoVista) as Page;
            if (action == null)
                viewModel.SetState(action);

            //el BindingContext relaciona la vista con el viewModel que es el que contiene los datos para la vista.
            vista.BindingContext = viewModel;

            return vista;
        }

        public Page Resolve<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            
            viewModel = _componentContext.Resolve<TViewModel>();
            
            var tipoVista = _map[typeof(TViewModel)];
            var vista = _componentContext.Resolve(tipoVista) as Page;
            vista.BindingContext = viewModel;
            return vista;
        }
    }

}
