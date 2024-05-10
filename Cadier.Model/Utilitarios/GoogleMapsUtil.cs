using Cadier.Model.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cadier.Desktop.Utilitarios
{
    public class GoogleMapsUtil
    {
        private dynamic TransformaJson(WebResponse valor)
        {
            var serializer = new JsonSerializer();
            using (var response = new StreamReader(valor.GetResponseStream()))
            {
                using (var jsonTextReader = new JsonTextReader(response))
                {
                    return serializer.Deserialize<dynamic>(jsonTextReader);
                }
            }
        }

        public Endereco GoogleMapsEnderecoCep(string cep)
        {
            try {
                cep = cep != null ? cep.Replace(".", "").Replace(",", "") : null;
                string url = @"https://maps.googleapis.com/maps/api/geocode/json?address=" + cep + "&key=AIzaSyBV7pqfjpBl0_LabFRj6pjsyarFp5OWkBw";//"AIzaSyB-qZXZAikle8f3GzANJTrJ3vm7W1o_7a0";
                url = url.Replace(' ', '+');
                WebRequest request = WebRequest.Create(url);

                using (var response = request.GetResponse())
                {
                    var jsonEndereco = TransformaJson(response);
                    response.Close();
                    var resultados = jsonEndereco["results"];

                    var componentesEndereco = resultados[0]["address_components"];
                    var componentesGeometricos = resultados[0]["geometry"]["location"];
                    var endereco = new Endereco();

                    foreach (var item in componentesEndereco)
                    {
                        string[] tipos = item["types"].ToObject<string[]>();
                        if (tipos.Contains("subpremise"))
                        {
                            endereco.Rua = item["long_name"];
                            continue;
                        }
                        else if (tipos.Contains("street_number"))
                        {
                            endereco.Rua = item["long_name"] + (endereco.Rua == null ? endereco.Rua : ", " + endereco.Rua);
                            continue;
                        }
                        else if (tipos.Contains("route"))
                        {
                            endereco.Rua = item["long_name"] + (endereco.Rua == null ? null : ", " + endereco.Rua);
                            continue;
                        }
                        else if (tipos.Contains("sublocality_level_1"))
                        {
                            endereco.Bairro = item["long_name"];
                            continue;
                        }
                        else if (tipos.Contains("administrative_area_level_2"))
                        {
                            endereco.Cidade = item["long_name"];
                            continue;
                        }
                        else if (tipos.Contains("administrative_area_level_1"))
                        {
                            endereco.Estado = item["short_name"];
                            continue;
                        }
                        else if (tipos.Contains("country"))
                        {
                            endereco.Pais = item["short_name"];
                            continue;
                        }
                        else if (tipos.Contains("postal_code"))
                        {
                            endereco.Cep = item["short_name"];
                            continue;
                        }
                    }

                    if (endereco.Cep == null)
                    {
                        endereco.Cep = cep;
                    }

                    endereco.Latitude = Convert.ToDouble(componentesGeometricos["lat"]);
                    endereco.Longitude = Convert.ToDouble(componentesGeometricos["lng"]);

                    return endereco;
                }
            } catch (Exception)
            {
                return null;
            }
        }

        public Endereco GetGoogleMapsEndereco(string localidade, string bairro, string cidade, string cep)
        {
            try
            {
                if (localidade == null || cidade == null)
                    return null;

                if (cidade.ToLower().Contains("cordeiro"))
                    return new Endereco() { Rua = localidade, Bairro = bairro, Cidade = cidade, Cep = cep, Complemento = null, Estado = "RJ", Pais = "Brasil", Latitude = -22.0526116, Longitude = -42.3819663 };

                if (localidade.Equals("Dr Álvaro Cesar n 93") && bairro.Equals("Vila Romana") && cidade.Equals("Mesquita") && cep.Equals("26.000-000"))
                    return null;

                if ((localidade == "" && bairro == "" && cidade == "" && (cep == "  .   -   " || cep == "00.000-000")) || (localidade.Contains("0") && bairro.Contains("0") && cidade.Contains("0")))
                    return null;
                if (cep.Contains("  .   -   "))
                {
                    cep = "";
                }
                if (localidade.Contains("#"))
                {
                    var posicaoInicial = localidade.IndexOf('#');
                    StringBuilder sb = new StringBuilder(localidade);
                    if (localidade[posicaoInicial].Equals('#'))
                    {
                        sb.Remove(posicaoInicial, 1);
                        sb.Insert(posicaoInicial, '%');
                        sb.Insert(posicaoInicial + 1, '2');
                        sb.Insert(posicaoInicial + 2, '3');
                    }
                    localidade = sb.ToString();
                }
                cep = cep != null ? cep.Replace(".", "") : null;
                string url = @"https://maps.googleapis.com/maps/api/geocode/json?address=" + localidade + " " + bairro + " " + cidade + " " + cep + "&key=AIzaSyCfYOirpmIz5ADYlp1hBal1WlWiDoUvs2A";//"AIzaSyB-qZXZAikle8f3GzANJTrJ3vm7W1o_7a0";
                url = url.Replace(' ', '+');
                WebRequest request = WebRequest.Create(url);

                using (var response = request.GetResponse())
                {
                    var jsonEndereco = TransformaJson(response);
                    response.Close();
                    var resultados = jsonEndereco["results"];

                    var property = typeof(ICollection).GetProperty("Count");
                    int count = (int)property.GetValue(resultados, null);

                    if (count > 0) //((string)Convert.ToString(resultados[1]["status"])).Equals("OK"))
                    {
                        var componentesEndereco = resultados[0]["address_components"];
                        var componentesGeometricos = resultados[0]["geometry"]["location"];
                        var endereco = new Endereco();

                        if (localidade.Contains("Cs") || localidade.Contains("Casa") || localidade.Contains("cs"))
                        {
                            endereco.Complemento = "Casa ";
                            int posicao = localidade.Contains("Cs") || localidade.Contains("cs") ? localidade.Contains("Cs") ? localidade.LastIndexOf('C') + 2 : localidade.LastIndexOf('c') + 2 : localidade.Contains("Casa") || localidade.Contains("casa") ? localidade.Contains("Casa") ? localidade.LastIndexOf('C') + 5 : localidade.LastIndexOf('c') + 5 : 0;

                            if (!(localidade.Contains("Casa") && posicao > localidade.Length))
                            {
                                for (var i = posicao; i < localidade.Length; i++)
                                {
                                    if (Char.IsDigit(localidade[i]))
                                    {
                                        endereco.Complemento += localidade[i];
                                    }
                                    if ((i + 1) >= localidade.Length || !Char.IsDigit(localidade[i + 1]))
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        if (localidade.Contains("fds") || localidade.Contains("Fds") || localidade.Contains("fundos") || localidade.Contains("Fundos"))
                        {
                            endereco.Complemento = endereco.Complemento != null ? endereco.Complemento + " Fundos" : "Fundos";
                        }

                        if (localidade.Contains("S/n") || localidade.Contains("s/n") || localidade.Contains("SN"))
                        {
                            endereco.Complemento = endereco.Complemento != null ? endereco.Complemento + " s/n" : "s/n";
                        }

                        foreach (var item in componentesEndereco)
                        {
                            string[] tipos = item["types"].ToObject<string[]>();
                            if (tipos.Contains("subpremise"))
                            {
                                endereco.Rua = item["long_name"];
                                continue;
                            }
                            else if (tipos.Contains("street_number"))
                            {
                                endereco.Rua = item["long_name"] + (endereco.Rua == null ? endereco.Rua : ", " + endereco.Rua);
                                continue;
                            }
                            else if (tipos.Contains("route"))
                            {
                                endereco.Rua = item["long_name"] + (endereco.Rua == null ? null : ", " + endereco.Rua);
                                continue;
                            }
                            else if (tipos.Contains("sublocality_level_1"))
                            {
                                endereco.Bairro = item["long_name"];
                                continue;
                            }
                            else if (tipos.Contains("administrative_area_level_2"))
                            {
                                endereco.Cidade = item["long_name"];
                                continue;
                            }
                            else if (tipos.Contains("administrative_area_level_1"))
                            {
                                endereco.Estado = item["short_name"];
                                continue;
                            }
                            else if (tipos.Contains("country"))
                            {
                                endereco.Pais = item["short_name"];
                                continue;
                            }
                            else if (tipos.Contains("postal_code"))
                            {
                                endereco.Cep = item["short_name"];
                                continue;
                            }
                        }
                        if (endereco.Bairro == null)
                        {
                            endereco.Bairro = bairro;
                        }
                        if (endereco.Cep == null)
                        {
                            endereco.Cep = cep;
                        }

                        endereco.Latitude = Convert.ToDouble(componentesGeometricos["lat"]);
                        endereco.Longitude = Convert.ToDouble(componentesGeometricos["lng"]);

                        return endereco;
                    }
                    else
                    {
                        localidade = localidade.Contains("cs") ? localidade.Replace("cs", "") : localidade;
                        var endereco = GetGoogleMapsEndereco(localidade, bairro, cidade, cep);
                        endereco.Rua = localidade;
                        return endereco;
                    }
                }
            }
            catch (Exception e) { throw e; }
        }
    }
}