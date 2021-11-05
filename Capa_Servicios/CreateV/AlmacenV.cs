using Capa_Servicios.CreateV;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.CreateV
{
    public class AlmacenV
    {
        public int Id{ get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name ="Nombre de producto")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public float Precio { get; set; }
        public AdminsC admins { set; get; }
    }
}
