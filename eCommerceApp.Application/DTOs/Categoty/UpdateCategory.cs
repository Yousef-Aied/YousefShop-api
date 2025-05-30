using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Application.DTOs.Categoty
{
    public class UpdateCategory : CategoryBase
    {
        [Required]
        public Guid Id { get; set; }
    }
}
