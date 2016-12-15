using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LandlordApp.DomainModel.Entities;
using LandlordApp.Repositories;
using System.Data;
using System.Collections.Generic;

namespace LandlordApp.Tests {
    [TestClass]
    public class ManageAddressTest {
        [TestMethod]
        //public void CreateAddress() {

        //    Address address = new Address();
        //    address.AddressLine1 = "AddressLine1";
        //    address.AddressLine2 = "AddressLine2";
        //    address.Town = "Town";
        //    address.County = "County";
        //    address.PostCode = "Postcode";

        //    ManageAddresses manageAddress = new ManageAddresses();
        //    DataSet ds = manageAddress.AddAddress(address);
        //}

        public void GetAddresses() {
            AddressGateway manageAddress = new AddressGateway();
            List<Address> addresses = manageAddress.GetAddresses();
            Assert.IsTrue(addresses != null);
            Assert.IsTrue(addresses.Count == 0);
        }
    }
}
