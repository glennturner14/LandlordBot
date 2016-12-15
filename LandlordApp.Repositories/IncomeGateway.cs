using LandlordApp.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.Repositories {
    public class IncomeGateway {

        public void CreateIncome(Income income) {

            MYOB.DAL.DAL dal = GatewayHelper.GetDal();

            dal.RunSp("CreateIncome",
                new MYOB.DAL.DalParm("PropertyId", System.Data.SqlDbType.Int, 0, income.Property.PropertyId),
                new MYOB.DAL.DalParm("StartDate", System.Data.SqlDbType.DateTime, 0, income.StartDate.ToString("s")),
                new MYOB.DAL.DalParm("FrequencyId", System.Data.SqlDbType.Int, 0, (int)income.RentFrequency),
                new MYOB.DAL.DalParm("Amount", System.Data.SqlDbType.Money, 0, income.RentAmount)
            );

            dal = null;
        }
    }
}
