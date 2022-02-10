using CadierBiblioteca.Enums;
using CadierBiblioteca.ModelosAtuais;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CadierBiblioteca.Utilitarios
{
    public class ConstrutorDePosts
    {
        public static async System.Threading.Tasks.Task ConstruirAtendenteAsync(List<Atendente> atendentes)
        {
            foreach (var atendente in atendentes)
            {
                var valores = new Dictionary<string, string> { { "nome", atendente.Nome }, { "telefone", atendente.Telefone }, { "rua" , atendente.Endereco.Rua }, { "bairro", atendente.Endereco.Bairro },
                { "cidade", atendente.Endereco.Cidade }, { "estado", atendente.Endereco.Estado }, { "pais", atendente.Endereco.Pais }, { "cep", atendente.Endereco.Cep },
                {"latitude", atendente.Endereco.Latitude.ToString().Replace(',','.')}, {"longitude", atendente.Endereco.Longitude.ToString().Replace(',','.')},
                {"cpf", atendente.Info.Cpf}, {"rg", atendente.Info.Rg}};

                await WebServiceHelper.RequisicaoAsync("http://cadier.com.br/api/Atendente", valores);
            }
        }

        public static async Task<string> ConstruirPJuridicaAsync(List<PJuridica> pjuridicas, TipoRequisicaoEnum requisicaoEnum)
        {
            foreach (var pjuridica in pjuridicas)
            {
                var valores = new Dictionary<string, string> { { "IdPJuridica", pjuridica.IdPJuridica.ToString() }, { "nome", pjuridica.Nome }, { "dataFundacao", pjuridica.DataFundacao != null ? Convert.ToDateTime(pjuridica.DataFundacao).Date.ToString("dd/MM/yyyy") : null },
                { "dataEntrou", pjuridica.SituacaoCadastral.DataEntrou != null ? Convert.ToDateTime(pjuridica.SituacaoCadastral.DataEntrou).Date.ToString("dd/MM/yyyy") : null },
                { "dataAtualizado", pjuridica.SituacaoCadastral.DataAtualizado != null ? Convert.ToDateTime(pjuridica.SituacaoCadastral.DataAtualizado).Date.ToString("dd/MM/yyyy") : null },
                { "dataUltimaVisita", pjuridica.SituacaoCadastral.DataUltimaVisita != null ? Convert.ToDateTime(pjuridica.SituacaoCadastral.DataUltimaVisita).Date.ToString("dd/MM/yyyy") : null },
                { "obs", pjuridica.SituacaoCadastral.Obs}, { "email", pjuridica.Email}, { "condicao", ((int) pjuridica.SituacaoCadastral.Condicao).ToString() }, { "eFiliado", Convert.ToInt32(pjuridica.SituacaoCadastral.EFiliado).ToString() }, { "IdAtendente", pjuridica.SituacaoCadastral.Atendente.CodAtendente.ToString() } };

                if (pjuridica.Endereco != null)
                {
                    valores.Add("rua", pjuridica.Endereco.Rua);
                    valores.Add("bairro", pjuridica.Endereco.Bairro);
                    valores.Add("cidade", pjuridica.Endereco.Cidade);
                    valores.Add("estado", pjuridica.Endereco.Estado);
                    valores.Add("pais", pjuridica.Endereco.Pais);
                    valores.Add("cep", pjuridica.Endereco.Cep);
                    valores.Add("latitudeVice", pjuridica.Endereco.Latitude.ToString().Replace(',', '.'));
                    valores.Add("longitudeVice", pjuridica.Endereco.Longitude.ToString().Replace(',', '.'));
                }

                if(pjuridica.Info != null)
                {
                    valores.Add("cnpj", pjuridica.Info.Cnpj);
                }

                if(pjuridica.PFisicaPresidente != null)
                {
                    valores.Add("IdPFisicaPresidente", pjuridica.PFisicaPresidente.IdPFisica.ToString());
                }

                if (pjuridica.PFisicaVice != null)
                {
                    valores.Add("IdPFisicaVice", pjuridica.PFisicaVice.IdPFisica.ToString());
                    /*valores.Add("nomeVice", pjuridica.PFisicaVice.Nome);
                    valores.Add("cpfVice", pjuridica.PFisicaVice.Info.Cpf);
                    valores.Add("rgVice", pjuridica.PFisicaVice.Info.Rg);
                    valores.Add("telVice", pjuridica.PFisicaVice.Telefone1);

                    if (pjuridica.PFisicaVice.Endereco != null)
                    {
                        valores.Add("ruaVice", pjuridica.PFisicaVice.Endereco.Rua);
                        valores.Add("bairroVice", pjuridica.PFisicaVice.Endereco.Bairro);
                        valores.Add("cidadeVice", pjuridica.PFisicaVice.Endereco.Cidade);
                        valores.Add("estadoVice", pjuridica.PFisicaVice.Endereco.Estado);
                        valores.Add("paisVice", pjuridica.PFisicaVice.Endereco.Pais);
                        valores.Add("cepVice", pjuridica.PFisicaVice.Endereco.Cep);
                        valores.Add("latitudeVice", pjuridica.PFisicaVice.Endereco.Latitude.ToString().Replace(',', '.'));
                        valores.Add("longitudeVice", pjuridica.PFisicaVice.Endereco.Longitude.ToString().Replace(',', '.'));
                    }*/
                }

                if (requisicaoEnum == TipoRequisicaoEnum.Inserir)
                {
                    return await WebServiceHelper.RequisicaoAsync("http://cadier.com.br/api/PJuridica", valores);
                }
                else
                {
                    valores.Add("_method", "put");
                    return await WebServiceHelper.RequisicaoAsync("http://cadier.com.br/api/PJuridica/" + pjuridica.IdPJuridica, valores);
                }                
            }
            return null;
        }

        public static async Task<string> ConstruirHistoricoCursosAsync(List<HistoricoCursos> historicos, TipoRequisicaoEnum requisicaoEnum)
        {
            foreach (var historico in historicos)
            {
                var valores = new Dictionary<string, string> {{ "IdCurso", historico.IdCurso != 0 ? historico.IdCurso.ToString() : "0" }, { "curso", historico.Curso }, { "periodo", historico.Periodo },
                { "dataUltimPagam", historico.DataUltimPagam != null ? Convert.ToDateTime(historico.DataUltimPagam).Date.ToString("dd/MM/yyyy") : null }, {"restaPagar", historico.RestaPagar.ToString().Replace(",",".") },
                { "dataLevouCert", historico.DataLevouCert != null ? Convert.ToDateTime(historico.DataLevouCert).Date.ToString("dd/MM/yyyy") : null },
                { "dataFormatura", historico.DataFormatura != null ? Convert.ToDateTime(historico.DataFormatura).Date.ToString("dd/MM/yyyy") : null }, { "obs", historico.Obs }, { "IdPFisica", historico.PFisica.IdPFisica.ToString() }
                };

                if (requisicaoEnum == TipoRequisicaoEnum.Inserir)
                {
                    return await WebServiceHelper.RequisicaoAsync("http://cadier.com.br/api/Curso", valores);
                } else if (requisicaoEnum == TipoRequisicaoEnum.Alterar)
                {
                    valores.Add("_method", "put");
                    return await WebServiceHelper.RequisicaoAsync("http://cadier.com.br/api/Curso/" + historico.IdCurso, valores);
                }
            }
            return null;
        }

        public static async Task<string> ConstruirHistoricosConsagracoesAsync(List<HistoricoConsagracao> historicos, TipoRequisicaoEnum requisicaoEnum)
        {
            foreach (var historico in historicos)
            {
                var valores = new Dictionary<string, string> { { "IdConsagracao", historico.IdConsagracao != 0 ? historico.IdConsagracao.ToString() : null }, 
                    {"cargo", ((int)historico.Cargo).ToString() }, { "local", historico.Local },
                    { "data", historico.Data != null ? Convert.ToDateTime(historico.Data).Date.ToString("dd/MM/yyyy") : null }, {"igreja", historico.Igreja },
                    { "nomeIndicou", historico.NomeIndicou }, { "obs", historico.Obs }, { "IdPFisica", historico.PFisica.IdPFisica.ToString() }
                };

                if (requisicaoEnum == TipoRequisicaoEnum.Inserir)
                {
                    return await WebServiceHelper.RequisicaoAsync("http://cadier.com.br/api/Consagracao", valores);
                } else if (requisicaoEnum == TipoRequisicaoEnum.Alterar)
                {
                    valores.Add("_method", "put");
                    return await WebServiceHelper.RequisicaoAsync("http://cadier.com.br/api/Consagracao/" + historico.IdConsagracao, valores);
                }
            }
            return null;
        }
        public static async Task<string> ConstruirOrdemAsync(List<OrdemServico> ordens, TipoRequisicaoEnum requisicaoEnum)
        {
            try
            {
                var valores = new Dictionary<string, string>();
                foreach (var ordem in ordens)
                {
                    if (requisicaoEnum != TipoRequisicaoEnum.Pegar)
                    {
                        valores = new Dictionary<string, string> { { "IdOrdem", ordem.IdOrdem != 0 ? ordem.IdOrdem.ToString() : null } ,{ "servico", ordem.Servico }, { "valor", ordem.Valor > 0 ? ordem.Valor.ToString().Replace(",",".") : "0" }, { "pago", ordem.Pago > 0 ? ordem.Pago.ToString().Replace(",",".") : "0" },
                        { "creditoAnterior", ordem.CreditoAnterior > 0 ? ordem.CreditoAnterior.ToString().Replace(",",".") : "0" }, { "deposito", ordem.Deposito > 0 ? ordem.Deposito.ToString().Replace(",",".") : "0" }, { "obs", ordem.Obs }, { "dataPedido", ordem.DataPedido != null ? Convert.ToDateTime(ordem.DataPedido).Date.ToString("dd/MM/yyyy") : null },
                        { "dataFeito", ordem.DataFeito != null ? Convert.ToDateTime(ordem.DataFeito).Date.ToString("dd/MM/yyyy") : null }, {"dataEntregue", ordem.DataEntregue != null ? Convert.ToDateTime(ordem.DataEntregue).Date.ToString("dd/MM/yyyy") : null },
                        { "quemLevou", ordem.QuemLevou }, { "IdAtendente", ordem.Atendente.CodAtendente.ToString() }, { "tipoServico", ((int)ordem.TipoServico).ToString() },
                        { "dataMensalidade", ordem.DataMensalidade != null ? Convert.ToDateTime(ordem.DataMensalidade).Date.ToString("dd/MM/yyyy") : null }
                        };

                        if (ordem.PFisica != null)
                        {
                            valores.Add("IdPFisica", ordem.PFisica.IdPFisica.ToString());
                        }
                        else
                        {
                            valores.Add("IdPJuridica", ordem.PJuridica.IdPJuridica.ToString());
                        }
                    } else
                    {
                        if (ordem.PFisica != null)
                        {
                            valores.Add("IdPFisica", ordem.PFisica.IdPFisica.ToString());
                            valores.Add("tipo", "PFisica");
                        } else
                        {
                            valores.Add("IdPFisica", ordem.PJuridica.IdPJuridica.ToString());
                            valores.Add("tipo", "PJuridica");
                        }
                    }

                    //var valores = new Dictionary<string, string> { { "ordens", JsonConvert.SerializeObject(ordens.ToArray()) } };

                    if (requisicaoEnum == TipoRequisicaoEnum.Inserir)
                    {
                        return await WebServiceHelper.RequisicaoAsync("http://cadier.com.br/api/OrdemServico", valores);
                    } else if (requisicaoEnum == TipoRequisicaoEnum.Alterar)
                    {
                        valores.Add("_method", "put");
                        return await WebServiceHelper.RequisicaoAsync("http://cadier.com.br/api/OrdemServico/" + ordem.IdOrdem, valores);
                    }
                    else if (requisicaoEnum == TipoRequisicaoEnum.Pegar)
                    {
                        return await WebServiceHelper.RequisicaoAsync("http://cadier.com.br/api/lastMonthly", valores);
                    }
                }
            } catch(Exception e)
            {
                throw new Exception("Erro: " + e.Message + " " + e.StackTrace);
            }
            return null;
        }

        public static async System.Threading.Tasks.Task<string> ConstruirPFisicaAsync(List<PFisica> pfisicas, TipoRequisicaoEnum requisicaoEnum)
        {
            foreach(var pfisica in pfisicas)
            {
                var valores = new Dictionary<string, string> { { "IdPFisica", pfisica.IdPFisica.ToString() } , { "nome", pfisica.Nome }, {"profissao", pfisica.Profissao}, {"email", pfisica.Email}, { "telefone1", pfisica.Telefone1 }, { "telefone2", pfisica.Telefone2 },
                { "dataNascimento", pfisica.DataNascimento != null ? Convert.ToDateTime(pfisica.DataNascimento).Date.ToString("dd/MM/yyyy") : null }, { "sexo", Convert.ToInt32(pfisica.Sexo).ToString() },
                { "cargo", ((int) pfisica.Cargo).ToString() }, { "conjuge", pfisica.Conjuge }, { "filiacao", pfisica.Filiacao },
                { "apresentouConv", pfisica.ApresentouConv }, { "IdPJuridica", pfisica.IdPJuridica != null ? (pfisica.IdPJuridica.IdPJuridica == 0 ? null : pfisica.IdPJuridica.IdPJuridica.ToString()) : null }, { "foto", pfisica.Foto },
                { "idAtendente", pfisica.SituacaoCadastral.Atendente.CodAtendente.ToString() },
                { "dataEntrou", pfisica.SituacaoCadastral.DataEntrou != null ? Convert.ToDateTime(pfisica.SituacaoCadastral.DataEntrou).Date.ToString("dd/MM/yyyy") : null },
                { "dataAtualizado", pfisica.SituacaoCadastral.DataAtualizado != null ? Convert.ToDateTime(pfisica.SituacaoCadastral.DataAtualizado).Date.ToString("dd/MM/yyyy") : null },
                { "dataUltimaVisita", pfisica.SituacaoCadastral.DataUltimaVisita != null ? Convert.ToDateTime(pfisica.SituacaoCadastral.DataUltimaVisita).Date.ToString("dd/MM/yyyy") : null },
                { "obs", pfisica.SituacaoCadastral.Obs }, { "condicao", ((int)pfisica.SituacaoCadastral.Condicao).ToString() }, { "eFiliado", Convert.ToInt32(pfisica.SituacaoCadastral.EFiliado).ToString() }
                };

                if(pfisica.Info != null)
                {
                    valores.Add("cpf", pfisica.Info.Cpf);
                    if (pfisica.Info.Rg != null)
                    {
                        valores.Add("rg", pfisica.Info.Rg.Contains("0000") || pfisica.Info.Rg.Contains("?") ? null : pfisica.Info.Rg);
                    }
                }

                if (pfisica.Endereco != null)
                {
                    valores.Add("rua", pfisica.Endereco.Rua);
                    valores.Add("bairro", pfisica.Endereco.Bairro);
                    valores.Add("cidade", pfisica.Endereco.Cidade);
                    valores.Add("estado", pfisica.Endereco.Estado);
                    valores.Add("pais", pfisica.Endereco.Pais);
                    valores.Add("cep", pfisica.Endereco.Cep);
                    valores.Add("latitude", pfisica.Endereco.Latitude.ToString().Replace(',', '.'));
                    valores.Add("longitude", pfisica.Endereco.Longitude.ToString().Replace(',', '.'));
                }

                if (pfisica.Foto != null && pfisica.Foto != "")
                {
                    if (!pfisica.Foto.Contains("cadier.com"))
                    {
                        valores.Add("nomeArquivo", "perfil" + new FileInfo(pfisica.Foto).Extension);//new FileInfo(pfisica.Foto).Name);
                    }
                }

                ////Temporário
                //if (pfisica.IdPJuridica != null && (pfisica.IdPJuridica.Nome != "" && pfisica.IdPJuridica.Nome != null))
                //{
                //    valores.Add("nomeIgreja", pfisica.IdPJuridica.Nome);
                //    valores.Add("enderecoIgreja", pfisica.IdPJuridica.Endereco.Rua);
                //}

                if (requisicaoEnum == TipoRequisicaoEnum.Inserir)
                {
                    return await WebServiceHelper.RequisicaoAsync("http://cadier.com.br/api/PFisica", valores);
                } else
                {
                    valores.Add("_method", "put");
                    return await WebServiceHelper.RequisicaoAsync("http://cadier.com.br/api/PFisica/" + pfisica.IdPFisica, valores);
                }                
                
            }
            return null;
        }
    }
}