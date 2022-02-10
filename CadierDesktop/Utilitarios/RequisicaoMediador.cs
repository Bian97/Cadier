using CadierBiblioteca;
using CadierBiblioteca.Enums;
using CadierBiblioteca.Utilitarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CadierDesktop.Utilitarios
{
    public class RequisicaoMediador
    {
        public static WebResponse RealizaRequisicaoGet(string url)
        {
            var wsHelper = new WebServiceHelper();
            return wsHelper.RequisicaoGet(url);
        }

        public static WebResponse RealizaRequisicaoDelete(string url)
        {
            var wsHelper = new WebServiceHelper();
            return wsHelper.RequisicaoDelete(url);
        }

        public static async Task<string> RealizaRequisicaoPostEPutAsync(dynamic modelo, string tipo, TipoRequisicaoEnum requisicaoEnum)
        {
            if (tipo.Equals("Atendentes"))
            {
                return await ConstrutorDePosts.ConstruirAtendenteAsync(modelo.GetType().GetProperty("Atendentes").GetValue(modelo, null));
            }
            else if (tipo.Equals("PFisicas"))
            {
                return await ConstrutorDePosts.ConstruirPFisicaAsync(modelo.GetType().GetProperty("PFisicas").GetValue(modelo, null), requisicaoEnum);
            }
            else if (tipo.Equals("PJuridicas"))
            {
                return await ConstrutorDePosts.ConstruirPJuridicaAsync(modelo.GetType().GetProperty("PJuridicas").GetValue(modelo, null), requisicaoEnum);
            }
            else if (tipo.Equals("Ordens"))
            {
                return await ConstrutorDePosts.ConstruirOrdemAsync(modelo.GetType().GetProperty("Ordens").GetValue(modelo, null), requisicaoEnum);
            }
            else if (tipo.Equals("HistoricoConsagracao"))
            {
                return await ConstrutorDePosts.ConstruirHistoricosConsagracoesAsync(modelo.GetType().GetProperty("HistoricoConsagracao").GetValue(modelo, null), requisicaoEnum);
            }
            else if (tipo.Equals("HistoricoCurso"))
            {
                return await ConstrutorDePosts.ConstruirHistoricoCursosAsync(modelo.GetType().GetProperty("HistoricoCurso").GetValue(modelo, null), requisicaoEnum);
            }

            return null;
        }
    }
}