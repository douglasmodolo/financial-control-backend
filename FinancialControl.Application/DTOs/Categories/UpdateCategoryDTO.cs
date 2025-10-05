using System.ComponentModel.DataAnnotations;

namespace FinancialControl.Application.DTOs.Categories
{
    public class UpdateCategoryDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
