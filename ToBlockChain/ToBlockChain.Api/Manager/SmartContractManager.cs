using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            var web3 = new Web3("https://eth2.augur.net");
            var service = new SmartContractService(web3, "0xbb9bc244d798123fde783fcc1c72d3bb8c189413");
            return service;
        }

        public T Sync<T>(Task<T> call)
        {
            return Task.Run(() => call).Result;
        }

        public void GetProposal()
        {
            var proposals = Sync(SmartContractService.GetNumberOfProposals());
        }

    }
}