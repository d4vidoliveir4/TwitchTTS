using System.Collections.Generic;
using System.IO;
using System.Net;

namespace TwitchTTS.Models
{
    public class Item
    {
        public Item(decimal id, string name)
        {
            Id = id;
            Name = name;
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
    }
    public class TTS
    {
        public TTS(string token = "", string app = "", string canal = "")
        {
            Canal = canal;
            Token = token;
            BotName = app;
        }
        public decimal Rate { get; set; }
        public decimal Pitch { get; set; }
        public string Resgate => "c3e2104a-ae41-4772-b44d-12242942b76a";
        public string BotName { get; set; }
        public string Token { get; set; }
        public string Canal { get; set; }

        public List<Item> ListaDecimal(decimal valorInicial, decimal valorMaximo)
        {
            var retorno = new List<Item>();
            for (var i = valorInicial; i <= valorMaximo; i += 0.1M)
                retorno.Add(new Item(i, i.ToString()));

            return retorno;
        }

        public string ObterToken()
        {
            WebRequest request = WebRequest.Create("https://id.twitch.tv/oauth2/authorize?response_type=code&client_id=1xlpagj0ylfo47l43o0jukcfr6pxc9&redirect_uri=http://davidoliveira.dev&scope=chat%3Aread+chat&3Aedit&state=c3ab8aa609ea11e793ae92361f002671");
            //WebRequest request = WebRequest.Create("https://id.twitch.tv/oauth2/token?client_id=1xlpagj0ylfo47l43o0jukcfr6pxc9&client_secret=oednf99dlvh3xrvgfnv7tgp5yq2koe&grant_type=client_credentials");
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            var retorno = request.GetResponse();
            var dataStream = retorno.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            var token = responseFromServer.Split('"')[3];
            return token;
        }
    }
}
