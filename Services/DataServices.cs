using ERPConsumeAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace ERPConsumeAPI.Services
{
    public class DataServices
    {
        private readonly ApiService _api = new();
        private readonly ILogger _logger;

        public List<Factura> Facturas { get; private set; }
        public List<Pago> Pagos { get; private set; }

        public async Task CargarDatosFacturas() {
            Facturas = await _api.ObtenerFacturas();
            Pagos = await _api.ObtenerPagos();
        }
    }
}
