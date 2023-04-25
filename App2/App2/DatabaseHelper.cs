using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using App2.Model;
using SQLite;

namespace App2
{
    public class DatabaseHelper
    {
        private readonly SQLiteConnection _connection;


        public DatabaseHelper(string path)
        {
            _connection = new SQLiteConnection(path);
            _connection.CreateTable<Test1>();
        }

        public List<Test1> GetTest1(string query)
        {
            return _connection.Table<Test1>().ToList();
        }

        public int SaveTest1(Test1 test1)
        {
            /*var query = $"INSERT INTO test (name, na) VALUES('dilboz', 'safarov')"; 
            return _connection.Execute(query);*/
            return _connection.Insert(test1);
        }

        public List<User> GetUsers(string query)
        {
            return _connection.Query<User>(query);
        }

        public List<Village> GetVillage(string query)
        {
            return _connection.Query<Village>(query);
        }

        public List<Gender> GetGenders(string query)
        {
            return _connection.Query<Gender>(query);
        }

        public List<Status> GetStatus(string query)
        {
            return _connection.Query<Status>(query);
        }

        public List<SocialStatus> GetStateTrigger(string query)
        {
            return _connection.Query<SocialStatus>(query);
        }

        public List<Education> GetEducationEducation(string query)
        {
            return _connection.Query<Education>(query);
        }

        public List<DisabledLevel> GetDisabledLevel(string query)
        {
            return _connection.Query<DisabledLevel>(query);
        }

        public List<Countrie> GetCountries(string query)
        {
            return _connection.Query<Countrie>(query);
        }
    }
}