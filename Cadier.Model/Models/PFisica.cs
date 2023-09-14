using Cadier.Model.Enums;
using Cadier.Model.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadier.Model.Models
{
    public class PFisica : IInfoBasicas
    {
        public int IdPFisica { get; set; }
        public string Profissao { get; set; }
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool Sexo { get; set; }
        [System.ComponentModel.DefaultValue(CargosEnum.Membro)]
        public CargosEnum Cargo { get; set; }
        public string Conjuge { get; set; }
        public string Filiacao { get; set; }
        public string ApresentouConv { get; set; }
        public string Indicacao { get; set; }
        public PJuridica IdPJuridica { get; set; }
        public int? IdPessoaJuridica { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public Infos Info { get; set; }
        public Endereco Endereco { get; set; }
        public SituacaoCadastral SituacaoCadastral { get; set; }
        public TipoMembroEnum IdTipoMembro { get; set; }
    }
}