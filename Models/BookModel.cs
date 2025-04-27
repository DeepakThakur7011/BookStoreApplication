using System.ComponentModel.DataAnnotations;
using WebApplication7.Helper;

namespace WebApplication7.Models
{
    public class BookModel
    {
        public int Id { get; set; }        
        public string Title { get; set; }
        [Required(ErrorMessage ="Please enter the Author of the book ")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage ="Please select the Language")]        
        public int  LanguageId { get; set; }
        public string? Langauge {  get; set; }
        public int TotalPages { get; set; } 

        [Display(Name ="Choose the cover photo")]
        [Required]
        public  IFormFile CoverPhoto { get; set; }
        public string ? CoverImageUrl { get; set; }
        [Display(Name = "Choose the gallery photo")]
        public List<IFormFile> ? GalleryFiles { get; set; }
        public List<GalleryModel> ? Gallery { get; set; }
        [Display(Name = "Upload your book in pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }
        public string? BookPdfUrl { get; set; }
    }
}
