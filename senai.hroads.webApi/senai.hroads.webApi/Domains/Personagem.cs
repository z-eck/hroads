using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagem
    {
        public byte IdPersonagem { get; set; }
        public byte? IdClasse { get; set; }

        [Required(ErrorMessage ="Informe o nome do personagem")]
        public string NomePersonagem { get; set; }

        [Required(ErrorMessage = "Informe os pontos de vida do personagem")]
        public short PtsVida { get; set; }

        [Required(ErrorMessage = "Informe os pontos de mana do personagem")]
        public short PtsMana { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
