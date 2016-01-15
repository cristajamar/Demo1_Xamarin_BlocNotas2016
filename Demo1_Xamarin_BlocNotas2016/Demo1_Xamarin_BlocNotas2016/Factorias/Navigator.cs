using System;
using System.Threading.Tasks;
using Demo1_Xamarin_BlocNotas2016.ViewModel.Base;
using Xamarin.Forms;

namespace Demo1_Xamarin_BlocNotas2016.Factorias
{
    public class Navigator:INavigator
    {
        /*Los creamos en readonly, porque una vez que esten inicializados no queremos que se modifiquen*/
        private readonly Lazy<INavigation> _navigation; //se encarga del Lazyloading, cuando le pasemos la referencia a ese navegador si no existe lo creará.
        private readonly IViewFactory _viewFactory; //se encargara de la relación entre vistas
        //private readonly IPage _page;

        public Navigator(Lazy<INavigation> navigation, IViewFactory viewFactory, IPage page)
        {
            _navigation = navigation;
            _viewFactory = viewFactory;
            //_page = page;
        }

        public INavigation Navigation {get {return _navigation.Value; }}


        /*Llama al metod PopAsync del objeto navigation y devuelve el viewmodel que tiene relacionado*/
        /*PopAsync y Push Async son mentodos que ya tiene iOS predefinido*/

        /*Metodos de Eliminación de ventanas,normales,modales y cambio de ventana raiz*/
        public async Task<IViewModel> PopAsync()
        {
            Page vista = await Navigation.PopAsync();
            return vista.BindingContext as IViewModel;
        }

        public async Task<IViewModel> PopModalAsyn()
        {
            Page vista = await Navigation.PopModalAsync();
            return vista.BindingContext as IViewModel;
        }

        public async Task PopToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }





        public async Task<IViewModel> PushAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            var vista = _viewFactory.Resolve<TViewModel>(out viewModel, action);
            await Navigation.PushAsync(vista);
            return viewModel;
        }

        public async Task<IViewModel> PushAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            
            var vista = _viewFactory.Resolve<TViewModel>(out viewModel);
            await Navigation.PushAsync(vista);
            return viewModel;
        }

        public async Task<IViewModel> PushModalAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            var vista = _viewFactory.Resolve<TViewModel>(out viewModel, action);
            await Navigation.PushModalAsync(vista);
            return viewModel;
        }
    

        public async Task<IViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            var vista = _viewFactory.Resolve<TViewModel>(out viewModel);
            await Navigation.PushModalAsync(vista);
            return viewModel;
        }
    }
}