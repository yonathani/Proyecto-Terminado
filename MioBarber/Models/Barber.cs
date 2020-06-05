using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MioBarber.Models
{
    public class Barber
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre-Barbero")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [MaxLength(100)]
        public string Description { get; set; }

        public int HorarioId { get; set; }
        [ForeignKey("HorarioId")]
        public Horario Horario { get; set; }


        [Required]
        [Display(Name = "Telefono")]
        [MaxLength(100)]
        public string Phone { get; set; }
    }
}