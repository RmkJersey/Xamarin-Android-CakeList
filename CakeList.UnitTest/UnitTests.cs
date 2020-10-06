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
        public void Cake_List_Sorted()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void Cake_List_No_Duplicates_Sorted()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void Cake_List_Download_Succeeds_List_Sorted_Duplicates_Removed()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void Cake_List_Download_Failed()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}