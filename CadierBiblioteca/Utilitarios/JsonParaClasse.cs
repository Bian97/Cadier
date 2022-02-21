using CadierBiblioteca.Enums;
using CadierBiblioteca.ModelosAtuais;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CadierBiblioteca.Utilitarios
{
    public class JsonParaClasse
    {
        public List<Atendente> GetAtendentes(dynamic objectAtendentes)
        {
            char[] delimitadores = { '-' };
            var atendentes = new List<Atendente>();

            foreach (var item in objectAtendentes)
            {
                //string endereco = item["endereco"];
                var atendente = new Atendente()
                {
                    CodAtendente = item["IdAtendente"],
                    Nome = item["Nome"],
                    //Info = new Infos() { Rg = item["rg"], Cpf = item["cpf"] },
                    //Endereco = new Endereco() { Rua = item["rua"], Bairro = item["bairro"], Cidade = item["cidade"], Estado = item["estado"], Pais = item["pais"], Cep = item["cep"], Latitude = item["latitude"], Longitude = item["longitude"] }
                };
                atendentes.Add(atendente);
            }

            return atendentes;
        }

        public List<HistoricoConsagracao> GetConsagracoes(dynamic objectHistorico)
        {
            var historicos = new List<HistoricoConsagracao>();

            if (objectHistorico is JArray)
            {
                foreach (var item in objectHistorico)
                {
                    historicos.Add(JsonParaConsagracao(item));
                }
            }
            else
            {
                historicos.Add(JsonParaConsagracao(objectHistorico));
            }
            return historicos;
        }

        private HistoricoConsagracao JsonParaConsagracao(dynamic item)
        {
            return new HistoricoConsagracao()
            {
                IdConsagracao = item["IdConsagracao"],
                Cargo = (CargosEnum) Convert.ToInt32(item["Cargo"]),
                Local = item["Local"],
                Data = item["Data"] != null ? Convert.ToDateTime(item["Data"]) : null,
                Igreja = item["Igreja"],
                NomeIndicou = item["NomeIndicou"],
                Obs = item["Obs"],
                PFisica = new PFisica() { IdPFisica = Convert.ToInt32(item["IdPFisica"]) }
            };
        }

        public List<PFisica> GetPFisicas(dynamic objectPFisica)
        {
            var pfisicas = new List<PFisica>();

            if (objectPFisica is JArray)
            {
                foreach (var item in objectPFisica)
                {
                    pfisicas.Add(JsonParaPFisica(item));
                    //pfisicas.Add(JsonParaPFisicaTodos(objectPFisica));
                }
            } else
            {
                pfisicas.Add(JsonParaPFisica(objectPFisica));
            }
            return pfisicas;
        }

        public PFisica JsonParaPFisicaTodos(dynamic item)
        {
            var pfisica = new PFisica()
            {
                IdPFisica = item["IdPFisica"],
                Nome = item["Nome"],
                Cargo = (CargosEnum)Convert.ToInt32(item["Cargo"] != null ? item["Cargo"] : 0),
                SituacaoCadastral = item["situacoes"] != null ? new SituacaoCadastral()
                {
                    EFiliado = item["situacoes"]["EFiliado"]
                } : null,
                Endereco = item["enderecos"] != null ? new Endereco()
                {
                    Cidade = item["enderecos"]["Cidade"]
                } : null,
                IdPJuridica = item["p_fisica_presidente"] == null ? item["infos_temporarias"] != null ? new PJuridica()
                {
                    Nome = item["infos_temporarias"]["NomeIgreja"],
                } : item["IdPJuridica"] != null ? new PJuridica() { IdPJuridica = item["IdPJuridica"] } : null : new PJuridica() { IdPJuridica = item["IdPJuridica"] != null ? item["IdPJuridica"] : item["p_fisica_presidente"]["IdPJuridica"], Nome = item["p_fisica_presidente"]["Nome"] }
            };

            return pfisica;
        }

        private PFisica JsonParaPFisica(dynamic item)
        {
            PJuridica pjuridica = null;

            if (item["p_fisica_presidente"] != null)
            {
                pjuridica = new PJuridica() { IdPJuridica = item["IdPJuridica"] != null ? item["IdPJuridica"] : item["p_fisica_presidente"]["IdPJuridica"], Nome = item["p_fisica_presidente"]["Nome"] };
            } else if(item["p_fisica_presidente"] == null && item["p_juridica"] != null)
            {
                pjuridica = new PJuridica()
                {
                    IdPJuridica = item["p_juridica"]["IdPJuridica"],
                    Nome = item["p_juridica"]["Nome"]
                };
            } else if(item["p_fisica_presidente"] == null && item["p_juridica"] == null && item["infos_temporarias"] != null)
            {
                pjuridica = new PJuridica()
                {
                    Nome = item["infos_temporarias"]["NomeIgreja"],
                    Endereco = new Endereco() { Rua = item["infos_temporarias"]["EnderecoIgreja"] }
                };
            }


            var pfisica = new PFisica()
            {
                IdPFisica = item["IdPFisica"],
                Nome = item["Nome"],
                Profissao = item["Profissao"],
                Email = item["Email"],
                Telefone1 = item["Telefone1"],
                Telefone2 = item["Telefone2"],
                Filiacao = item["Filiacao"],
                DataNascimento = item["DataNascimento"],
                Sexo = item["Sexo"] ?? true,
                Cargo = (CargosEnum)Convert.ToInt32(item["Cargo"] ?? 0),
                Conjuge = item["Conjuge"],
                ApresentouConv = item["ApresentouConv"],
                Foto = item["Foto"],
                Info = item["infos"] != null ? new Infos()
                {
                    Cpf = item["infos"]["Cpf"],
                    Rg = item["infos"]["Rg"]
                } : null,
                SituacaoCadastral = item["situacoes"] != null ? new SituacaoCadastral()
                {
                    DataAtualizado = item["situacoes"]["DataAtualizado"],
                    DataEntrou = item["situacoes"]["DataEntrou"],
                    DataUltimaVisita = item["situacoes"]["DataUltimaVisita"],
                    Obs = item["situacoes"]["Obs"],
                    Condicao = (CondicaoEnum)Convert.ToInt32(item["situacoes"]["Condicao"]),
                    Atendente = new Atendente() { CodAtendente = item["situacoes"]["IdAtendente"] },
                    EFiliado = item["situacoes"]["EFiliado"]
                } : null,
                Endereco = item["enderecos"] != null ? new Endereco()
                {
                    Rua = item["enderecos"]["Rua"],
                    Bairro = item["enderecos"]["Bairro"],
                    Cidade = item["enderecos"]["Cidade"],
                    Estado = item["enderecos"]["Estado"],
                    Pais = item["enderecos"]["Pais"],
                    Latitude = item["enderecos"]["Latitude"],
                    Longitude = item["enderecos"]["Longitude"],
                    Cep = item["enderecos"]["Cep"]
                } : null,
                IdPJuridica = pjuridica
            };            

            return pfisica;
        }

        public List<PJuridica> GetPJuridicas(dynamic objectPJuridica)
        {
            var pjuridicas = new List<PJuridica>();

            if (objectPJuridica is JArray)
            {
                foreach (var item in objectPJuridica)
                {
                    pjuridicas.Add(JsonParaPJuridica(item));
                }
            }
            else
            {
                pjuridicas.Add(JsonParaPJuridica(objectPJuridica));
            }
            return pjuridicas;
        }

        private PJuridica JsonParaPJuridica(dynamic item)
        {
            var pjuridica = new PJuridica()
            {
                IdPJuridica = item["IdPJuridica"],
                Nome = item["Nome"],
                DataFundacao = item["DataFundacao"],
                Email = item["Email"],
                Info = item["infos"] != null ? new Infos()
                {
                    Cnpj = item["infos"]["Cnpj"]
                } : null,
                SituacaoCadastral = item["situacoes"] != null ? new SituacaoCadastral()
                {
                    DataAtualizado = item["situacoes"]["DataAtualizado"],
                    DataEntrou = item["situacoes"]["DataEntrou"],
                    DataUltimaVisita = item["situacoes"]["DataUltimaVisita"],
                    Obs = item["situacoes"]["Obs"],
                    Condicao = (CondicaoEnum)Convert.ToInt32(item["situacoes"]["Condicao"]),
                    Atendente = new Atendente() { CodAtendente = item["situacoes"]["IdAtendente"] },
                    EFiliado = item["situacoes"]["EFiliado"]
                } : null,
                Endereco = item["enderecos"] != null ? new Endereco()
                {
                    Rua = item["enderecos"]["Rua"],
                    Bairro = item["enderecos"]["Bairro"],
                    Cidade = item["enderecos"]["Cidade"],
                    Estado = item["enderecos"]["Estado"],
                    Pais = item["enderecos"]["Pais"],
                    Latitude = item["enderecos"]["Latitude"] != null ? item["enderecos"]["Latitude"] : 0,
                    Longitude = item["enderecos"]["Longitude"] != null ? item["enderecos"]["Longitude"] : 0,
                    Cep = item["enderecos"]["Cep"]
                } : null,
                PFisicaPresidente = item["p_fisica_presidente"] != null ? new PFisica()
                {
                    IdPFisica = item["p_fisica_presidente"]["IdPFisica"],
                    Nome = item["p_fisica_presidente"]["Nome"]
                } :null,
                PFisicaVice = item["p_fisica_vice"] != null ? new PFisica()
                {
                    IdPFisica = item["p_fisica_vice"]["IdPFisica"],
                    Nome = item["p_fisica_vice"]["Nome"]
                } : null
            };

            return pjuridica;
        }

        public List<HistoricoCursos> GetCursos(dynamic objectHistorico)
        {
            var historicos = new List<HistoricoCursos>();

            if (objectHistorico is JArray)
            {
                foreach (var item in objectHistorico)
                {
                    historicos.Add(JsonParaCurso(item));
                }
            }
            else
            {
                historicos.Add(JsonParaCurso(objectHistorico));
            }
            return historicos;
        }

        private HistoricoCursos JsonParaCurso(dynamic item)
        {
            return new HistoricoCursos()
            {
                IdCurso = item["IdCursos"],
                PFisica = new PFisica() { IdPFisica = Convert.ToInt32(item["IdPFisica"]) },
                Curso = item["Curso"],
                RestaPagar = Convert.ToDecimal(item["RestaPagar"]),
                Periodo = item["Periodo"],
                DataUltimPagam = Convert.ToDateTime(item["DataUltimPagam"]),
                DataLevouCert = Convert.ToDateTime(item["DataLevouCert"]),
                DataFormatura = Convert.ToDateTime(item["DataFormatura"]),
                Obs = item["Obs"]
            };
        }

        public List<OrdemServico> GetOrdens(dynamic objectOrdem)
        {
            var ordens = new List<OrdemServico>();

            if (objectOrdem is JArray)
            {
                foreach (var item in objectOrdem)
                {
                    ordens.Add(JsonParaOrdem(item));
                }
            }
            else
            {
                ordens.Add(JsonParaOrdem(objectOrdem));
            }
            return ordens;
        }

        private OrdemServico JsonParaOrdem(dynamic item)
        {
            return new OrdemServico() { 
                IdOrdem = Convert.ToInt32(item["IdOrdem"]),
                PFisica = item["IdPFisica"] != null ? new PFisica() { IdPFisica = Convert.ToInt32(item["IdPFisica"]) } : null,
                PJuridica = item["IdPJuridica"] != null ? new PJuridica() { IdPJuridica = Convert.ToInt32(item["IdPJuridica"]) } : null,
                Servico = item["Servico"],
                Valor = Convert.ToDecimal(item["Valor"]),
                Pago = item["Pago"] != "" ? Convert.ToDecimal(item["Pago"]) : 0,
                CreditoAnterior = item["CreditoAnterior"] != "" ? Convert.ToDecimal(item["CreditoAnterior"]) : 0,
                Deposito = item["Deposito"] != "" ? Convert.ToDecimal(item["Deposito"]) : 0,
                Obs = item["Obs"],
                DataPedido = item["DataPedido"] == "1970-01-01" ? null : Convert.ToDateTime(item["DataPedido"]),
                DataFeito = item["DataFeito"] == "1970-01-01" ? null : Convert.ToDateTime(item["DataFeito"]),
                DataEntregue = item["DataEntregue"] == "1970-01-01" ? null : Convert.ToDateTime(item["DataEntregue"]),
                DataMensalidade = item["Mensalidade"] == "1970-01-01" || item["Mensalidade"] == null ? null : Convert.ToDateTime(item["Mensalidade"]),
                QuemLevou = item["QuemLevou"],
                Atendente = new Atendente() { CodAtendente = Convert.ToInt32(item["IdAtendente"]) },
                TipoServico = (TipoServicoEnum)Convert.ToInt32(item["TipoServico"])
            };
        }
    }
}