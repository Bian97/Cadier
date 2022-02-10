using CadierBiblioteca.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadierBiblioteca.ModelosAtuais
{
    public class OrdemServico
    {
        public int IdOrdem { get; set; }
        public PFisica PFisica { get; set; }
        public PJuridica PJuridica { get; set; }
        public string Servico { get; set; }
        public decimal Valor { get; set; }
        public decimal Pago { get; set; }
        public decimal CreditoAnterior { get; set; }
        public decimal Deposito { get; set; }
        public decimal Resta => Valor - Pago - CreditoAnterior - Deposito;
        public string Obs { get; set; }
        public DateTime? DataPedido { get; set; }
        public DateTime? DataFeito { get; set; }
        public DateTime? DataEntregue { get; set; }
        public DateTime? DataMensalidade { get; set; }
        public string QuemLevou { get; set; }
        public Atendente Atendente { get; set; }
        public TipoServicoEnum TipoServico { get; set; }
    }
}
