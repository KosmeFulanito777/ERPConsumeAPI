using System;
using System.Collections.Generic;
using System.Text;

namespace ERPConsumeAPI.Model
{
    public class Pago
    {
        public int PagoId { get; set; }
        public int FacturaId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
}
