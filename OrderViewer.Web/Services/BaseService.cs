using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using OrderViewer.Web.Interfaces;
using OrderViewer.Web.Models;
using static OrderViewer.Web.Utils.SD;

namespace OrderViewer.Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto<T>?> SendAsync<T>(RequestDto requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("OrderAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");

                message.RequestUri = new Uri(requestDto.ApiUrl);
                if (requestDto.Data != null)
                { 
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(requestDto.Data),
                        Encoding.UTF8,
                        "application/json");
                }
                HttpResponseMessage? apiResponse = null;
                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);
                switch (apiResponse.StatusCode)
                { 
                    case HttpStatusCode.NotFound:
                        return new()
                        {
                            Message = "Error 404 Not Found",
                            IsSuccess = false,
                        };
                    case HttpStatusCode.InternalServerError:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Internal Server Error"
                        };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var jsonRes = JsonConvert.DeserializeObject<T>(apiContent, new JsonSerializerSettings
                        {
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                            Formatting = Formatting.Indented
                        });
                       
                        return new() { 
                            IsSuccess =  true,
                            Message = "Success",
                            Result = jsonRes
                        };
                }


            }
            catch (Exception ex)
            {
                var dto = new ResponseDto<T>()
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false,
                };
                return dto;
            }
        }
    }
}
