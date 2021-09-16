using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Informe o e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        [StringLength(16, MinimumLength = 8, ErrorMessage ="O campo senha deve ter no máximo 16 e no mínimo 8 caracteres.")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
