using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class // using "<T>" on the final of our class we define a generic class
    {
        // It isn't interesting to us pass a conection parameter in each class
        // so we remove it from the methods and pass as a private variable
        private readonly SqlConnection _connection; // private variable to work with the connection inside the class     
        public Repository(SqlConnection connection) => _connection = connection; // constructor method receive the external connection

        // methods: in these methods we beguin to use a concept called "Generic"
        // where we dont have to pass which object we are basing our method


        public IEnumerable<T> Get() => _connection.GetAll<T>();
        public T Get(int id) => _connection.Get<T>(id); // read one user if receive a id
        public void Create(T model) => _connection.Insert<T>(model); // create a new user when receive the user's props
        public void Update(T model) => _connection.Update<T>(model);// update user
        public void Delete(T model) => _connection.Delete<T>(model);// delete user
        public void Delete(int id) // delete user using just the id
        {
            if (id != 0)
                return;
            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model);
        }
    }
}