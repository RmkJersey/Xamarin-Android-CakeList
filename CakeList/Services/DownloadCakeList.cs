using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CakeList.Interfaces;
using CakeList.Models;

namespace CakeList.Services
{
    /// <summary>
    /// Cake list download class
    /// </summary>
    public class DownloadCakeList : IDownloadCakeList
    {
        /// <returns><c>Task WaracleCakeList</c></returns>
        public async Task<List<WaracleCake>> GetCakeList()
        {
            return null;
        }
    }
}
