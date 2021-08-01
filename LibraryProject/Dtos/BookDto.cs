using System.Collections.Generic;


namespace LibraryProject.Dtos
{
    public class BookDto
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public List<CommentDto> Comments { get; set; }
        public string YayinEviAdi { get; set; }
        public string YazarAdi { get; set; }
        public string Url { get; set; }
    }
}
