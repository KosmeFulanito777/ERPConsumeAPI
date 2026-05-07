using ERPConsumeAPI.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ERPConsumeAPI.Services
{
    public class ApiService
    {
        private readonly HttpClient _http = new();
        private readonly ILogger _logger;

        public async Task<List<Cliente>> ObtenerClientes()
        {
            var response = await _http.GetAsync("https://localhost:44355/api/v1/clientes");

            if (!response.IsSuccessStatusCode)
                return [];

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<Cliente>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? [];
            return list;
        }

        public async Task<List<Factura>> ObtenerFacturas()
        {
            var response = await _http.GetAsync("https://localhost:44355/api/v1/facturas");

            if (!response.IsSuccessStatusCode)
                return [];

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<Factura>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? [];
            return list;
        }

        public async Task<List<Pago>> ObtenerPagos()
        {
            var response = await _http.GetAsync("https://localhost:44355/api/v1/Pagos");

            if (!response.IsSuccessStatusCode)
                return [];

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<Pago>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? [];
            return list;
        }
    }
}
