using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JulioRivero.Tesis.WebMVC.Models
{
    public class IntoPreventionViewModel
    {
        public int Id { get; set; }
        public int PreventionId { get; set; }
        [Display(Name = "Tipo")]
        public string Kind { get; set; }
        [Required]
        [Display(Name = "Titulo")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Prevención")]
        public string Prevention { get; set; }
        [Display(Name = "Imagen")]
        public string FileImage { get; set; }
    }
}