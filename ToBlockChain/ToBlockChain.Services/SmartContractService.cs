using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using ToBlockChain.Entities.BlockChain;

namespace ToBlockChain.Services
{
    public class SmartContractService
    {
        string account = "0x2f1bbc2fa5fce5843904aa52bd21b82d1d469c6f";
        private readonly Web3 web3;
        private string abi = System.IO.File.ReadAllText(@"Content\abi.txt");
        private Contract contract;
        public SmartContractService(Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }

        public async Task<string> RegisterUser(User user)
        {
            var function = contract.GetFunction("Register");

            web3.Personal.UnlockAccount.SendRequestAsync(account, "Power2Share123456", 400).Wait();
            var result = await function.SendTransactionAsync(account, user.PostCode, user.HouseNumber, user.Email, user.MobileNumber, user.Password);

            return result;
        }
    }
}
