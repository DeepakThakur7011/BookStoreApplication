using System.ComponentModel.DataAnnotations;

namespace BookStoreApplication.Helper
{
    public class MyCustomValidationAttribute:ValidationAttribute
    {
        public MyCustomValidationAttribute(string text)
        {
            Text = text;
        }
        public string Text { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value !=null)
            {
                string bookname = value.ToString();
                if(bookname.Contains(Text))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Book Name does not contain the desired value. ");
        }
    }
}
