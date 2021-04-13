using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht_Web_API.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
