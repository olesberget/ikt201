using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace assignment_4.Models
{
    public class Blog
    {
        public Blog() {}
        public Blog(string nickname, string title, string summary, string content, DateTime time, ApplicationUser user)
        {
            Nickname = nickname;
            Title = title;
            Summary = summary;
            Content = content;
            Time = time;
            Author = user; 
        }
        public string ApplicationUserId { get; set; }
        public ApplicationUser Author { get; set; }
        public int Id { get; set; }
        public string Nickname { get; set; }
        
        [Required] 
        [DisplayName("Title")] 
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        [DisplayName("Summary")]
        public string Summary { get; set; } = string.Empty;

        
        [Required]
        [StringLength(200, MinimumLength = 20)]
        [DisplayName("Content")]
        public string Content { get; set; } = string.Empty;
        
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }
        
        
        
    }
}