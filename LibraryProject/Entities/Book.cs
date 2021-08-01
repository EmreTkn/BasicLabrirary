using System.Collections.Generic;

namespace LibraryProject.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public List<Comment> Comments { get; set; }
        public string YayinEviAdi { get; set; }
        public string YazarAdi { get; set; }
        public string Url { get; set; }
    }
}
