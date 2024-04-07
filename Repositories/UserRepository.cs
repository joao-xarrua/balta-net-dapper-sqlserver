using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository
    {
        // It isn't interesting to us pass a conection parameter in each class
        // so we remove it from the methods and pass as a private variable
        private readonly SqlConnection _connection; // private variable to work with the connection inside the class     
        public UserRepository(SqlConnection connection) => _connection = connection; // constructor method receive the external connection

        // methods
        public IEnumerable<User> Get() => _connection.GetAll<User>(); // read a list of users if don't receive a id
        public User Get(int id) => _connection.Get<User>(id); // read one user if receive a id
        public void Create(User user) // create a new user when receive the user's props
        {
            user.Id = 0;
            _connection.Insert<User>(user);
        }
        public void Update(User user) // update user
        {
            if (user.Id != 0)
                _connection.Update<User>(user);

        }

        public void Delete(User user) // delete user
        {
            if (user.Id != 0)
                _connection.Delete<User>(user);

        }

        public void Delete(int id) // delete user using just the id
        {
            if (id != 0)
                return;
            var user = _connection.Get<User>(id);
            _connection.Delete<User>(user);
        }
    }
}