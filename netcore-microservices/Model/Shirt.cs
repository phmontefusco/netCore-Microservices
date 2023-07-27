using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using netcore_microservices.Model.Validation;

namespace netcore_microservices.Model
{
    public class Shirt
    {
        
        public int ShirtId { get; set; }

        [Required]
        public string? Brand {get; set;}
        [Required]
        public string? Color { get; set;}
        
        [ShirtValidateCorretSize]
        public int? Size { get; set;}
        [Required]
        public string? Gender { get; set;}
        
        public decimal? Price { get; set;}


    }
}