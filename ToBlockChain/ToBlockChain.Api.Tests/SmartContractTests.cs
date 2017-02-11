using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToBlockChain.Api.Manager;
using ToBlockChain.Entities.BlockChain;

namespace ToBlockChain.Api.Tests
{
    [TestClass]
    public class SmartContractTests
    {
        [TestMethod]
        public void RegisterUserTest()
        {
            //given
            var manager = new SmartContractManager();
            var user = new User
            {
                Email = "dharmi.tanna@gmail.com",
                Password = "test",
                HouseNumber = "123",
                MobileNumber = "1234567890",
                PostCode = "1234DF"
            };

            //when
            var actual = manager.RegisterUser(user);

            //then
            Assert.IsNotNull(actual);
        }
    }
}
