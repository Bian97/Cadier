using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cadier.Desktop.Utilitarios
{
    //Classe Temporária
    public class LocalizadorMensalidade
    {
        public static DateTime? PegaData(string servico)
        {
            if(servico.Contains("nunca pagou"))
            {
                return null;
            }
            var meses = new Dictionary<string, int>() { { "jan", 1 }, { "fev", 2 }, { "mar", 3 }, { "abr", 4 }, { "mai", 5 }, { "jun", 6 }, { "jul", 7 }, { "ago", 8 }, { "set", 9 }, { "out", 10 }, { "nov", 11 }, { "dez", 12 } };
            if (servico.Contains("ano") || Regex.Matches(servico, @"\w+").Cast<Match>().Where(x => meses.Any(c => x.Value.Contains(c.Key))).Any())
            {
                if (servico.Contains("ano") && !Regex.Matches(servico, @"\w+").Cast<Match>().Where(x => meses.Any(c => x.Value.Contains(c.Key))).Any())
                {
                    var ano = Regex.Matches(servico, @"\d+")
                        .Cast<Match>()
                        .Select(x => Convert.ToInt32(x.Value))
                        .Last();
                    var dia = DateTime.DaysInMonth(ano, 12);
                    return new DateTime(ano, 12, dia);
                }                
                else if (servico.Contains("abonado"))
                {
                    return DateTime.Now;
                }
                else if (servico.Contains("mens"))
                {
                    var numeros = Regex.Matches(servico, @"\d+")
                        .Cast<Match>()
                        .Select(x => Convert.ToInt32(x.Value));
                    var ano = numeros.Where(x => (Convert.ToInt32(x) <= 25 || Convert.ToInt32(x) > 2000) && Convert.ToInt32(x) > 0)
                        .Last();
                    var mes = Regex.Matches(servico, @"\w+").Cast<Match>().Where(x => meses.Any(c => x.Value.Contains(c.Key))).Select(x => meses.Where(c => x.Value.Contains(c.Key)).Select(c => c.Value).First()).Last();//x => x.Value).Last();
                    var dia = DateTime.DaysInMonth(ano, mes);
                    return new DateTime(ano < 1000 ? 2000 + ano : ano, mes, dia);
                }
            }
            return null;
        }
    }
}
