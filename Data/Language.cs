using Humanizer;

namespace WebApplication7.Data
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Books> Books { get; set; }
    }
}
