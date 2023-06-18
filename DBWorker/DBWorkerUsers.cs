using System.Linq;
using TestReactAndEFCore.Models;
using TestReactAndEFCore.Help;

namespace TestReactAndEFCore.DBWorker
{
    public class DBWorkerUsers
    {
        private readonly  ApplicationContext<User> db;
        public DBWorkerUsers(ApplicationContext<User> context) 
        {
            db = context;
        }
        public void Add(User data)
        {
            db.Users.Add(data);
            db.SaveChanges();
        }

        public IEnumerable<User> SelectUsers()
        {
            return db.Users.ToList();

        }

        public void Update(User data) 
        {
            db.Users.Update(data);
            db.SaveChanges();
        }

        public void Delete(User data) 
        {
            db.Users.Remove(data);
            db.SaveChanges();
        }
    }
}
