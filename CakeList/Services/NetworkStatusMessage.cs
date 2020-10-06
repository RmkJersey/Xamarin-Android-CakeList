using Xamarin.Essentials;

namespace CakeList.Services
{
    /// <summary>
    /// Network status manager class
    /// </summary>
    public class NetworkStatusMessage
    {
        /// <param name="networkStatus">NetworkAccess</param>
        /// <param name="networkMessage"></param>
        /// <returns><c>networkMessage</c></returns>
        /// <returns><c>true</c> if the network <c>NetworkAccess</c> is equal to <c>NetworkAccess.Internet</c>; otherwise, <c>false></c></returns>
        public bool Get(NetworkAccess networkStatus, out string networkMessage)
        {
            string errorSuffixMessage = @", please check your connection and try again";
            bool networkConnectionStatus;
            switch (networkStatus)
            {
                case NetworkAccess.Internet:
                    networkMessage = "Connected to internet";
                    networkConnectionStatus = true;
                    break;
                case NetworkAccess.Local:
                case NetworkAccess.ConstrainedInternet:
                case NetworkAccess.None:
                case NetworkAccess.Unknown:
                    networkMessage = "No internet available" + errorSuffixMessage;
                    networkConnectionStatus = false;
                    break;
                default:
                    networkMessage = "Internet access is unknown" + errorSuffixMessage;
                    networkConnectionStatus = false;
                    break;
            }

            return networkConnectionStatus;
        }
    }
}
