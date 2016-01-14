using System;
using System.ComponentModel;

namespace Demo1_Xamarin_BlocNotas2016.ViewModel.Base
{
    /*INotifyPropertyChanged: es el notificador de la propiedad cambiada, y se utiliza para el Binding 2Way,
    para que la propiedad que cambien en la clase se refleje en pantalla*/
    public interface IViewModel:INotifyPropertyChanged
    {
        /*Titulo lo utlizxamos para que todos los ViewModels/pantallas tengan su Titulo
          El IViewModel nos va a forzar a que incluyamos en titulo*/
        string Titulo { get; set; }

        /*SetState se utilza para cambiar el estado de ViewModel, es un delegado, esto se hace forzando a que sean ViewModels*/
        /*El Action es el metodo que queremos que ejecute, es decir el Alta de Usuario o el Login, por ejemplo*/
        /*La clase recibira un objeto de Tipo T*/
        void SetState<T>(Action<T> action) where T : class, IViewModel;
    }
}