using CadierBiblioteca.Interfaces;
using CadierBiblioteca.ModelosAtuais;
using System;

namespace CadierBiblioteca
{
    public class Atendente : IInfoBasicas
    {
        public int CodAtendente { get; set; }
        public String Telefone { get; set; }
        public string Nome { get; set; }
        public Infos Info { get; set; }
        public Endereco Endereco { get; set; }        
    }
}
