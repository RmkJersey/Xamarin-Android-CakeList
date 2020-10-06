using CakeList.Models;
using CakeList.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CakeList.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly CakeListManager _cakeManager = new CakeListManager();
        public ObservableCollection<WaracleCake> CakeList { get; set; } = new ObservableCollection<WaracleCake>();
        public Command RefreshCommand { get; }

        public MainPageViewModel()
        {
            RefreshCakeList();
            RefreshCommand = new Command(RefreshCakeList);
        }

        private async void RefreshCakeList()
        {
            lock (_cakeManager)
            {
                if (IsBusy)
                    return;
                IsBusy = true;
            }

            try
            {
                //Check that we have a valid network connection
                //Without this there is no way to retrieve or refresh the cake list
                await Task.Run(() =>
                {
                    StatusMessageVisible = false;
                    StatusMessage = "";
                    _cakeManager.Clear(CakeList);

                    if (!CheckNetworkStatus(out string statusMessage))
                    {
                        throw new Exception(statusMessage);
                    }
                    _cakeManager.DownLoadCakeList(OnCakeDownload);
                });
            }
            catch (Exception ex)
            {
                StatusMessageVisible = true;
                StatusMessage = ex.Message;
                Debug.WriteLine($"Unable to download cake list: {ex.Message}");
            }
            finally
            {
                lock (_cakeManager)
                {
                    IsBusy = false;
                }
            }
        }

        public bool CheckNetworkStatus(out string message)
        {
            bool isConnected = new NetworkHelper().CheckNetworkStatus(out string statusMessage);
            message = statusMessage;
            return isConnected;
        }

        public void OnCakeDownload()
        {
            foreach (var cake in _cakeManager.DownlodedCakeList.Cakes)
            {
                CakeList.Add(cake);
            }
        }
    }
}