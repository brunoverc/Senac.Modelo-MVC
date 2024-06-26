﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Senac.Mvc.Scaffolding.Models
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }

        
    }

    public class UserLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Senha")]
        public string Password { get; set; }
    }

    public class UserLoginResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public List<string> Errors { get; set; }
        public ResponseResult ResponseResult { get; set; }
    }

    public class UserRegister
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "As senhas devem ser iguais.")]
        [DisplayName("Confirme sua Senha")]
        public string PasswordConfirm { get; set; }

        public ClientViewModel Client { get; set; } = new ClientViewModel();
    }

    public class UserRegisteredResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken UsuarioToken { get; set; }
        public ResponseResult ResponseResult { get; set; }
    }

    public class UserToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }

    public class UserClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
