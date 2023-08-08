using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadier.Utilitaries.Extensoes
{
    public static class ArquivosExtensoes
    {
        public static async Task<string> PegarConteudoAsync(this Type type, string path)
        {
            var fileContent = type.Assembly.GetManifestResourceStream($"{type.Assembly.GetName().Name}.{path}");
            if (fileContent == null) return null;



            using var reader = new StreamReader(fileContent);
            return await reader.ReadToEndAsync();
        }
    }
}
