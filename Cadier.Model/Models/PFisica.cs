using Cadier.Model.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadier.Model.Models
{
    public class PFisica
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
        public PJuridica PessoaJuridica { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string DocumentoIdentificacaoSocial { get; set; }
        public string Rg { get; set; }
        public Endereco Endereco { get; set; }
        public Atendente Atendente { get; set; }
        public SituacaoCadastral SituacaoCadastral { get; set; }
        public TipoMembroEnum IdTipoMembro { get; set; }
    }
}