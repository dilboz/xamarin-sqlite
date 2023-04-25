using SQLite;

namespace App2.Model
{
    public class Countrie
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
    
    public class Test1
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Na { get; set; }
    }
}