﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagem
    {
        public byte IdPersonagem { get; set; }
        public byte? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public short PtsVida { get; set; }
        public short PtsMana { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
