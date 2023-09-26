using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace crud_aspnet.Models
{
    public class Product
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter the product code.")]
        [MinLength(5, ErrorMessage = "The code must contain at least 5 characters.")]
        public required string Code { get; set; }
        
        [Required(ErrorMessage = "Enter the product group.")]
        public int GroupId { get; set; }
        public Group? Group { get; set; }

        [Required(ErrorMessage = "Enter the product subgroup.")]
        public int SubGroupId { get; set; }
        public SubGroup? SubGroup { get; set;}

        [Required(ErrorMessage = "Enter the cost of the product.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The cost value must be greater than zero.")]
        public double Cost { get; set; }

        [Required(ErrorMessage = "Enter the product's profit margin.")]
        [Range(0, 100, ErrorMessage = "The margin must be between 0 and 100 percent.")]
        public int ProfiMargin { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "The sales value must be greater than zero.")]
        [Required(ErrorMessage = "Enter the sales value of the product.")]
        public double SaleValue { get; set; }
    }
}
