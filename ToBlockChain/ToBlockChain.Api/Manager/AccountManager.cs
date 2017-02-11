using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToBlockChain.Api.Models;

namespace ToBlockChain.Api.Manager
{
    public class AccountManager
    {
        #region Validation Methods
        public bool ValidRegisterModel(RegisterModel model)
        {
            if (model == null) return false;

            if (!string.IsNullOrEmpty(model.PostCode) &&
               !string.IsNullOrEmpty(model.HouseNumber) &&
               !string.IsNullOrEmpty(model.Email) &&
               !string.IsNullOrEmpty(model.MobileNumber) &&
               !string.IsNullOrEmpty(model.Password))
            {
                return true;
            }

            return false;
        }

        public bool ValidLoginModel(LoginModel model)
        {
            if (model == null) return false;

            if (!string.IsNullOrEmpty(model.Email) &&
                !string.IsNullOrEmpty(model.Password))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Helpers
        internal string GenerateUniqueId()
        {
            var preId = RandomDigits(13);
            var postId = RandomDigits(18);
            return $"{preId}x{postId}"; 
        }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        #endregion
    }
}