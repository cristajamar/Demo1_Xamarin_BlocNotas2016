﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Demo1_Xamarin_BlocNotas2016.Factorias;
using Demo1_Xamarin_BlocNotas2016.Model;
using Demo1_Xamarin_BlocNotas2016.Service;
using Demo1_Xamarin_BlocNotas2016.Util;
using Xamarin.Forms;

namespace Demo1_Xamarin_BlocNotas2016.ViewModel
{
    public class NuevoBlocViewModel:GeneralViewModel
    {
        
        public ObservableCollection<Bloc> Blocs { get; set; }
        public ICommand CmdGuardar { get; set; }

        

        public Bloc Bloc
        {
            get { return _bloc; }
            set { SetProperty(ref _bloc, value); }
        }

        private Bloc _bloc;

        public NuevoBlocViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            
            _bloc=new Bloc();
            CmdGuardar=new Command(Guardar);
        }

        private async void Guardar()
        {
            Bloc.Fecha=DateTime.Now;
            Bloc.IdUsuario = (Session["usuario"] as Usuario).Id;
            Bloc.Icono = "";
            await _servicio.AddBloc(Bloc);//Añade a azure
            Blocs.Add(Bloc);//Añade a local
        }
    }
}