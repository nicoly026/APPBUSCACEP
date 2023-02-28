using APPBUSCACEP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APPBUSCACEP.Service
{
    public class DataService
    {
        public static async Task<Endereco> GetEnderecoByCep(string cep)
        {
            Endereco end;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/endereco/by-cep?cep=" + cep);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return end;
        }

        public static async Task<List<Bairro>> GetBairroByIdCidade(int id_cidade)
        {
            List<Bairro> arr_bairros = new List<Bairro>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/bairro/by-cidade?id_cidade" + id_cidade);


                 if (response.IsSuccessStatusCode)
                 {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_bairros = JsonConvert.DeserializeObject<List<Bairro>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_bairros;
        }

        public static async Task<List<Lougradouro>> GetLougradourosByBairroAndIdCidade(string bairro, int id_cidade)
        {
            List<Lougradouro> arr_lougradouros = new List<Lougradouro>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("htts://cep.metoda.com.br/lougradouro/by-bairro?id_cidade=4874&bairro= Jardim" + id_cidade + "&bairro" + bairro);


                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_lougradouros = JsonConvert.DeserializeObject<List<Lougradouro>>(json);
                }
                else
                    throw new Exception(response.RequestMessage.Content.ToString());
            }
            return arr_lougradouros;
        }
    }

}
