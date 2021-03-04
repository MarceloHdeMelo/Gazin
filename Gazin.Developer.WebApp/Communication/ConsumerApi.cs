using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Gazin.Developer.WebApp.Communication
{
    public class ConsumerApi
    {
        private readonly HttpClient _httpClient;

        public ConsumerApi(string clientAddress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(clientAddress),
                MaxResponseContentBufferSize = int.MaxValue
            };
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private HttpContent SerializarConteudo<TDto>(TDto conteudo)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(conteudo));
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpContent;
        }

        public TDto Get<TDto>(string endpoint) where TDto : class
        {
            var httpResponseMessage = _httpClient.GetAsync(endpoint).Result;
            return httpResponseMessage.IsSuccessStatusCode ? JsonConvert.DeserializeObject<TDto>(httpResponseMessage.Content.ReadAsStringAsync().Result) : default(TDto);
        }

        public IEnumerable<TDto> GetAll<TDto>(string endpoint) where TDto : class
        {
            var httpResponseMessage = _httpClient.GetAsync(endpoint).Result;
            return httpResponseMessage.IsSuccessStatusCode ? JsonConvert.DeserializeObject<IEnumerable<TDto>>(httpResponseMessage.Content.ReadAsStringAsync().Result) : default(IEnumerable<TDto>);
        }

        public void Put<TDto>(string endpoint, TDto dados) where TDto : class
        {
            var conteudo = SerializarConteudo(dados);
            var httpResponseMessage = _httpClient.PutAsync(endpoint, conteudo).Result;
            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        public void Post<TDto>(string endpoint, TDto dados) where TDto : class
        {
            var conteudo = SerializarConteudo(dados);
            var httpResponseMessage = _httpClient.PostAsync(endpoint, conteudo).Result;
            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        public void Delete(string endpoint)
        {
            var httpResponseMessage = _httpClient.DeleteAsync(endpoint).Result;
            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }
    }
}
