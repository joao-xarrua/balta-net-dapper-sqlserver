using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Category]")]
    public class Category
    {
        public Category(int id, string name, string slug, List<Post> posts)
        {
            Id = id;
            Name = name;
            Slug = slug;
            Posts = new List<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<Post> Posts { get; set; }
    }
}