using AppP1.Class;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppP1.ServicesApi
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }

    public class ApiEquipos
    {
        private readonly HttpClient _httpClient;

        public ApiEquipos(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://apiequiposugel.somee.com/");
        }

        // Obtener todos los equipos
        public async Task<ApiResponse<List<EquiposCLS>>> ObtenerEquiposAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("ObtenerEquipos");
                response.EnsureSuccessStatusCode();
                var equipos = await response.Content.ReadFromJsonAsync<List<EquiposCLS>>();

                return new ApiResponse<List<EquiposCLS>>
                {
                    Data = equipos,
                    Success = true,
                    Message = "Equipos obtenidos con éxito."
                };
            }
            catch (HttpRequestException e)
            {
                return new ApiResponse<List<EquiposCLS>>
                {
                    Success = false,
                    Message = "Error al obtener equipos: " + e.Message
                };
            }
            catch (Exception e)
            {
                return new ApiResponse<List<EquiposCLS>>
                {
                    Success = false,
                    Message = "Ocurrió un error inesperado: " + e.Message
                };
            }
        }

        // Registrar un nuevo equipo (POST)
        public async Task<ApiResponse<EquiposCLS>> RegistrarNuevoEquipoAsync(EquiposCLS nuevoEquipo)
        {
            var response = await _httpClient.PostAsJsonAsync("RegistrarNuevoEquipo", nuevoEquipo);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<EquiposCLS>();
                return new ApiResponse<EquiposCLS>
                {
                    Data = data,
                    Success = true,
                    Message = "Equipo registrado con éxito."
                };
            }
            return new ApiResponse<EquiposCLS>
            {
                Success = false,
                Message = "Error al registrar el equipo."
            };
        }

        // Actualizar un equipo existente (PUT)
        public async Task<ApiResponse<EquiposCLS>> ActualizarEquipoAsync(EquiposCLS equipo)
        {
            var response = await _httpClient.PutAsJsonAsync($"ActualizarEquipo/{equipo.idEquipo}", equipo);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<EquiposCLS>();
                return new ApiResponse<EquiposCLS>
                {
                    Data = data,
                    Success = true,
                    Message = "Equipo actualizado con éxito."
                };
            }
            return new ApiResponse<EquiposCLS>
            {
                Success = false,
                Message = "Error al actualizar el equipo."
            };
        }

        // Eliminar un equipo (DELETE)
        public async Task<ApiResponse<string>> EliminarEquipoAsync(int idEquipo)
        {
            var response = await _httpClient.DeleteAsync($"EliminarEquipo/{idEquipo}");
            if (response.IsSuccessStatusCode)
            {
                return new ApiResponse<string>
                {
                    Success = true,
                    Message = "Equipo eliminado correctamente."
                };
            }
            return new ApiResponse<string>
            {
                Success = false,
                Message = "Error al eliminar el equipo."
            };
        }
    }
}
