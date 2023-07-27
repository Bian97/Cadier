using CadierBiblioteca.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadierBiblioteca.ModelosAtuais
{
    public class SituacaoCadastral
    {
        public DateTime? DataEntrou { get; set; }
        public DateTime? DataAtualizado { get; set; }
        public Atendente Atendente { get; set; }
        public DateTime? DataUltimaVisita { get; set; }
        public string Obs { get; set; }
        public CondicaoEnum Condicao { get; set; }
        public bool EFiliado { get; set; }
    }
}
