using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Cadier.Model.Models
{
    public class Endereco
    {
        public int? Id { get; set; }
        public int? IdEndereco { get; set; }

        //[JsonProperty("logradouro")]
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        //[JsonProperty("localidade")]
        public string Cidade { get; set; }
        //[JsonProperty("uf")]
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }


        public bool TodasPropriedadesSaoNulas(Endereco endereco)
        {
            return endereco == null ||
                   endereco.Id == null &&
                   endereco.Rua == null &&
                   endereco.Complemento == null &&
                   endereco.Bairro == null &&
                   endereco.Cidade == null &&
                   endereco.Estado == null &&
                   endereco.Pais == null &&
                   endereco.Cep == null &&
                   endereco.Latitude == null &&
                   endereco.Longitude == null;
        }
    }
}
