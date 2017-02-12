using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToBlockChain.Api.Manager;
using ToBlockChain.Entities.BlockChain;
using ToBlockChain.Api.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            var user = new RegisterModel
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

        [TestMethod]
        public async Task SetMandateTest()
        {
            //given
            var manager = new SmartContractManager();
            var mandate = new MandateModel
            {
                Email = "dharmi.tanna@gmail.com",
                MobileNumber = "1234567890",
                SmartMeter = new MandateType
                {
                    Active = true,
                    StartDate = "2016-12-12",
                    EndDate = "2017-12-12"
                },
                SourceProfile = new MandateType
                {
                    Active = true,
                    StartDate = "2016-12-12",
                    EndDate = "2017-12-12"
                },
                TrustedParty = new MandateType
                {
                    Active = true,
                    StartDate = "2016-12-12",
                    EndDate = "2017-12-12"
                }
            };

            //when
            var actual = await manager.SetMandate(mandate);

            //then
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public async Task SetPowerUsageGenTest()
        {
            //given
            var manager = new SmartContractManager();
            var generation = new GenerationModel
            {
                Email = "dharmi.tanna@gmail.com",
                ActualBackdeliverSolarProductionOwn = new List<int> { 1000, 200, 3000 }
            };

            //when
            var actual = await manager.SetPowerUsageGeneration(generation);

            //then
            Assert.IsNotNull(actual);
        }
    }
}
