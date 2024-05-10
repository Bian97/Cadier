using System;

namespace Cadier.Model.Models
{
    public class PJuridica
    {        
        public int IdPJuridica { get; set; }
        public int IdAtendente { get; set; }
        public int? IdEndereco { get; set; }
        public int? IdSituacaoCadastral { get; set; }
        public string Nome { get; set; }
        public DateTime? DataFundacao { get; set; }
        public Endereco Endereco { get; set; }
        public SituacaoCadastral SituacaoCadastral { get; set; }
        public PFisica PFisicaPresidente { get; set; }
        public PFisica PFisicaVice { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
    }
}
