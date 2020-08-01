using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WcfService.Model
{
    public class User
    {
        [Display(Name ="Id")]
        public int Id { get; set; }
        
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
    }
}