using System.Collections.Generic;
using System.Threading.Tasks;
using CakeList.Models;

namespace CakeList.Interfaces
{
    public interface IDownloadCakeList
    {
        Task<List<WaracleCake>> GetCakeList();
    }
}

