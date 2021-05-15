using System.ComponentModel.DataAnnotations;
using Libraries.Helpers;

namespace Data.ViewModels
{
    public class AgencyLoginViewModel
    {
        [Required(ErrorMessage = "Invalid identifier")]
        [MinLength(7, ErrorMessage = "Invalid identifier")]
        [MaxLength(7, ErrorMessage = "Invalid identifier")]
        public string BusinessId { get; set; }

        [Required(ErrorMessage = "Invalid password")]
        public string Password { get; set; }

        public string EncryptedPassword
        {
            get
            {
                return Cryptography.EncryptWithMD5(Password);
            }
        }
    }
}