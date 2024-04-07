using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class RoleRepository
    {
        // It isn't interesting to us pass a conection parameter in each class
        // so we remove it from the methos and pass as a private variable
        private readonly SqlConnection _connection; // private variable to work with the connection inside the class     
        public RoleRepository(SqlConnection connection) => _connection = connection; // constructor method receive the external connection

        // methods
        public IEnumerable<Role> Get() => _connection.GetAll<Role>(); // read a list of Roles if don't receive a id
        public Role Get(int id) => _connection.Get<Role>(id); // read one Role if receive a id
        public void Create(Role role) => _connection.Insert<Role>(role); // create a new Role when receive the Role's props
    }
}