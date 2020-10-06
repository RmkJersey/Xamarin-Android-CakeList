using CommonServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Essentials;
using CakeList.Interfaces;
using CakeList.Models;
using CakeList.Services;
using CakeList.UnitTest.Services;


namespace CakeList.UnitTest
{
    [TestClass]
    public class UnitTests
    {
        private readonly UnityContainer _unityContainer = new UnityContainer();

        [TestInitialize]
        public void Init()
        {
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(_unityContainer));
        }

        [TestMethod]
        public void Cake_List_Equals_Function()
        {
            //Arrange
            //Fetch unsorted duplicate test list
            var testCakeList = UnsortedDuplicateList();

            //Act
            var testCakeEntry = new WaracleCake("Test Cake 3", "This is a test cake 3", "");

            //Assert
            //Check entry is equal to test object
            Assert.IsTrue(testCakeEntry.Equals(testCakeList.Cakes[0]));

            //Check entry does not equal to test object
            Assert.IsFalse(testCakeEntry.Equals(testCakeList.Cakes[1]));
        }

        [TestMethod]
        public void Cake_List_Sorted()
        {
            //Arrange
            //Fetch unsorted duplicate test list
            var testList = UnsortedDuplicateList();

            //Expected sorted list
            var sortedCakeList = new List<WaracleCake>
            {
                new WaracleCake("Test Cake 1", "This is a test cake 1", ""),
                new WaracleCake("Test Cake 1", "This is a test cake 1", ""),
                new WaracleCake("Test Cake 2", "This is a test cake 2", ""),
                new WaracleCake("Test Cake 3", "This is a test cake 3", ""),
                new WaracleCake("Test Cake 3", "This is a test cake 3", ""),
                new WaracleCake("Test Cake 4", "This is a test cake 4", ""),
                new WaracleCake("Test Cake 4", "This is a test cake 4", ""),
                new WaracleCake("Test Cake 4", "This is a test cake 4", ""),
                new WaracleCake("Test Cake 5", "This is a test cake 5", ""),
            };

            //Act
            testList.Sort();

            //Assert
            Assert.IsTrue(sortedCakeList.SequenceEqual(testList.Cakes), "List is not sorted as expected");
        }

        [TestMethod]
        public void Cake_List_No_Duplicates_Sorted()
        {
            //Arrange
            //Fetch unsorted duplicate test list
            var testCakeList = UnsortedDuplicateList();

            //Expected list, sorted and duplicates removed
            var duplicatesRemovedList = new List<WaracleCake>
            {
                new WaracleCake("Test Cake 1", "This is a test cake 1", ""),
                new WaracleCake("Test Cake 2", "This is a test cake 2", ""),
                new WaracleCake("Test Cake 3", "This is a test cake 3", ""),
                new WaracleCake("Test Cake 4", "This is a test cake 4", ""),
                new WaracleCake("Test Cake 5", "This is a test cake 5", "")
            };

            //Act
            testCakeList.Sort();
            testCakeList.RemoveDuplicateEntries();

            //Assert
            Assert.IsTrue(duplicatesRemovedList.SequenceEqual(testCakeList.Cakes), "List has duplicates which is not expected");
        }

        [TestMethod]
        public void Cake_List_Download_Succeeds_List_Sorted_Duplicates_Removed()
        {
            //Arrange
            _unityContainer.RegisterInstance<INetworkHelper>(new FakeNetworkHelper(NetworkAccess.Internet));
            _unityContainer.RegisterInstance<IDownloadCakeList>(new DownloadCakeList());

            //Act
            var downlodedCakeList = CakesHelper.GetCakeList().Result;

            var cakes = downlodedCakeList.Cakes;

            //Assert
            //Do we have any entries in the cake list
            Assert.IsTrue(downlodedCakeList.Cakes.Count > 0, "List does not contain any entries as expected");

            //Error message should be empty 
            Assert.AreEqual(string.Empty, downlodedCakeList.ErrorMessage, "Connectivity error message should be empty");

            //List sort check
            var expectedList = cakes.OrderBy(x => x.Title).ToList();
            Assert.IsTrue(expectedList.SequenceEqual(cakes), "List is not sorted as expected");
        }

        [TestMethod]
        public void Cake_List_Download_Failed()
        {
            //Arrange
            _unityContainer.RegisterInstance<INetworkHelper>(new FakeNetworkHelper(NetworkAccess.Internet));
            _unityContainer.RegisterInstance<IDownloadCakeList>(new FakeDownloadCakeList(FakeDownloadCakeList.Mode.ReturnsNull));

            //Act
            var downlodedCakeList = CakesHelper.GetCakeList().Result;

            //Assert
            Assert.AreEqual("Error retrieving cake list, please try again", downlodedCakeList.ErrorMessage);
        }

        private static WaracleCakeList UnsortedDuplicateList()
        {
            //Create test cake list which is unsorted and contains duplicates
            var unsortedDuplicateList = new WaracleCakeList();
            unsortedDuplicateList.Cakes.Add(new WaracleCake("Test Cake 3", "This is a test cake 3", ""));
            unsortedDuplicateList.Cakes.Add(new WaracleCake("Test Cake 1", "This is a test cake 1", ""));
            unsortedDuplicateList.Cakes.Add(new WaracleCake("Test Cake 5", "This is a test cake 5", ""));
            unsortedDuplicateList.Cakes.Add(new WaracleCake("Test Cake 4", "This is a test cake 4", ""));
            unsortedDuplicateList.Cakes.Add(new WaracleCake("Test Cake 4", "This is a test cake 4", ""));
            unsortedDuplicateList.Cakes.Add(new WaracleCake("Test Cake 2", "This is a test cake 2", ""));
            unsortedDuplicateList.Cakes.Add(new WaracleCake("Test Cake 1", "This is a test cake 1", ""));
            unsortedDuplicateList.Cakes.Add(new WaracleCake("Test Cake 4", "This is a test cake 4", ""));
            unsortedDuplicateList.Cakes.Add(new WaracleCake("Test Cake 3", "This is a test cake 3", ""));

            return unsortedDuplicateList;
        }
    }
}