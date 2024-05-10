using Cadier.Model.Enums;

namespace Cadier.API.ViewModels.PessoaFisicaViewModels
{
    public class GetFiliadosToGridViewModel
    {
        public int? NumeroRol { get; set; }
        public string? Documento { get; set; }
        public int? NumeroRolIgreja { get; set; }
        public string? NomeIgreja { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
        public CondicaoEnum? Condicao { get; set; }
        public bool Filiado { get; set; }
    }
}
