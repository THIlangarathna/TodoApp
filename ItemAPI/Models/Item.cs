using System.ComponentModel.DataAnnotations;

namespace ItemAPI.Models
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
