using System;
using System.Net.Http;

namespace ConsultaAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            consultarAPI();
        }

        private static void consultarAPI()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://randomuser.me/api"); // endereço que será consultado
            var message = new HttpResponseMessage(); // resposta da consulta
            message = client.GetAsync("/?nat=us&randomapi").GetAwaiter().GetResult();
            string result = message.Content.ReadAsStringAsync().Result; //resultado gerado pela consulta
            // nesse caso, essa consulta retorna informações em json.
            Console.WriteLine(result);
        }
    }
}
