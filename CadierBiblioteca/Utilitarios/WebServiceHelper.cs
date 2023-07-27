using CadierBiblioteca.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CadierBiblioteca
{
    public class WebServiceHelper
    {
        private static HttpClient client;

        public WebResponse RequisicaoGet(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                WebResponse response = request.GetResponse();

                return response;
            } catch (WebException ex)
            {
                return ex.Response;
            }
        }

        public WebResponse RequisicaoDelete(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "DELETE";
                WebResponse response = request.GetResponse();

                return response;
            }
            catch (WebException ex)
            {
                return ex.Response;
            }
        }

        public static async Task<string> RequisicaoAsync(string url, Dictionary<string, string> valores)
        {
            try
            {
                using (client = new HttpClient())
                {
                    HttpResponseMessage response;
                    //System.Threading.Thread.Sleep(3000);
                    
                    response = CreateMultipartContent(valores, valores.ContainsKey("nomeArquivo") ? valores["nomeArquivo"] : null, url);
                    
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Erro na requisição. Código: " + response.StatusCode + " " + response.RequestMessage);
                    }                    
                    return await response.Content.ReadAsStringAsync();
                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        private static HttpResponseMessage CreateMultipartContent(Dictionary<string, string> valores, string fileName, string url)
        {
            using (var content = new MultipartFormDataContent())
            {
                Dictionary<string, string> teste = new Dictionary<string, string>();
                foreach (var item in valores)
                {
                    if (item.Value != null && item.Value != "")
                    {
                        teste.Add(item.Key, item.Value);
                        content.Add(new StringContent(item.Value), item.Key);
                    }
                }

                if (valores.ContainsKey("nomeArquivo") && (valores["foto"] != null && valores["foto"] != ""))
                {
                    var bytes = File.ReadAllBytes(valores["foto"]);
                    content.Add(new ByteArrayContent(bytes, 0, bytes.Length), "fotoFiliado", fileName);
                }                
                return client.PostAsync(url, content).Result;
            }
        }
    }
}