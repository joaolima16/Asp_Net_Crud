using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ProductModel
    {
        public int? Id { get; set; }
        public string? Name {get;set;}

        public decimal? Value {get;set;}

    }
}