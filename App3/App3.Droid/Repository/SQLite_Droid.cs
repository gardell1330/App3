using System;

using App3;
using SQLite;
using System.IO;
using App3.Droid.Repository;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Droid))]
namespace App3.Droid.Repository
{
    public class SQLite_Droid : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            var fileNm = "Users.db";
            var docsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = Path.Combine(docsFolder, fileNm);
            File.Open(pathToDatabase, FileMode.OpenOrCreate);
            var conn = new SQLiteConnection(pathToDatabase);
            return conn;
        }        
    }
}