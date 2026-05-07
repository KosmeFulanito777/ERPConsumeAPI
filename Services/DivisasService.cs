using System;
using System.Collections.Generic;
using System.Text;

namespace ERPConsumeAPI.Services
{
    public class DivisasService
    {
        public decimal ConvertirAMXN(decimal monto, string moneda)
        {
            decimal result = moneda switch
            {
                "MXN" => monto,
                "USD" => monto * 17.0m,
                "EUR" => monto * 18.9m,
                _ => monto,
            };
            return result;
        }
    }
}
