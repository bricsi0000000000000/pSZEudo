using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractStore.Models
{
    public class User
    {
        public int ID { get; set; }

        [DisplayName("Felhasználónév")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DisplayName("E-mail cím")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        [RegularExpression(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+", ErrorMessage = "Az email cim nem megfelelő formátumú.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        [DisplayName("Jelszó")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A mező kitöltése kötelező!")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "A jelszó nem megfelelő formátumú. Minimum 8 karakter.")]
        [DataType(DataType.Password)]
        [NotMapped] // nem menti el az adatbázisban
        public string Password { get; set; }
    }
}
