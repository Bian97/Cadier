using Cadier.Model.Enums;
using System;
using System.Threading.Tasks;

namespace Cadier.Model.Utilitarios
{
    public class EscolheConstrutor
    {        

        public static async Task<string> EscolherConstrutorAsync(dynamic modelo, TipoRequisicaoEnum requisicaoEnum)
        {
            try
            {
                string resultado = "";
                //if (modelo.GetType().GetProperty("Atendentes").GetValue(modelo, null).Count > 0)
                //{
                //    await ConstrutorDePosts.ConstruirAtendenteAsync(modelo.GetType().GetProperty("Atendentes").GetValue(modelo, null));
                //}

                //if (modelo.GetType().GetProperty("PFisicas").GetValue(modelo, null).Count > 0)
                //{
                //    await ConstrutorDePosts.ConstruirPFisicaAsync(modelo.GetType().GetProperty("PFisicas").GetValue(modelo, null), requisicaoEnum);
                //}

                //if (modelo.GetType().GetProperty("PJuridicas").GetValue(modelo, null).Count > 0)
                //{
                //    await ConstrutorDePosts.ConstruirPJuridicaAsync(modelo.GetType().GetProperty("PJuridicas").GetValue(modelo, null), requisicaoEnum);
                //}

                //if (modelo.GetType().GetProperty("Ordens").GetValue(modelo, null).Count > 0)
                //{
                //    resultado = await ConstrutorDePosts.ConstruirOrdemAsync(modelo.GetType().GetProperty("Ordens").GetValue(modelo, null), requisicaoEnum);
                //}

                //if (modelo.GetType().GetProperty("HistoricoConsagracao").GetValue(modelo, null).Count > 0)
                //{
                //    await ConstrutorDePosts.ConstruirHistoricosConsagracoesAsync(modelo.GetType().GetProperty("HistoricoConsagracao").GetValue(modelo, null), requisicaoEnum);
                //}

                //if (modelo.GetType().GetProperty("HistoricoCursos").GetValue(modelo, null).Count > 0)
                //{
                //    await ConstrutorDePosts.ConstruirHistoricoCursosAsync(modelo.GetType().GetProperty("HistoricoCursos").GetValue(modelo, null), requisicaoEnum);
                //}

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}