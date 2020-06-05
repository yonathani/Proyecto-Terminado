using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MioBarber.Models
{
    public class Horario
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Horario")]
        [MaxLength(100)]
        public string Time { get; set; }
    }
}