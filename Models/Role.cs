using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("[Role]")]
    public class Role
    {
        public Role(int id, string name, string slug)
        {
            Id = id;
            Name = name;
            Slug = slug;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}