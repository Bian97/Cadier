using Cadier.Model.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadier.Model.Models
{
    public class PJuridica : IInfoBasicas
    {
        public int IdPJuridica { get; set; }
        public string Nome { get; set; }
        public DateTime? DataFundacao { get; set; }
        public Infos Info { get; set; }
        public Endereco Endereco { get; set; }
        public SituacaoCadastral SituacaoCadastral { get; set; }
        public PFisica PFisicaPresidente { get; set; }
        public PFisica PFisicaVice { get; set; }
        public string Email { get; set; }
    }
}
