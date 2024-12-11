using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace assignment_3.Models { 
    public class Guestbook {
        public Guestbook() {}
        public Guestbook(string name, string title, string message)
        {
            Name = name;
            Title = title;
            Message = message;
        }
        public int Id { get; set; }

        [Required] 
        [DisplayName("Name")] 
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50), MinLength(5)]
        [DisplayName("Title")]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [StringLength(200), MinLength(20)]
        [DisplayName("Message")]
        public string Message { get; set; } = string.Empty;
    }
}