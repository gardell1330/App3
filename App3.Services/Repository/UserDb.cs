using SQLite;
using SQLitePCL;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using App3.Models;

namespace App3.Repository
{
    public class UserDb
    {
        private SQLiteConnection db;
        static object locker = new object();

        public UserDb()
        {
            db = DependencyService.Get<ISqlite>().GetConnection();
            db.CreateTable<Users>();
        }

        public List<Users> GetAll()
        {
            return db.Table<Users>().ToList();
        }

        public Users SaveItem(Users item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    db.Update(item);
                }
                else
                {
                    item.ID = db.Insert(item);
                }
                return item;
            }
        }

        public Users FindUserByName(string _user)
        {
            lock (locker)
            {
                var user = db.Table<Users>().FirstOrDefault(r => r.User == _user);
                return user;
            }
        }
    }
}