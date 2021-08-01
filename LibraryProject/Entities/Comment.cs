namespace LibraryProject.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int BookId{ get; set; }
        public Book Book { get; set; }
        public string CommentDescription{ get; set; }
    }
}
