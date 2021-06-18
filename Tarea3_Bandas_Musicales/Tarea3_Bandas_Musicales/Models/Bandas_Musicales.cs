using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea3_Bandas_Musicales.Models
{
    public class Bandas_Musicales
    {
        [Key]
        public int BandaM_Id { get; set; }
        [Display(Name = "Nombre")]
        public string BandaM_Name { get; set; }
        [Display(Name = "Genero")]
        public string BandaM_Musical_Genre { get; set; }
        [Display(Name = "Año de Creación")]
        public string BandaM_YearOfCreation { get; set; }
        [Display(Name = "Pais")]
        public string BandaM_Country { get; set; }
    }
}
