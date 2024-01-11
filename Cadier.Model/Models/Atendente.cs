using Cadier.Model.Interfaces;
using Cadier.Model.Models;
using System;

namespace Cadier.Model
{
    public class Atendente : IInfoBasicas
    {
        public int CodAtendente { get; set; }
        public string Telefone { get; set; }
        public string Nome { get; set; }
        public string DocumentoIdentificacaoSocial { get; set; }
        public Infos Info { get; set; }
        public Endereco Endereco { get; set; }        
    }
}
