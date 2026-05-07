using ERPConsumeAPI.Model;
using ERPConsumeAPI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ERPConsumeAPI.ViewModels
{
    public class FacturasViewModel : INotifyPropertyChanged
    {
        private readonly DataServices _data = App.DataService;

        private readonly ApiService _api = new();
        private readonly DivisasService _divisa = new();
        private ObservableCollection<Factura> _facturas;

        public ObservableCollection<Factura> Facturas
        {
            get => _facturas;
            set
            {
                _facturas = value;
                OnPropertyChanged(nameof(Facturas));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public FacturasViewModel()
        {
            Facturas = new ObservableCollection<Factura>();
            _ = CargarFacturas();
        }

        private async Task CargarFacturas()
        {
            await _data.CargarDatosFacturas();

            var _facturas = _data.Facturas;
            var _pagos = _data.Pagos;

            Facturas.Clear();

            foreach (var factura in _facturas)
            {
                var totalPagado = _pagos.Where(pago => pago.FacturaId == factura.FacturaId).Sum(p => p.Monto);

                var estadoFactura = "";
                if(totalPagado == 0)
                {
                    estadoFactura = "PENDIENTE";
                } else if (totalPagado < factura.Total)
                {
                    estadoFactura = "PARCIAL";
                } else
                {
                    estadoFactura = "PAGADA";
                }
                factura.Pago = estadoFactura;
                factura.Total = _divisa.ConvertirAMXN(factura.Total, factura.Moneda);
                factura.Moneda = "MXN";

                Facturas.Add(factura);
            }

            var unicos = Facturas
                    .GroupBy(factura => factura.Folio)
                    .Select(factura => factura.First())
                    .ToList();

            Facturas.Clear();

            foreach (var factura in unicos)
            {
                Facturas.Add(factura);
            }
        }
    }
}