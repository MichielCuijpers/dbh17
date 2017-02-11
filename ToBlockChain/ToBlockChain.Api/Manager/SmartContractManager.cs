using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        public T Sync<T>(Task<T> call)
        {
            return Task.Run(() => call).Result;
        }

        public string RegisterUser(User user)
        {
            var response = Sync(SmartContractService.RegisterUser(user));

            return response;
        }

    }
}