using System.ComponentModel.DataAnnotations.Schema;

namespace Waigaya3.Controllers.Request
{
    public class SaveCategoryRequest
    {
        public int Id { get; set; }

        public required string Title { get; set; }
    }
}
