using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace crud_aspnet.Models
{
    public class Group
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Enter the name of the group.")]
        [StringLength(80, ErrorMessage = "Group name must contain a maximum of 80 characters.")]
        [MinLength(2, ErrorMessage = "The group name must contain at least 2 characters.")]
        public required string Name { get; set; }
    }
}
