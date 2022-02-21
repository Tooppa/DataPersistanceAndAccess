namespace CustomerDB.Models
{
    public class CustomerGenre
    {
        public string? Genre { get; set; }
        public int Number { get; set; }

        /// <summary>
        /// Converts the database element to string
        /// </summary>
        /// <returns>
        /// String containing infromation from the element
        /// </returns>
        public override string? ToString()
        {
            return "Genre: " + Genre + ", Amount: " + Number;
        }
    }
}
