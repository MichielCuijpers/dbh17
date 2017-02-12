using Nethereum.Web3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ToBlockChain.Api.Models;
using ToBlockChain.Entities.BlockChain;
using ToBlockChain.Services;

namespace ToBlockChain.Api.Manager
{
    public class SmartContractManager
    {
        SmartContractService SmartContractService { get; set; }

        public SmartContractManager()
        {
            SmartContractService = GetSmartContractService();
        }

        private SmartContractService GetSmartContractService()
        {
            var web3 = new Web3("http://tbcnewrfo.westeurope.cloudapp.azure.com:8545");
            var service = new SmartContractService(web3, "0xeecf672f7f2fb6522a2859c0f0570b8c252e21a8");
            return service;
        }

        public async Task<string> RegisterUser(RegisterModel model)
        {
            var user = new User
            {
                Email = model.Email,
                HouseNumber = model.HouseNumber,
                MobileNumber = model.MobileNumber,
                Password = model.Password,
                PostCode = model.PostCode
            };

            var response = await SmartContractService.RegisterUser(user);

            return response;
        }

        public async Task<string> SetMandate(MandateModel model)
        {
            var mandate = new Mandate
            {
                Email = model.Email,
                MobileNumber = model.MobileNumber,
                SmartActive = model.SmartMeter.Active,
                SmartStartDate = model.SmartMeter.StartDate,
                SmartEndDate = model.SmartMeter.EndDate,
                ProfileActive = model.SourceProfile.Active,
                ProfileStartDate = model.SourceProfile.StartDate,
                ProfileEndDate = model.SourceProfile.EndDate,
                TrustedPartyActive = model.TrustedParty.Active,
                TrustedPartyStartDate = model.TrustedParty.StartDate,
                TrustedPartyEndDate = model.TrustedParty.EndDate
            };

            var response = await SmartContractService.SetMandate(mandate);

            return response;
        }

        public async Task<MandateModel> GetMandate(MandateAccountModel model)
        {
            //1. Create user object
            var user = new User
            {
                Email = model.Email,
                MobileNumber = model.MobileNumber
            };

            var mandate = new MandateModel
            {
                Email = model.Email,
                MobileNumber = model.MobileNumber
            };

            //2. Get Smart Meter Mandate
            var smartMet = await SmartContractService.GetSmartMandate(user);
            if(!string.IsNullOrEmpty(smartMet))
            {
               var smartMandateType =  JsonConvert.DeserializeObject<MandateType>(smartMet);
                mandate.SmartMeter = smartMandateType;
            }

            //3. Get Source Profile Mandate
            var smartPro = await SmartContractService.GetProfileMandate(user);
            if (!string.IsNullOrEmpty(smartPro))
            {
                var proMandateType = JsonConvert.DeserializeObject<MandateType>(smartPro);
                mandate.SourceProfile = proMandateType;
            }

            //3. Get Trusted Party Mandate
            var trustPar = await SmartContractService.GetTrustedMandate(user);
            if (!string.IsNullOrEmpty(trustPar))
            {
                var trustMandateType = JsonConvert.DeserializeObject<MandateType>(trustPar);
                mandate.SourceProfile = trustMandateType;
            }

            return mandate;
        }

        public async Task<string> Share(ShareModel model)
        {
            var share = new Share
            {
                SenderEmail = model.SenderEmail,
                ReceiverEmail = model.ReceiverEmail,
                Amount = model.Amount
            };

            var response = await SmartContractService.Share(share);

            return response;
        }

        public async Task<string> SetPowerUsageGeneration(GenerationModel model)
        {
            var generation = new Generation
            {
                Email = model.Email,
                DeviceId = "123456789",
                GenerationInKW = Convert.ToInt32(model.ActualConsumedSolarProductionOwn)
            };

            var response = await SmartContractService.SetPowerUsageGeneration(generation);

            return response;
        }
    }
}