using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MioBarber.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Fecha de Cita Programada")]
        public DateTime? Day { get; set; }
        [Required]
        [Display(Name = "Hora de Cita Programada")]
        public TimeSpan? Time { get; set; }

        public int BarberId { get; set; }
        [ForeignKey("BarberId")]
        public Barber Barber { get; set; }

        public int CorteId { get; set; }
        [ForeignKey("CorteId")]
        public Corte Corte { get; set; }
    }
}