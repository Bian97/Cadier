using CadierBiblioteca.ModelosAtuais;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadierBiblioteca.Interfaces
{
    interface IInfoBasicas
    {
        String Nome { get; set; }
        Infos Info { get; set; }
        Endereco Endereco { get; set; }
    }
}
