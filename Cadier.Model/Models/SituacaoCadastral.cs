using Cadier.Model.Enums;
using System;

namespace Cadier.Model.Models
{
    public class SituacaoCadastral
    {
        public int Id { get; set; }
        public int IdSituacaoCadastral { get; set; }
        public DateTime? DataEntrou { get; set; }
        public DateTime? DataAtualizado { get; set; }
        public Atendente Atendente { get; set; }
        public DateTime? DataUltimaVisita { get; set; }
        public string Obs { get; set; }
        public CondicaoEnum? Condicao { get; set; }
        public bool EFiliado { get; set; }
    }
}
