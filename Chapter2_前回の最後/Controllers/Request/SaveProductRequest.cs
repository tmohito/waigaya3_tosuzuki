using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Waigaya3.Models;

namespace Waigaya3.Controllers.Request
{
    public class SaveProductRequest
    {
        public int? Id { get; set; }

        public required string Name { get; set; }

        public string Description { get; set; } = "";

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
