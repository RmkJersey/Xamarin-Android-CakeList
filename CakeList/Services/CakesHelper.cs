using CakeList.Interfaces;
using CakeList.Models;
using CommonServiceLocator;
using System;
using System.Threading.Tasks;

namespace CakeList.Services
{
    /// <summary>
    /// Cake list helper class
    /// </summary>
    public class CakesHelper
    {
        /// <returns><c>WaracleCakeList</c> which will be have duplicates removed, sorted by title,  first letter of title and description upper cased</returns>
        public static async Task<WaracleCakeList> GetCakeList()
        {
            var waracleCakeList = new WaracleCakeList();
            var networkHelper = ServiceLocator.Current.GetInstance<INetworkHelper>();
            var isNetworkAvailable = networkHelper.CheckNetworkStatus(out var networkMessage);

            try
            {
                if (!isNetworkAvailable)
                {
                    throw new Exception(networkMessage);
                }

                var dl = ServiceLocator.Current.GetInstance<IDownloadCakeList>();

                var cakeList = await dl.GetCakeList();


                if (cakeList == null || cakeList.Count == 0)
                {
                    throw new Exception("Error retrieving cake list, please try again");
                }

                //Create list from REST API response data
                //1) Removes any duplicate entries
                //2) Sorts the list by title
                //3) Uppercase fist letter of title and desc
                waracleCakeList.AddRangeWithSort(cakeList);
            }
            catch (Exception ex)
            {
                //Display appropriate message to user if cake list retrieval failed
                //The error message is stored in the cake list object
                waracleCakeList.ErrorMessage = ex.Message;
            }

            return waracleCakeList;
        }
    }
}