namespace CakeList.Interfaces
{
    public interface INetworkHelper
    {
        bool CheckNetworkStatus(out string networkMessage);
    }
}