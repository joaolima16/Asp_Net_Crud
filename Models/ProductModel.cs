using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class ProductModel
    {
        
        public int? Id { get; set; }
        [Required]
        [StringLength(30)]
        public string? Name {get;set;}

        public decimal? Value {get;set;}

    }
}