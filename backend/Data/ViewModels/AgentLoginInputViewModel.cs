using System.ComponentModel.DataAnnotations;
using Libraries.Helpers;

namespace Data.ViewModels
{
<<<<<<< HEAD:backend/Data/ViewModels/AgentLoginInputViewModel.cs
    public class AgentLoginInputViewModel
=======
    public class AgentLoginViewModel
>>>>>>> added-agent:backend/Data/ViewModels/AgencyLoginViewModel.cs
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