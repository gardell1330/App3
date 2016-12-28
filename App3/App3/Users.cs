using SQLite;
using System;

namespace App3
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string IDClient { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}