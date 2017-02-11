using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToBlockChain.Api.Models;

namespace ToBlockChain.Api.Manager
{
    public class MandateManager
    {
        #region Constructor

        public MandateManager()
        {

        }

        #endregion

        public MandateModel GetMandate(MandateAccountModel model)
        {
            //TODO : Connect with db to retrieve data

            var mandateModel = new MandateModel
            {
                Email = model.Email,
                MobileNumber = model.MobileNumber,
                SmartMeter = new MandateType
                {
                    Active = true,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1)
                },
                SourceProfile = new MandateType
                {
                    Active = true,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1)
                },
                TrustedParty = new MandateType
                {
                    Active = true,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1)
                }
            };

            return mandateModel;
        }
    }
}