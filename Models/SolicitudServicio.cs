using System;
using System.ComponentModel.DataAnnotations;

namespace TecnoGasHogar.Models
{
    public class SolicitudServicio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        public string Cliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El distrito es obligatorio.")]
        public string Distrito { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de servicio es obligatorio.")]
        public string TipoServicio { get; set; } = string.Empty; // Instalación, Mantenimiento, Revisión, Fuga

        public string? Descripcion { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
