using System;
using System.ComponentModel.DataAnnotations;

namespace SeminarManagementSystem.Models
{
    public class Attendee
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 4)]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}