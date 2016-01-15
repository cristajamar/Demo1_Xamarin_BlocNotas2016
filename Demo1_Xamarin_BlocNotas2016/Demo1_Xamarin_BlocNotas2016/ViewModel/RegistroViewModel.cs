﻿using System.Windows.Input;
using Demo1_Xamarin_BlocNotas2016.Factorias;
using Demo1_Xamarin_BlocNotas2016.Model;
using Demo1_Xamarin_BlocNotas2016.Service;
using Demo1_Xamarin_BlocNotas2016.ViewModel.Base;

namespace Demo1_Xamarin_BlocNotas2016.ViewModel
{
    public class RegistroViewModel:GeneralViewModel
    {
        public ICommand cmdAlta { get; set; }
        private Usuario _usuario;
        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        public RegistroViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
        }

        private async void GuardarUsuario()
        {
            try
            {
                IsBusy = true;
                var r = await _servicio.AddUsuario(_usuario);

                if (r != null)
                {
                    await _navigator.PushModalAsync<PrincipalViewModel>();

                }
                else
                {
                    var a = "";
                }
            }
            finally
            {

                IsBusy = false;

            }
        }
    }
}