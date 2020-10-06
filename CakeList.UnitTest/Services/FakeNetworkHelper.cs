using Xamarin.Essentials;
using CakeList.Interfaces;
using CakeList.Services;

namespace CakeList.UnitTest.Services
{
    public class FakeNetworkHelper : INetworkHelper
    {
        private readonly bool _fakeNetworkConnected;
        private readonly string _fakeNetworkMessage;

        public FakeNetworkHelper(NetworkAccess networkStatus)
        {
            _fakeNetworkConnected = new NetworkStatusMessage().Get(networkStatus, out _fakeNetworkMessage);
        }

        public bool CheckNetworkStatus(out string networkMessage)
        {
            networkMessage = _fakeNetworkMessage;
            return _fakeNetworkConnected;
        }
    }
}
