namespace Waigaya3.Controllers.Request.Product
{
    public class SaveRequest
    {
        public int? Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; } = "";

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
