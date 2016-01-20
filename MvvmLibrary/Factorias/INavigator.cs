using System;
using System.Threading.Tasks;
using MvvmLibrary.ViewModel.Base;

namespace MvvmLibrary.Factorias
{
    /*Es el interfaz que vamos a autilizar para todas las tareas de PUSH y POP*/
    /*Sirve para el intercambio/cambio de ventanas*/
    public interface INavigator
    {
        /*Les pasamos el IviewModelvacio para poder hacer el trabajo directamente en la vista*/
        /*Elimina las ventanas*/
        Task<IViewModel> PopAsync();
        /*Elimina las ventanas modales*/
        Task<IViewModel> PopModalAsyn();
        /*Elimina todas las ventanas hasta llegar a la ventana raiz*/
        Task PopToRootAsync();

        /*Por un lado le pasamos el Interface (IViewModel) y por otro el Template(TViewModel)*/
        /*El IViewModel que le pasamos es un interface ya construido*/
        Task<IViewModel> PushAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel;
        Task<IViewModel> PushAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;

        /*Nos creamos la tarea push para las ventanas raiz/modales*/
        Task<IViewModel> PushModalAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel;
        Task<IViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) where TViewModel: class, IViewModel;

    }
}