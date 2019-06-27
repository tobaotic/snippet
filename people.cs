using SQLite;

namespace ExistingSQLite.Model
{
    [Table("People")]
    public class People
    {
        [PrimaryKey, AutoIncrement]
        public int IDS { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
