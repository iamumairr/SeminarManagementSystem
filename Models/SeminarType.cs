using System.ComponentModel.DataAnnotations;

namespace SeminarManagementSystem.Models
{
    public class SeminarType
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 4)]
        [Required(ErrorMessage = "Type Name is required.")]
        [Display(Name ="Type Name")]
        public string TypeName { get; set; }
    }
}