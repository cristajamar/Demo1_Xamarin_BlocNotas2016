using System;
using Demo1_Xamarin_BlocNotas2016.ViewModel.Base;
using Xamarin.Forms;

namespace Demo1_Xamarin_BlocNotas2016.Factorias
{
    /*Se va a encargar de construir vistas, por una lado el enlazara cada viewModel con su vista y por otro lado se encargara de todas las relaciones*/
    public interface IViewFactory
    {
        //Register: Guarda en el contenedor la relación entre el ViewModel y su vista
        //TViewModel: tiene que ser del tipo IViewModel y class porque tiene que ser un objeto
        //TView: sera una vista de tipo Pagina de Xamarin
        void Register<TViewModel, TView>() where TViewModel : class, IViewModel where TView : Page;

        /*Ahora hay que recuperar del contenedor las vistas*/

        /*Tenemos tres tipos de recuperación del contenedor:
            1. Pasomos el ViewModel vacio junto con una Accion
            2. Pasamos el ViewModel con una acción
            3. Pasamos unicamente un ViewModel vacio*/

        Page Resolve<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel;

        Page Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> action = null) where TViewModel : class, IViewModel;

        Page Resolve<TViewModel>(TViewModel viewModel) where TViewModel : class,IViewModel;
    }
}