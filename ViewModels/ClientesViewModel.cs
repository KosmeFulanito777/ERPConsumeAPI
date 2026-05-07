using ERPConsumeAPI.Model;
using ERPConsumeAPI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ERPConsumeAPI.ViewModels
{
    public class ClientesViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _api = new();
        private ObservableCollection<Cliente> _clientes;

        public ObservableCollection<Cliente> Clientes
        {
            get => _clientes;
            set
            {
                _clientes = value;
                OnPropertyChanged(nameof(Clientes));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ClientesViewModel()
        {
            Clientes = new ObservableCollection<Cliente>();
            _ = CargarClientes();
        }

        private async Task CargarClientes()
        {
            var datos = await _api.ObtenerClientes();

            Clientes.Clear();

            foreach (var cliente in datos)
            {
                cliente.Nombres = cliente.Nombres.ToUpper();
                cliente.Apellidos = cliente.Apellidos.ToUpper();
                Clientes.Add(cliente);
            }
        }
    }
}