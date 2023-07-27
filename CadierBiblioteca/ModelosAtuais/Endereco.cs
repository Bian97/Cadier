using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadierBiblioteca.ModelosAtuais
{
    public class Endereco
    {

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
    }
}
