using Cadier.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cadier.Model.Interfaces
{
    interface IInfoBasicas
    {
        String Nome { get; set; }
        Infos Info { get; set; }
        Endereco Endereco { get; set; }
    }
}
