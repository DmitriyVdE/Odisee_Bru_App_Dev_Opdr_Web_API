using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht_Web_API.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public double BuyPrice { get; set; }

        [Required]
        public int TaxLevelId { get; set; }

        public Tax TaxLevel { get; set; }

        [Required]
        public int AmountInStock { get; set; }

        [Required]
        public Boolean Active { get; set; }

        public Boolean GetInStock()
        {
            return AmountInStock > 0;
        }
    }

}
