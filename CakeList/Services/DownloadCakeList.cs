using CakeList.Interfaces;
using CakeList.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CakeList.Services
{
    /// <summary>
    /// Cake list download class
    /// </summary>
    public class DownloadCakeList : IDownloadCakeList
    {
        /// <returns><c>WaracleCake list</c></returns>
        public async Task<List<WaracleCake>> GetCakeList()
        {
            IRestClient client = new RestClient("https://gist.githubusercontent.com/t-reed/739df99e9d96700f17604a3971e701fa/raw/1d4dd9c5a0ec758ff5ae92b7b13fe4d57d34e1dc");

            IRestRequest request = new RestRequest("waracle_cake-android-client", Method.GET)
            {
                OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; }
            };

            var response = await client.ExecuteAsync<List<WaracleCake>>(request);

            if (response.IsSuccessful)
                return response.Data;

            var errorMessage = response.ErrorException.Message;
            if (string.Equals(errorMessage, "Unable to read data from the transport connection: Connection reset by peer.", StringComparison.CurrentCultureIgnoreCase))
            {
                errorMessage = "Please check your network connection and try again!";
            }

            throw new Exception(errorMessage);
        }
    }
}
