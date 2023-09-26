using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace crud_aspnet.Models
{
    public class SubGroup
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the name of the subgroup.")]
        [StringLength(80, ErrorMessage = "Subgroup name must contain a maximum of 80 characters.")]
        [MinLength(2, ErrorMessage = "The subgroup name must contain at least 2 characters.")]
        public required string Name { get; set; }

        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
