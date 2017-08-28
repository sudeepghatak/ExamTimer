using SQLite;

namespace Timer.Data
{
    public class Config
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Key { get; set; }
        public int Value { get; set; }
 
    }
}
