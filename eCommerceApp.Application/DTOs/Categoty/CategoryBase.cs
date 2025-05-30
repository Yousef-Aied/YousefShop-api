using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Application.DTOs.Categoty
{
    public class CategoryBase
    {
        [Required]
        public string? Name { get; set; }
    }
}
