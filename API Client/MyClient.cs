using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Client
{
    public class MyClient : IDisposable
    {
        private static string _connectionString = "https://gorest.co.in/";
        private static string _apiKey = "a9abdb97d74688ffb0256f87789b2362162c59934a01ea313add99312aab5c4f";
        private string _objPath;
        private RestClient _client;
        private static MyClient _myClient;
        public int currentPage;
        public int totalPages;

        private MyClient()
        {

        }

        public static MyClient GetInstance()
        {
            if (_myClient == null)
            {
                _myClient = new MyClient();
                _myClient._client = new RestClient(_connectionString);
                _myClient._client.Authenticator = new JwtAuthenticator(_apiKey);
            }

            return _myClient;
        }

        public async Task<List<DTO.Error>?> PostObjAsync<T>(T data)
        {
            var _request = new RestRequest(_objPath);

            if (data is not null)
            {
                _request.AddBody(data);
                _request.Method = Method.Post;
            }

            RestResponse restResponse = await _myClient._client.ExecuteAsync(_request);

            if (restResponse.Content != null && restResponse.IsSuccessful != true)
            {
                return JsonSerializer.Deserialize<List<DTO.Error>>(restResponse.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                return null;
            }
        }

        public async Task<List<DTO.Error>?> PatchObjAsync<T>(T data, int objectId)
        {
            var _request = new RestRequest(_objPath + $"/{objectId}");

            if (data is not null)
            {
                _request.AddBody(data);
                _request.Method = Method.Patch;
            }

            RestResponse restResponse = await _myClient._client.ExecuteAsync(_request);

            if (restResponse.Content != null && restResponse.IsSuccessful != true)
            {
                return JsonSerializer.Deserialize<List<DTO.Error>>(restResponse.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                return null;
            }
        }

        public async Task<List<DTO.Error>?> DeleteObjAsync<T>(int objectId)
        {
            var _request = new RestRequest(_objPath + $"/{objectId}");

            if (objectId > 0)
            {
                _request.Method = Method.Delete;
            }

            RestResponse restResponse = await _myClient._client.ExecuteAsync(_request);

            if (restResponse.Content != null && restResponse.IsSuccessful != true)
            {
                return JsonSerializer.Deserialize<List<DTO.Error>>(restResponse.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                return null;
            }
        }

        public async Task<T> GetObjAsync<T>(int objectId)
        {
            var request = new RestRequest(_objPath + $"/{objectId}");
            RestResponse restResponse = await _myClient._client.ExecuteAsync(request);
            if (restResponse.Content != null)
            {
                return JsonSerializer.Deserialize<T>(restResponse.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                return default(T?);
            }
        }

        public async Task<List<T>?> GetListObjAsync<T>(int page)
        {
            if (typeof(T).Name == "User")
            {
                _objPath = "public/v2/users";
            }
            else if(typeof(T).Name == "Post")
            {
                _objPath = "public/v2/posts";
            }
            var request = new RestRequest(_objPath + "?page=" + page);
            RestResponse restResponse = await _myClient._client.ExecuteAsync(request);
            if (restResponse.Content != null && restResponse.Headers != null)
            {
                totalPages = Convert.ToInt32(restResponse.Headers.Where(x => x.Name == "x-pagination-pages").First().Value);
                currentPage = Convert.ToInt32(restResponse.Headers.Where(x => x.Name == "x-pagination-page").First().Value);
                return JsonSerializer.Deserialize<List<T>>(restResponse.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                return null;
            }
        }

        public void Dispose()
        {
        }
    }
}
