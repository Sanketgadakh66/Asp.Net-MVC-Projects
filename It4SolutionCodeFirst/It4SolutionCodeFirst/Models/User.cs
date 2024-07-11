using System.ComponentModel.DataAnnotations;

namespace It4SolutionCodeFirst.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        [Display(Name = "User Name")]
        [StringLength(50)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [StringLength(50)]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool isActive { get; set; }
    }
}