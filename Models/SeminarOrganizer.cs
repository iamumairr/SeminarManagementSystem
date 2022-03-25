using System.ComponentModel.DataAnnotations;

namespace SeminarManagementSystem.Models
{
    public class SeminarOrganizer
    {
        public int Id { get; set; }
        [Display(Name ="Seminar")]
        public int SeminarId { get; set; }
        [Display(Name = "Organizer")]
        public int OrganizerId { get; set; }
        public Seminar Seminar { get; set; }
        public Organizer Organizer { get; set; }
    }
}