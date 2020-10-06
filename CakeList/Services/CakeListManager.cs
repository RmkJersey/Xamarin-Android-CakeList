using CakeList.Models;
using System;
using System.Collections.ObjectModel;

namespace CakeList.Services
{
    /// <summary>
    /// CakeListManager class
    /// </summary>
    public class CakeListManager
    {
        public WaracleCakeList DownlodedCakeList = new WaracleCakeList();
        public string ErrorMessage = string.Empty;
        public bool Loaded;
        public bool Loading;
        private Action _doneFunc;

        public async void DownLoadCakeList(Action done = null)
        {
            // Record call back function
            _doneFunc = done;

            // If we are already loading just return
            if (Loading)
                return;

            // If we have already loaded the data just call the callback function and return
            if (Loaded)
            {
                _doneFunc();
                return;
            }

            // We are loading now
            Loading = true;

            try
            {
                DownlodedCakeList = await CakesHelper.GetCakeList();
                Loaded = true;
                Loading = false;

                // if there is a callback function call it.
                _doneFunc?.Invoke();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        public void Clear(ObservableCollection<WaracleCake> obeservableCakeList)
        {
            DownlodedCakeList.Cakes.Clear();
            obeservableCakeList.Clear();
            Loaded = false;
            Loading = false;
            ErrorMessage = "";
        }
    }
}