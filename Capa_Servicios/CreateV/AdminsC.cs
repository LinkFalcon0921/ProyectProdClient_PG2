using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.CreateV
{
    public class AdminsC
    {
        public int Id { set; get; }

        [Required]
        [StringLength(15)]
        [DataType(DataType.Text)]
        [Display(Name = "RNC")]
        public string RNC { get; set; }
        [Required]
        [StringLength(28)]
        [Display(Name = "Nombre Proveedor")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [StringLength(30)]
        [Display(Name = "Apellido")]
        [DataType(DataType.Text)]
        public string Apellido { set; get; }
        [Required]
        [Display(Name = "Telefono")]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }
        [Required]
        [Display(Name = "Correo electronico")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        public AdminsC()
        {

        }
    }

    

}
