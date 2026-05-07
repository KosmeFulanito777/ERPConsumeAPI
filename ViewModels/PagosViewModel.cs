using ERPConsumeAPI.Model;
using ERPConsumeAPI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace ERPConsumeAPI.ViewModels
{
    public class PagosViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _api = new();
        private ObservableCollection<Pago> _pagos;

        public ObservableCollection<Pago> Pagos
        {
            get => _pagos;
            set
            {
                _pagos = value;
                OnPropertyChanged(nameof(Pagos));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public PagosViewModel()
        {
            Pagos = new ObservableCollection<Pago>();
            _ = CargarPagos();
        }

        private async Task CargarPagos()
        {
            var datos = await _api.ObtenerPagos();

            Pagos.Clear();

            foreach (var pago in datos)
            {
                Pagos.Add(pago);
            }
        }
    }
}

