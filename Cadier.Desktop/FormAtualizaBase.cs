using Cadier.Desktop.Utilitarios;
using Cadier.Model;
using Cadier.Model.Enums;
using Cadier.Model.Models;
using Cadier.Model.Utilitarios;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadier.Desktop
{
    public partial class FormAtualizaBase : Form
    {
        private readonly JsonParaClasse _jsonParaClasse;

        public FormAtualizaBase()
        {
            _jsonParaClasse = new JsonParaClasse();
            InitializeComponent();
        }

        private void FormAtualizaBase_Load(object sender, EventArgs e)
        {

        }        

        //private dynamic TransformaJson(WebResponse valor)
        //{
        //    var serializer = new JsonSerializer();
        //    using (var response = new StreamReader(valor.GetResponseStream()))
        //    {
        //        using (var jsonTextReader = new JsonTextReader(response))
        //        {
        //            return serializer.Deserialize<dynamic>(jsonTextReader);
        //        }                
        //    }
        //}

        private dynamic TransformaJson(WebResponse valor)
        {
            if (((HttpWebResponse)valor).StatusCode == HttpStatusCode.NotFound)
            {
                MessageBoxes.MostraMensagens("Número do Rol não encontrado!", "Erro!");
                return null;
            }
            else
            {
                using (var response = new StreamReader(valor.GetResponseStream()))
                {
                    string json = response.ReadToEnd();
                    return JsonConvert.DeserializeObject(json);
                }
            }
        }

        private List<Atendente> GetAtendentes()
        {
            char[] delimitadores = { '-' };
            var responseAtendente = RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/WSDesktop/wsListAtendentes.php");
            var objectAtendentes = TransformaJson(responseAtendente);
            var atendentes = new List<Atendente>();
            GoogleMapsUtil mapsUtil = new GoogleMapsUtil();

            foreach (var item in objectAtendentes)
            {
                string endereco = item["endereco"];
                var atendente = new Atendente()
                {
                    CodAtendente = item["cod_atend"],
                    Nome = item["nome"],
                    Info = new Infos() { Rg = item["rg"], Cpf = item["cpf"] },
                    Endereco = mapsUtil.GetGoogleMapsEndereco(endereco.Split(delimitadores).First(), endereco.Split(delimitadores)[1], "Rio de Janeiro", "21.250-260") //new Endereco() { Rua = endereco.Split(delimitadores).First(), Bairro = endereco.Split(delimitadores)[1] }
                };
                atendentes.Add(atendente);
            }

            return atendentes;
        }

        private List<PFisica> GetPFisicas()
        {
            try
            {
                var responsePFisica = RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/WSDesktop/wsListAllPFisica.php");
                var objectPFisicas = TransformaJson(responsePFisica);
                var pfisicas = new List<PFisica>();
                GoogleMapsUtil mapsUtil = new GoogleMapsUtil();

                foreach (var item in objectPFisicas)
                {
                    string status = item["status"];
                    bool sexo = item["sexo"] == 0 ? false : true;
                    var dataNascimento = Convert.ToString(item["nasc"]) == "  /  /    " || Convert.ToString(item["nasc"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["nasc"]));
                    var dataAtualizado = Convert.ToString(item["atualizado"]) == "  /  /    " || Convert.ToString(item["atualizado"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["atualizado"]));
                    var dataEntrou = Convert.ToString(item["dataentrou"]) == "  /  /    "  || Convert.ToString(item["dataentrou"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["dataentrou"]));
                    var dataUltimaVis = Convert.ToString(item["ultimaviz"]) == "  /  /    " || Convert.ToString(item["ultimaviz"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["ultimaviz"]));
                    var cpf = item["cpf"] == "   .   .   -  " || item["cpf"] == "000.000.000-00" ? null : item["cpf"];
                    var cargo = item["cargo"] == "" || item["cargo"] == "null" ? CargosEnum.Membro : ConferirCargo(((string)item["cargo"]).ToLower());
                    var tel1 = item["tel"] == "(  )     -    " || item["tel"] == "(00)00000-0000" ? null : item["tel"];
                    var tel2 = item["telop"] == "(  )     -    " || item["telop"] == "(00)00000-0000" ? null : item["telop"];

                    var pfisica = new PFisica()
                    {
                        IdPFisica = item["rol"],
                        Nome = item["nome"],
                        Profissao = item["profissao"],
                        Email = item["email"],
                        Telefone1 = tel1,
                        Telefone2 = tel2,
                        DataNascimento = dataNascimento,
                        Sexo = sexo,
                        Cargo = cargo,
                        Conjuge = item["conjuge"],
                        Filiacao = item["filiacao"],
                        ApresentouConv = item["apres"],
                        Foto = item["foto"],
                        Info = new Infos() { Cpf = cpf, Rg = item["rg"] },
                        SituacaoCadastral = new SituacaoCadastral()
                        {
                            DataAtualizado = dataAtualizado,
                            DataEntrou = dataEntrou,
                            DataUltimaVisita = dataUltimaVis,
                            Obs = item["obs"],
                            Condicao = (CondicaoEnum)Enum.Parse(typeof(CondicaoEnum), ((status.Replace(" ", ""))
                            .Replace("ê","e"))
                            .Replace("í","i")),
                            Atendente = new Atendente() { CodAtendente = item["atualizult"] },
                            EFiliado = true
                        },
                        //Endereco = mapsUtil.GetGoogleMapsEndereco(Convert.ToString(item["rua"]), Convert.ToString(item["bairro"]), Convert.ToString(item["cidade"]), Convert.ToString(item["cep"])),
                        IdPJuridica = new PJuridica() { Nome = item["igreja"], Endereco = new Endereco() { Rua = item["endigr"] } }
                    };
                    pfisicas.Add(pfisica);
                }

                return pfisicas;
            } catch(Exception e)
            {
                throw e;
            }
        }

        private List<PJuridica> GetPJuridicas()//List<PFisica> pFisicas)
        {
            try
            {
                var responsePJuridica = RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/WSDesktop/wsListAllPJuridica.php");
                var objectPJuridicas = TransformaJson(responsePJuridica);
                var pjuridicas = new List<PJuridica>();
                GoogleMapsUtil mapsUtil = new GoogleMapsUtil();

                foreach (var item in objectPJuridicas)
                {
                    string status = item["status"];
                    var dataFundacao = Convert.ToString(item["datafunda"]) == "  /  /    " || Convert.ToString(item["datafunda"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["datafunda"]));
                    var dataAtualizado = Convert.ToString(item["atualizado"]) == "  /  /    " || Convert.ToString(item["atualizado"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["atualizado"]));
                    var dataEntrou = Convert.ToString(item["dataentr"]) == "  /  /    " || Convert.ToString(item["dataentr"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["dataentr"]));
                    var dataUltimaVis = Convert.ToString(item["ultvizu"]) == "  /  /    " || Convert.ToString(item["ultvizu"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["ultvizu"]));
                    var cnpj = item["cnpj"] == "  .   .   /    -  " || item["cnpj"] == "00.000.000/0000-00" || item["cnpj"] == " .   .   /    -  " ? null : item["cnpj"];
                    var cpf = item["cpf"] == "   .   .   -  " || item["cpf"] == "000.000.000-00" ? null : item["cpf"];

                    var pjuridica = new PJuridica() { 
                        IdPJuridica = item["rol"],
                        DataFundacao = dataFundacao,
                        Nome = item["nome"],
                        Email = item["email"],
                        Endereco = mapsUtil.GetGoogleMapsEndereco(Convert.ToString(item["rua"]), Convert.ToString(item["bairro"]), Convert.ToString(item["cidade"]), Convert.ToString(item["cep"]))/* new Endereco()
                        {
                            Rua = item["rua"],
                            Bairro = item["bairro"],
                            Cidade = item["cidade"],
                            Estado = item["estado"],
                            Pais = item["pais"],
                            Cep = item["cep"]
                        }*/,
                        Info = new Infos() { Cnpj = cnpj },
                        SituacaoCadastral = new SituacaoCadastral() { Atendente = new Atendente() { 
                            CodAtendente = item["fk_atult"]},
                            Condicao = (CondicaoEnum)Enum.Parse(typeof(CondicaoEnum), ((status.Replace(" ", ""))
                            .Replace("ê", "e"))
                            .Replace("í", "i")),
                            DataAtualizado = dataAtualizado,
                            DataEntrou = dataEntrou,
                            DataUltimaVisita = dataUltimaVis,
                            Obs = item["obs"],
                            EFiliado = true
                        },
                        PFisicaPresidente = new PFisica() { IdPFisica = item["rolpres"]},
                        PFisicaVice = new PFisica() { 
                            Nome = item["nomevice"], 
                            Endereco = mapsUtil.GetGoogleMapsEndereco(Convert.ToString(item["ruavice"]), Convert.ToString(item["bairrovice"]), null, Convert.ToString(item["cepvice"]))/*new Endereco() { 
                                Rua = item["ruavice"],
                                Bairro = item["bairrovice"],
                                Cep = item["cepvice"]
                            }*/,
                            Telefone1 = item["tel"] != "(  )     -" ? item["tel"] : null,
                            Info = new Infos() { Cpf = cpf, Rg = item["rg"]},
                            SituacaoCadastral = new SituacaoCadastral() {  EFiliado = false /*(cpf != "" && 
                            cpf != null)
                            && pFisicas.Any(x => x.Nome.Contains(((string)item["nomevice"])) || x.Info.Cpf != null 
                            && x.Info.Cpf.Contains(cpf)) ? true : false*/}
                            //Botei false, mas mudar usando query. Depois retornar código quanto utilizar "a vera".
                        }
                    };
                    pjuridicas.Add(pjuridica);
                }
                return pjuridicas;
            } catch (Exception e)
            {
                throw e;
            }
        }

        private List<OrdemServico> GetOrdemServico()
        {
            try
            {
                var responseOrdem = RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/WSDesktop/wsListAllOrdemServico.php");
                var objectOrdem = TransformaJson(responseOrdem);
                var ordens = new List<OrdemServico>();

                foreach(var item in objectOrdem)
                {
                    var dataSoli = Convert.ToString(item["datasoli"]) == "  /  /    " || Convert.ToString(item["datasoli"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["datasoli"]));
                    var dataFez = Convert.ToString(item["datafez"]) == "  /  /    " || Convert.ToString(item["datafez"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["datafez"]));
                    var dataEnt = Convert.ToString(item["dataent"]) == "  /  /    " || Convert.ToString(item["dataent"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["dataent"]));
                    var tipoServ = ((string) Convert.ToString(item["tiposerv"])).ToLower().Contains("mens") && !((string)Convert.ToString(item["tiposerv"])).ToLower().Contains("curso") && !((string)Convert.ToString(item["tiposerv"])).ToLower().Contains("saber") ? TipoServicoEnum.Mensalidade : TipoServicoEnum.Outros;
                    int anoServico = 0;
                    if (tipoServ == TipoServicoEnum.Mensalidade && Regex.Match(((string)Convert.ToString(item["tiposerv"])).ToLower(), @"\d+").Value == "")
                    {
                        anoServico = ((DateTime) Convert.ToDateTime(dataSoli)).Year;
                    }

                    var ordemServico = new OrdemServico() {
                        Atendente = new Atendente() { CodAtendente = item["fk_atend"] },
                        DataEntregue = dataEnt,
                        DataFeito = dataFez,
                        DataPedido = dataSoli,
                        Deposito = item["deposito"],
                        Obs = item["obs"],
                        Valor = Convert.ToDecimal(item["valorserv"]),
                        Pago = Convert.ToDecimal(item["pghj"]),
                        CreditoAnterior = Convert.ToDecimal(item["creditoant"]),
                        QuemLevou = item["nomelevou"],
                        Servico = item["tiposerv"],
                        TipoServico = tipoServ,
                        PFisica = new PFisica() { IdPFisica = item["fk_rolfis"]},
                        DataMensalidade = tipoServ == TipoServicoEnum.Mensalidade ? LocalizadorMensalidade.PegaData((string)(Convert.ToString(item["tiposerv"])).ToLower() + (anoServico != 0 ? " " + anoServico.ToString() : "")) : null
                    };

                    ordens.Add(ordemServico);
                }

                responseOrdem = RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/WSDesktop/wsListAllOrdemServicoJur.php");
                objectOrdem = TransformaJson(responseOrdem);

                foreach (var item in objectOrdem)
                {
                    var dataSoli = Convert.ToString(item["datasoli"]) == "  /  /    " || Convert.ToString(item["datasoli"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["datasoli"]));
                    var dataFez = Convert.ToString(item["datafez"]) == "  /  /    " || Convert.ToString(item["datafez"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["datafez"]));
                    var dataEnt = Convert.ToString(item["dataent"]) == "  /  /    " || Convert.ToString(item["dataent"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["dataent"]));
                    var tipoServ = ((string)Convert.ToString(item["tiposerv"])).Contains("mens") ? TipoServicoEnum.Mensalidade : TipoServicoEnum.Outros;
                    int anoServico = 0;
                    if (tipoServ == TipoServicoEnum.Mensalidade && Regex.Match(((string)Convert.ToString(item["tiposerv"])).ToLower(), @"\d+").Value == "")
                    {
                        anoServico = ((DateTime)Convert.ToDateTime(dataSoli)).Year;
                    }

                    var ordemServico = new OrdemServico()
                    {
                        Atendente = new Atendente() { CodAtendente = item["fk_atende"] },
                        DataEntregue = dataEnt,
                        DataFeito = dataFez,
                        DataPedido = dataSoli,
                        Deposito = item["deposito"],
                        Obs = item["obs"],
                        Valor = Convert.ToDecimal(item["valorserv"]),
                        Pago = Convert.ToDecimal(item["pghj"]),
                        CreditoAnterior = Convert.ToDecimal(item["creditoant"]),
                        QuemLevou = item["nomelevou"],
                        Servico = item["tiposerv"],
                        TipoServico = tipoServ,
                        PJuridica = new PJuridica() { IdPJuridica = item["fk_roljur"] },
                        DataMensalidade = tipoServ == TipoServicoEnum.Mensalidade ? LocalizadorMensalidade.PegaData(Convert.ToString(item["tiposerv"]).ToLower() + (anoServico != 0 ? " " + anoServico.ToString() : "")) : null
                    };

                    ordens.Add(ordemServico);
                }

                return ordens;
            } catch (Exception e)
            {
                throw e;
            }
        }

        private CargosEnum ConferirCargo(string cargo)
        {
            if (cargo.Contains("resi") || cargo.Contains("pas"))
                return CargosEnum.Pastor;
            if (cargo.Contains("ev"))
                return CargosEnum.Evangelista;
            if (cargo.Contains("mis"))
                return CargosEnum.Missionario;
            if (cargo.Contains("pre"))
                return CargosEnum.Presbitero;
            if (cargo.Contains("dia") || cargo.Contains("diá"))
                return CargosEnum.Diacono;
            if (cargo.Contains("ob"))
                return CargosEnum.Obreiro;
            if (cargo.Contains("aux"))
                return CargosEnum.Auxiliar;

            return CargosEnum.Membro;
        }

        private List<HistoricoConsagracao> GetHistoricoConsagracao()
        {
            try
            {
                var responseHistorico = RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/WSDesktop/wsListAllCons.php");
                var objectHistoricos = TransformaJson(responseHistorico);
                var historicos = new List<HistoricoConsagracao>();

                foreach (var item in objectHistoricos)
                {
                    var dataConsagracao = Convert.ToString(item["data"]) == "  /  /    " || Convert.ToString(item["data"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["data"]));
                    var local = ((string)Convert.ToString(item["local"])).Contains("u813766663_conv") ? "Convenção Cadier" : item["local"];
                    var igreja = ((string)Convert.ToString(item["igreja"])).Contains("u813766663_conv") ? "Convenção Cadier" : item["igreja"];
                    var cargo = item["cargo"] == "" || item["cargo"] == "null" ? CargosEnum.Membro : ConferirCargo(((string)item["cargo"]).ToLower());

                    var historico = new HistoricoConsagracao() {
                        PFisica = new PFisica() { IdPFisica = item["fkrol"] },
                        Data = dataConsagracao,
                        Local = local,
                        Cargo = cargo,
                        Igreja = igreja,
                        NomeIndicou = item["indicou"],
                        Obs = item["obs"]
                    };
                    historicos.Add(historico);
                }
                return historicos;
            } catch(Exception e)
            {
                throw e;
            }
        }

        private List<HistoricoCursos> GetHistoricoCursos()
        {
            try
            {
                var responseHistorico = RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/WSDesktop/wsListAllCursos.php");
                var objectHistoricos = TransformaJson(responseHistorico);
                var historicos = new List<HistoricoCursos>();

                foreach (var item in objectHistoricos)
                {
                    var dataPagamento = Convert.ToString(item["datapg"]) == "  /  /    " || Convert.ToString(item["datapg"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["datapg"]));
                    var dataLevouCertif = Convert.ToString(item["datalevcert"]) == "  /  /    " || Convert.ToString(item["datalevcert"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["datalevcert"]));
                    var dataFormatura = Convert.ToString(item["dtaform"]) == "  /  /    " || Convert.ToString(item["dtaform"]) == "00/00/0000" ? null : Convert.ToDateTime(Convert.ToString(item["dtaform"]));

                    var historico = new HistoricoCursos()
                    {                      
                        PFisica = new PFisica() { IdPFisica = item["fkrolcursos"] },
                        Curso = item["curso"],
                        Periodo = item["periodo"],
                        RestaPagar = item["resta"],
                        Obs = item["obs"],
                        DataFormatura = dataFormatura,
                        DataLevouCert = dataLevouCertif,
                        DataUltimPagam = (dataPagamento == null && item["resta"] == 0) ? dataFormatura : dataPagamento
                    };
                    historicos.Add(historico);
                }
                return historicos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }        

        //private Endereco GetGoogleMapsEnderecoAutocomplete(string localidade, string bairro, string cidade, string cep)
        //{
        //    try
        //    {
        //        string url = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + localidade + "+" + bairro + "+" + cidade + "+" + cep + "&types=geocode&language=pt_BR&key=AIzaSyB-qZXZAikle8f3GzANJTrJ3vm7W1o_7a0";

        //        WebRequest request = WebRequest.Create(url);

        //        using (var response = request.GetResponse())
        //        {
        //            var jsonEndereco = TransformaJson(response);
        //            response.Close();
        //            var resultados = jsonEndereco["results"];
        //        }
        //    } catch (Exception e)
        //    {
        //        throw e;
        //    }

        //    return null;
        //}

        private async Task GuardarDadosAsync(dynamic modelo)
        {
            await EscolheConstrutor.EscolherConstrutorAsync(modelo, TipoRequisicaoEnum.Inserir);
        }

        private async Task AlterarDadosAsync(dynamic modelo)
        {
            await EscolheConstrutor.EscolherConstrutorAsync(modelo, TipoRequisicaoEnum.Alterar);
        }

        private async void btnAtualizar_Click(object sender, EventArgs e)
        {
            lblStatusAtualizacao.Text = "Recuperando dados da hostinger";
            var jsonPJuridicas = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/PJuridica"));
            var pjuridicas = ((List<PJuridica>)_jsonParaClasse.GetPJuridicas(jsonPJuridicas)).AsParallel().ToList();

            var jsonPFisicas = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/PFisica?tipo=0&status=0"));
            var pfisicas = ((List<PFisica>)_jsonParaClasse.GetPFisicas(jsonPFisicas)).AsParallel().ToList();

            var jsonHistoricoCursos = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/listAllCursos"));
            var historicoCursos = ((List<HistoricoCursos>)_jsonParaClasse.GetCursos(jsonHistoricoCursos)).AsParallel().ToList();
            
            var jsonHistoricoConsagracoes = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/listAll"));
            var historicoConsagracoes = ((List<HistoricoConsagracao>)_jsonParaClasse.GetConsagracoes(jsonHistoricoConsagracoes)).AsParallel().ToList();

            var jsonOrdemServicos = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/getAllOrders"));
            var ordemServicos = ((List<OrdemServico>)_jsonParaClasse.GetOrdens(jsonOrdemServicos)).AsParallel().ToList();

            lblStatusAtualizacao.Text = "Iniciando importação de Pessoa Jurídica.";
            int indice = 1;
            string bearerToken = JsonConvert.DeserializeObject<dynamic>(await RequisicaoMediador.RealizaRequisicaoPost(@"https://localhost:7095/autenticacao/login", new { nome = "teste", cpf = "teste" }, null)).token;
            foreach (var pjuridica in pjuridicas)
            {

                lblStatusAtualizacao.Text = "Importando Pessoa Jurídica. "+indice+ " de "+pjuridicas.Count;
                int idTemporario = 0;

                if(pjuridica.SituacaoCadastral != null)
                {
                    int.TryParse(JsonConvert.DeserializeObject<dynamic>(await RequisicaoMediador.RealizaRequisicaoPost("https://localhost:7095/SituacaoCadastral", pjuridica.SituacaoCadastral, bearerToken)).ToString(), out idTemporario);
                    pjuridica.IdSituacaoCadastral = idTemporario;
                    pjuridica.IdAtendente = pjuridica.SituacaoCadastral.Atendente.CodAtendente;
                }

                if(!new Endereco().TodasPropriedadesSaoNulas(pjuridica.Endereco))
                {
                    int.TryParse(JsonConvert.DeserializeObject<dynamic>(await RequisicaoMediador.RealizaRequisicaoPost("https://localhost:7095/Endereco", pjuridica.Endereco, bearerToken)).ToString(), out idTemporario);
                    pjuridica.IdEndereco = idTemporario;
                }
                
                if(pjuridica.Info != null && !string.IsNullOrEmpty(pjuridica.Info.Cnpj))
                    pjuridica.Cnpj = Regex.Replace(pjuridica.Info.Cnpj, "[^0-9]", "");

                await RequisicaoMediador.RealizaRequisicaoPost("https://localhost:7095/PessoaJuridica", pjuridica, bearerToken);
                indice++;
            }

            lblStatusAtualizacao.Text = "Iniciando importação de Pessoa Física.";
            indice = 1;


            foreach (var pfisica in pfisicas)
            {
                lblStatusAtualizacao.Text = "Importando Pessoa Física. " + indice + " de " + pfisicas.Count;
                int idTemporario = 0;

                if (pfisica.SituacaoCadastral != null)
                {
                    int.TryParse(JsonConvert.DeserializeObject<dynamic>(await RequisicaoMediador.RealizaRequisicaoPost("https://localhost:7095/SituacaoCadastral", pfisica.SituacaoCadastral, bearerToken)).ToString(), out idTemporario);
                    pfisica.IdSituacaoCadastral = idTemporario;
                    pfisica.IdAtendente = pfisica.SituacaoCadastral.Atendente.CodAtendente;
                }

                if (!new Endereco().TodasPropriedadesSaoNulas(pfisica.Endereco))
                {
                    int.TryParse(JsonConvert.DeserializeObject<dynamic>(await RequisicaoMediador.RealizaRequisicaoPost("https://localhost:7095/Endereco", pfisica.Endereco, bearerToken)).ToString(), out idTemporario);
                    pfisica.IdEndereco = idTemporario;
                }

                if (pfisica.Info != null)
                {
                    if (!string.IsNullOrEmpty(pfisica.Info.Cpf) && Regex.Replace(pfisica.Info.Cpf, "[^0-9]", "").Count(char.IsDigit) < 13)
                        pfisica.Cpf = pfisica.Info.Cpf;

                    pfisica.DocumentoIdentificacaoSocial = pfisica.Cpf;


                    if (!string.IsNullOrEmpty(pfisica.Info.Rg) && Regex.Replace(pfisica.Info.Rg, "[^0-9]", "").Count(char.IsDigit) < 13)
                        pfisica.Rg = pfisica.Info.Rg;
                }

                pfisica.Indicacao = pfisica.ApresentouConv;

                if(pfisica.IdPJuridica != null)
                {
                    if(pfisica.IdPJuridica.IdPJuridica == 0 && pfisica.IdPJuridica.Nome == null)
                    {
                        pfisica.IdPessoaJuridica = null;
                        pfisica.IdTipoMembro = TipoMembroEnum.Membro;
                    }
                    else
                    {
                        if (pfisica.IdPJuridica.IdPJuridica == 0)
                        {
                            pfisica.IdPessoaJuridica = pjuridicas.Where(x => x.Nome.ToLower().Contains(pfisica.IdPJuridica.Nome.ToLower())).Select(x => x.IdPJuridica).FirstOrDefault();
                        }
                        else
                        {
                            pfisica.IdPessoaJuridica = pfisica.IdPJuridica.IdPJuridica;
                        }

                        if (pfisica.IdPessoaJuridica != null && pfisica.IdPessoaJuridica > 0)
                        {
                            var juridicaPertencente = pjuridicas.Where(x => x.IdPJuridica == pfisica.IdPessoaJuridica).FirstOrDefault();

                            if (juridicaPertencente.PFisicaPresidente?.IdPFisica == pfisica.IdPFisica)
                                pfisica.IdTipoMembro = TipoMembroEnum.Presidente;
                            else if (juridicaPertencente.PFisicaVice?.IdPFisica == pfisica.IdPFisica)
                                pfisica.IdTipoMembro = TipoMembroEnum.VicePresidente;
                            else pfisica.IdTipoMembro = TipoMembroEnum.Membro;
                        }
                        else
                        {
                            pfisica.IdPessoaJuridica = null;
                            pfisica.IdTipoMembro = TipoMembroEnum.Membro;                            
                        }
                    }
                }                

                await RequisicaoMediador.RealizaRequisicaoPost("https://localhost:7095/PessoaFisica", pfisica, bearerToken);
                indice++;
            }


            lblStatusAtualizacao.Text = "Iniciando importação de Histórico de Cursos.";
            indice = 1;
            foreach(var historicoCurso in historicoCursos)
            {
                lblStatusAtualizacao.Text = "Importando Histórico de Cursos. " + indice + " de " + historicoCursos.Count;

                historicoCurso.IdPessoaFisica = historicoCurso.PFisica.IdPFisica;
                historicoCurso.DataFormatura = historicoCurso.DataFormatura != null && historicoCurso.DataFormatura.Value > new DateTime(2000, 01, 01) ? historicoCurso.DataFormatura : null;
                historicoCurso.DataLevouCertificado = historicoCurso.DataLevouCert != null && historicoCurso.DataLevouCert.Value > new DateTime(2000, 01, 01) ? historicoCurso.DataLevouCert : null;
                historicoCurso.DataUltimoPagamento = historicoCurso.DataUltimPagam != null && historicoCurso.DataUltimPagam.Value > new DateTime(2000, 01, 01) ? historicoCurso.DataUltimPagam : null;

                await RequisicaoMediador.RealizaRequisicaoPost("https://localhost:7095/HistoricoCurso", historicoCurso, bearerToken);
                indice++;
            }

            lblStatusAtualizacao.Text = "Iniciando importação de Histórico de Consagrações.";
            indice = 1;
            foreach(var historicoConsagracao in historicoConsagracoes)
            {
                lblStatusAtualizacao.Text = "Importando Histórico de Consagrações. " + indice + " de " + historicoConsagracoes.Count;

                historicoConsagracao.IdPessoaFisica = historicoConsagracao.PFisica.IdPFisica;
                historicoConsagracao.DataLiturgia = historicoConsagracao.Data != null && historicoConsagracao.Data.Value > new DateTime(1960, 01, 01) ? historicoConsagracao.Data : null;
                historicoConsagracao.Lugar = historicoConsagracao.Local;

                await RequisicaoMediador.RealizaRequisicaoPost("https://localhost:7095/HistoricoConsagracao", historicoConsagracao, bearerToken);
                indice++;
            }

            lblStatusAtualizacao.Text = "Iniciando importação de Ordens de Serviços.";
            indice = 1;

            foreach(var ordemServico in ordemServicos)
            {
                lblStatusAtualizacao.Text = "Importando Ordens de Serviço. " + indice + " de " + ordemServicos.Count;
                ordemServico.Mensalidade = ordemServico.DataMensalidade.HasValue && ordemServico.DataMensalidade.Value < new DateTime(2000, 01, 01) ? null : ordemServico.DataMensalidade;

                ordemServico.DataEntregue = ordemServico.DataEntregue != null && ordemServico.DataEntregue.Value > DateTime.MinValue && ordemServico.DataEntregue.Value > new DateTime(2000, 01, 01) ? (ordemServico.DataMensalidade != null && ordemServico.DataEntregue.Value < DateTime.Now ? ordemServico.DataMensalidade : ordemServico.DataEntregue) : null;
                ordemServico.DataPedido = ordemServico.DataPedido != null && ordemServico.DataPedido.Value > DateTime.MinValue && ordemServico.DataPedido.Value > new DateTime(2000, 01, 01) ? (ordemServico.DataMensalidade != null && ordemServico.DataPedido.Value < DateTime.Now? ordemServico.DataMensalidade : ordemServico.DataEntregue) : null;
                ordemServico.DataFeito = ordemServico.DataFeito != null && ordemServico.DataFeito.Value > DateTime.MinValue && ordemServico.DataFeito.Value > new DateTime(2000, 01, 01) ? (ordemServico.DataMensalidade != null && ordemServico.DataFeito.Value < DateTime.Now ? ordemServico.DataMensalidade : ordemServico.DataEntregue) : null;
                ordemServico.IdPessoaFisica = ordemServico.PFisica?.IdPFisica;
                ordemServico.IdPessoaJuridica = ordemServico.PJuridica?.IdPJuridica;

                ordemServico.IdAtendente = ordemServico.Atendente.CodAtendente;
                await RequisicaoMediador.RealizaRequisicaoPost("https://localhost:7095/OrdemServico", ordemServico, bearerToken);
                indice++;
            }

            lblStatusAtualizacao.Text = "Finalizado!";

            //GetGoogleMapsEndereco("215 South Avenue, #1", "Whitman", "MA", "02382");

            //var atendentes = GetAtendentes();
            //var pfisicasVelho = GetPFisicas();
            //var pjuridicas = GetPJuridicas();

            //var ordens = GetOrdemServico();
            //var historicosConsagracoes = GetHistoricoConsagracao();
            //var historicoCursos = GetHistoricoCursos();

            //dynamic modelo = new { /*Atendentes = atendentes,PFisicas = pfisicas, PJuridicas = pjuridicas,*/ Ordens = ordens/*, HistoricoConsagracao = historicosConsagracoes, HistoricoCursos = historicoCursos*/ };

            //GuardarDadosAsync(modelo);


            //var pfisicasNovo = PegaPFisica().Where(x => x.SituacaoCadastral.EFiliado).ToList();//AtualizaPFisica(PegaPFisica(), PegaPJuridica());

            //foreach(var pfisica in pfisicasNovo)
            //{
            //    pfisica.Filiacao = pfisicasVelho.Where(x => x.IdPFisica == pfisica.IdPFisica).Select(c => c.Filiacao).First();
            //}

            //EnviaPFisicaAsync(pfisicasNovo);
            //dynamic modelo = new { PFisicas = pfisicasNovo };

            //AlterarDadosAsync(modelo);
        }

        private List<PFisica> AtualizaPFisica(List<PFisica> pfisicas, List<PJuridica> pjuridicas)
        {
            foreach (var pjuridica in pjuridicas)
            {
                pfisicas.Where(x => x.IdPFisica == pjuridica.PFisicaPresidente.IdPFisica).Select(x => x).First().IdPJuridica = pjuridica;
            }

            return pfisicas;
        }

        private async Task EnviaPFisicaAsync(List<PFisica> pfisicas)
        {
            //System.Threading.Tasks.Task.Run(() => RequisicaoMediador.RealizaRequisicaoPostEPutAsync(pfisicas, "PFisicas", TipoRequisicaoEnum.Alterar));
            await RequisicaoMediador.RealizaRequisicaoPostEPutAsync(pfisicas, "PFisicas", TipoRequisicaoEnum.Alterar);
        }

        private List<PFisica> PegaPFisica()
        {
            JsonParaClasse jsonParaClasse = new JsonParaClasse();
            var jsonPFisicas = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/PFisica"));
            return ((List<PFisica>)jsonParaClasse.GetPFisicas(jsonPFisicas));
        }

        private List<PJuridica> PegaPJuridica()
        {
            JsonParaClasse jsonParaClasse = new JsonParaClasse();
            var jsonPJuridicas = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/PJuridica"));
            return ((List<PJuridica>)jsonParaClasse.GetPJuridicas(jsonPJuridicas));
        }
    }
}