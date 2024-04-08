using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Tag]")]
    public class Tag
    {
        public Tag(int id, string name, string slug)
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