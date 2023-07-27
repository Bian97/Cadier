using Cadier.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadier.Model.Models
{
    public class HistoricoConsagracao
    {
        public int IdConsagracao { get; set; }
        public CargosEnum Cargo { get; set; }
        public string Local { get; set; }
        public DateTime? Data { get; set; }
        public string Igreja { get; set; }
        public string NomeIndicou { get; set; }
        public string Obs { get; set; }
        public PFisica PFisica { get; set; }
    }
}
