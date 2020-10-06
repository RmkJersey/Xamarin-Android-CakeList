using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CakeList.Interfaces;
using CakeList.Models;

namespace CakeList.UnitTest.Services
{
    class FakeDownloadCakeList : IDownloadCakeList
    {
        public enum Mode
        {
            ReturnsNull, ReturnsList

        }

        private readonly Mode _mode;

        public FakeDownloadCakeList(Mode mode)
        {
            _mode = mode;
        }

        public async Task<List<WaracleCake>> GetCakeList()
        {
            if (_mode == Mode.ReturnsNull)
                return null;
            
            //Additional methods can be added here for other tests
            ////Todo
            //// Implement method to test successful list without the dependency on a network connection
            throw new NotImplementedException();
        }
    }
}
