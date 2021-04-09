using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht_Web_API.Models
{
    public class Order
    {
        public int Id { get; set; }

#nullable enable
        public int? UserId { get; set; }

        public ICollection<StoreItem> Cart { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
    }
}
