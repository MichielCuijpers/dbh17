using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using ToBlockChain.Entities.BlockChain;
using Microsoft.Azure;

namespace ToBlockChain.Services
{
    public class SmartContractService
    {
        string contractAccount = CloudConfigurationManager.GetSetting("UserAccount1");
        string contractPassword = CloudConfigurationManager.GetSetting("AccountPassword1");
        string userAccount = CloudConfigurationManager.GetSetting("UserAccount2");
        string userPassword = CloudConfigurationManager.GetSetting("AccountPassword2");
        private readonly Web3 web3;
        //private string abi = CloudConfigurationManager.GetSetting("ABI"); 
        private string abi = @"[{""constant"":false,""inputs"":[],""name"":""kill"",""outputs"":[],""payable"":false,""type"":""function""},{""constant"":true,""inputs"":[{""name"":""_emailId"",""type"":""string""},{""name"":""_mobileNumber"",""type"":""string""}],""name"":""GetSMMandate"",""outputs"":[{""name"":"""",""type"":""bool""},{""name"":"""",""type"":""string""},{""name"":"""",""type"":""string""}],""payable"":false,""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_emailIdSender"",""type"":""string""},{""name"":""_emailIdReceiver"",""type"":""string""},{""name"":""_amount"",""type"":""uint256""}],""name"":""Share"",""outputs"":[],""payable"":false,""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_add1"",""type"":""address""},{""name"":""_add2"",""type"":""address""},{""name"":""_add3"",""type"":""address""},{""name"":""_add4"",""type"":""address""}],""name"":""RegisterAddress"",""outputs"":[],""payable"":false,""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_emailId"",""type"":""string""},{""name"":""_deviceId"",""type"":""string""},{""name"":""_generation"",""type"":""uint256""}],""name"":""SetPowerUsageGen"",""outputs"":[],""payable"":false,""type"":""function""},{""constant"":true,""inputs"":[{""name"":""_emailId"",""type"":""string""}],""name"":""GetAddress"",""outputs"":[{""name"":"""",""type"":""address""}],""payable"":false,""type"":""function""},{""constant"":true,""inputs"":[{""name"":""_emailId"",""type"":""string""},{""name"":""_mobileNumber"",""type"":""string""}],""name"":""GetSPMandate"",""outputs"":[{""name"":"""",""type"":""bool""},{""name"":"""",""type"":""string""},{""name"":"""",""type"":""string""}],""payable"":false,""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_postCode"",""type"":""string""},{""name"":""_houseNumber"",""type"":""string""},{""name"":""_emailId"",""type"":""string""},{""name"":""_mobileNumber"",""type"":""string""},{""name"":""_password"",""type"":""string""},{""name"":""addrId"",""type"":""address""}],""name"":""Register"",""outputs"":[],""payable"":false,""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_emailId"",""type"":""string""},{""name"":""_mobileNumber"",""type"":""string""},{""name"":""_smActive"",""type"":""bool""},{""name"":""_smStartDate"",""type"":""string""},{""name"":""_smEndDate"",""type"":""string""},{""name"":""_spActive"",""type"":""bool""},{""name"":""_spStartDate"",""type"":""string""},{""name"":""_spEndDate"",""type"":""string""},{""name"":""_tpActive"",""type"":""bool""},{""name"":""_tpStartDate"",""type"":""string""},{""name"":""_tpEndDate"",""type"":""string""}],""name"":""SetMandate"",""outputs"":[],""payable"":false,""type"":""function""},{""constant"":true,""inputs"":[{""name"":""_emailId"",""type"":""string""},{""name"":""_password"",""type"":""string""}],""name"":""Login"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""type"":""function""},{""constant"":true,""inputs"":[{""name"":""_emailId"",""type"":""string""}],""name"":""GetPowerUsageGen"",""outputs"":[{""name"":"""",""type"":""string""},{""name"":"""",""type"":""uint256""}],""payable"":false,""type"":""function""},{""constant"":true,""inputs"":[{""name"":""_emailId"",""type"":""string""},{""name"":""_mobileNumber"",""type"":""string""}],""name"":""GetTPMandate"",""outputs"":[{""name"":"""",""type"":""bool""},{""name"":"""",""type"":""string""},{""name"":"""",""type"":""string""}],""payable"":false,""type"":""function""},{""inputs"":[],""payable"":false,""type"":""constructor""}]";
        private Contract contract;
        public SmartContractService(Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }

        public async Task<string> RegisterUser(User user)
        {
            var function = contract.GetFunction("Register");

            web3.Personal.UnlockAccount.SendRequestAsync(contractAccount, contractPassword, 400).Wait();
            var result = await function.SendTransactionAsync(contractAccount, user.PostCode, user.HouseNumber, user.Email, user.MobileNumber, user.Password);

            return result;
        }

        public async Task<string> GetSmartMandate(User user)
        {
            var function = contract.GetFunction("GetSMMandate");

            web3.Personal.UnlockAccount.SendRequestAsync(contractAccount, contractPassword, 400).Wait();
            var result = await function.SendTransactionAsync(contractAccount, user.Email, user.MobileNumber);

            return result;
        }

        public async Task<string> GetProfileMandate(User user)
        {
            var function = contract.GetFunction("GetSPMandate");

            web3.Personal.UnlockAccount.SendRequestAsync(contractAccount, contractPassword, 400).Wait();
            var result = await function.SendTransactionAsync(contractAccount, user.Email, user.MobileNumber);

            return result;
        }

        public async Task<string> GetTrustedMandate(User user)
        {
            var function = contract.GetFunction("GetTPMandate");

            web3.Personal.UnlockAccount.SendRequestAsync(contractAccount, contractPassword, 400).Wait();
            var result = await function.SendTransactionAsync(contractAccount, user.Email, user.MobileNumber);

            return result;
        }

        public async Task<string> SetMandate(Mandate mandate)
        {
            var function = contract.GetFunction("SetMandate");

            web3.Personal.UnlockAccount.SendRequestAsync(contractAccount, contractPassword, 400).Wait();
            var result = await function.SendTransactionAsync(contractAccount, mandate.Email, mandate.MobileNumber,
                                mandate.SmartActive, mandate.SmartStartDate, mandate.SmartEndDate, mandate.ProfileActive,
                                mandate.ProfileStartDate, mandate.ProfileEndDate, mandate.TrustedPartyActive, mandate.TrustedPartyStartDate, mandate.TrustedPartyEndDate);

            return result;
        }

        public async Task<string> Share(Share share)
        {
            var function = contract.GetFunction("Share");

            web3.Personal.UnlockAccount.SendRequestAsync(contractAccount, contractPassword, 400).Wait();
            var result = await function.SendTransactionAsync(contractAccount, share.SenderEmail, share.ReceiverEmail, share.Amount);

            return result;
        }

        public async Task<string> SetPowerUsageGeneration(Generation generation)
        {
            var function = contract.GetFunction("SetPowerUsageGen");

            web3.Personal.UnlockAccount.SendRequestAsync(contractAccount, contractPassword, 400).Wait();
            var result = await function.SendTransactionAsync(contractAccount, generation.Email, generation.DeviceId, generation.GenerationInKW);

            return result;
        }
    }
}
