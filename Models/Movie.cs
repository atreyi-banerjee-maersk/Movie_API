using System.ComponentModel.DataAnnotations;

namespace MovieTicketApi.Models
{
    public class Movie
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public Priority Price { get; set; }
        public MovieType Type { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Ended { get; set; }
        
    }
    public enum Priority
    {
        Low , Medium , High
    }
    public enum MovieType
    {
        Action , Suspense , Horror , Comedy
    }

}
