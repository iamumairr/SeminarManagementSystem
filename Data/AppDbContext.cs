using SeminarManagementSystem.Models;
using System.Data.Entity;

namespace SeminarManagementSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base()
        {

        }
        public DbSet<SeminarType> SeminarTypes { get; set; }
        public DbSet<Seminar> Seminars { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        public DbSet<SeminarOrganizer> SeminarOrganizers { get; set; }
    }
}