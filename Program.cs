using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    internal class Program
    {

        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            ReadUsersWithRoles(connection);
            // CreateUser(connection);
            // ReadRoles(connection);
            // ReadTags(connection);
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            // DeleteUser();
            connection.Close();
        }
        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($"- {role.Name}");
                }
            }
        }

        public static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Name = "João Xarrua",
                Email = "joaoxarrua@balta.com",
                PasswordHash = "HASH",
                Bio = "Maior de todos",
                Image = "https://",
                Slug = "joao-xarrua"
            };
            var repository = new Repository<User>(connection);
            repository.Create(user);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();
            foreach (var item in items)
                Console.WriteLine(item.Name);
        }
        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();
            foreach (var item in items)
                Console.WriteLine(item.Name);
        }
    }
}