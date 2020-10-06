using CakeList.Interfaces;
using Xamarin.Essentials;

namespace CakeList.Services
{
    /// <summary>
    /// Network helper class
    /// </summary>
    public class NetworkHelper : INetworkHelper
    {
        /// <param name="networkMessage"></param>
        /// <returns><c>networkMessage</c></returns>
        /// <returns><c>true</c> if the network <c>NetworkAccess</c> is equal to <c>NetworkAccess.Internet</c>; otherwise, <c>false></c></returns>
        public bool CheckNetworkStatus(out string networkMessage)
        {
            return new NetworkStatusMessage().Get(Connectivity.NetworkAccess, out networkMessage);
        }
    }
}