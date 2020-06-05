using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MioBarber.Models
{
    public class barbero
    {
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}