namespace CustomerDB.Models
{
    public class CustomerGenre
    {
        public string? Genre { get; set; }
        public int Number { get; set; }

        public override string? ToString()
        {
            return "Genre: " + Genre + ", Amount: " + Number;
        }
    }
}
