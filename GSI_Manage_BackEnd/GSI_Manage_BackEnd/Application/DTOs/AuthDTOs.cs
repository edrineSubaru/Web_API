using System.ComponentModel.DataAnnotations;

namespace GSI_Manage_BackEnd.Application.DTOs
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }

    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; } = "user";
    }

    public class AuthResponse
    {
        public string Token { get; set; }
        public Domain.Entities.User User { get; set; }
    }
}