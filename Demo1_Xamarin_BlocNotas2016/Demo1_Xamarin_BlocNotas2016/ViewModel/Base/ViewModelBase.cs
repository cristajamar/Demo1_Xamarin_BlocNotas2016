using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo1_Xamarin_BlocNotas2016.ViewModel.Base
{
    public class ViewModelBase:IViewModel
    {
        

        /*_IsBusy lo utilizamos para que cuando la aplicación este ocupada de ponga a true y en caso contrario a false*/
        private bool _isBusy;
        /*Con el _opacity oscurece la aplicación mientras este Busy*/
        private double _opacity;
        /*Con el _enabled lo que hacemos es deshbilitarle los controles al usuario mientras a aplicación esta Busy*/
        private bool _enabled;

        /*PropertyChangedEventHandler: Es el que maneja el cambio de las propiedades, revibe el evento de que ha habido un cambio*/
        public event PropertyChangedEventHandler PropertyChanged;
        public string Titulo { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value)
                    Opacity = 0.5;
                else
                    Opacity = 1;
                Enabled = !value; //Enable igual a lo contrario de value.   
                SetProperty(ref _isBusy, value);
            }
        }

        /*El valor por defecto de un booleano es FALSE*/
        public ViewModelBase()
        {
            Opacity = 1;
            Enabled = true;
        }

        public double Opacity
        {
            get { return _opacity; }
            set { SetProperty(ref _opacity, value); }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }


        /*SetProperty:Se configura para cada tipo de propiedad, le pasamos la variable por referencia para que nos fije la varible, el valor y el nombre de la variable. Al pasarle la referencia de la variable lo que hace es coger el valor actual de la varible.*/
        /*Fuerza el cambio de las propiedades*/
        protected virtual bool SetProperty<T>(ref T variable, T valor, [CallerMemberName] string nombre = null)
        {
            /*Si el valo es igual, no hace nada*/
            if (object.Equals(variable, valor))
                return false;
            /*Si no es igual, actualiza el valor de la varible*/
            variable = valor;
            OnPropertyChange(nombre);
            return true;

        }

        /*Cualquier majedador de eventos va a recibir dos paramentros: el sender: this,  y propertyChangeEventArgs: recibe la propoiedad que ha cambiado*/
        protected void OnPropertyChange([CallerMemberName] string nombre = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(nombre));
            }

        }
        /*recibe el View model que esta trabajando*/
        public void SetState<T>(Action<T> action) where T : class, IViewModel
        {
            if (action != null)
                action(this as T);
        }
    }
}
