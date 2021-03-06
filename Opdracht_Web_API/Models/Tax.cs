using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht_Web_API.Models
{
    public class Tax
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int TaxPercentage { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
