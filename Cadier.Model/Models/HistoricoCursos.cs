using System;
using System.Collections.Generic;
using System.Text;

namespace Cadier.Model.Models
{
    public class HistoricoCursos
    {
        public int IdCurso { get; set; }
        public int IdPessoaFisica { get; set; }
        public PFisica PFisica { get; set; }
        public string Curso { get; set; }
        public decimal RestaPagar { get; set; }
        public string Periodo { get; set; }
        public DateTime? DataUltimPagam { get; set; }
        public DateTime? DataUltimoPagamento { get; set; }
        public DateTime? DataLevouCertificado { get; set; }
        public DateTime? DataLevouCert { get; set; }
        public DateTime? DataFormatura { get; set; }
        public string Obs { get; set; }
    }
}
