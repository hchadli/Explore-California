using System.Reflection.Metadata.Ecma335;

namespace ExploreCalifornia.Models
{
    public class MonthlySpecial
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
    }
}
