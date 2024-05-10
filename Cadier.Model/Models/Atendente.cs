using Cadier.Model.Models;

namespace Cadier.Model
{
    public class Atendente
    {
        public int CodAtendente { get; set; }
        public int IdAtendente { get; set; }
        public string Telefone { get; set; }
        public string Nome { get; set; }
        public string DocumentoIdentificacaoSocial { get; set; }
        public Endereco Endereco { get; set; }        
    }
}
