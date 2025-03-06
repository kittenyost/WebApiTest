using System.ComponentModel.DataAnnotations;

namespace WebApiTest.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // navigation property
        public virtual ICollection<Content> PostedContent { get; set; }
    }
}