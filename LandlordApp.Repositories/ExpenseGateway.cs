using LandlordApp.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.Repositories {
    public class ExpenseGateway {
        public void CreateExpense(Expense expense) {

            MYOB.DAL.DAL dal = GatewayHelper.GetDal();

            dal.RunSp("CreateExpense",
                new MYOB.DAL.DalParm("PropertyId", System.Data.SqlDbType.Int, 0, expense.Property.PropertyId),
                new MYOB.DAL.DalParm("Description", System.Data.SqlDbType.VarChar, 0, expense.Description),
                new MYOB.DAL.DalParm("Date", System.Data.SqlDbType.DateTime, 0, expense.Date.ToString("s")),
                new MYOB.DAL.DalParm("Amount", System.Data.SqlDbType.Money, 0, expense.Amount)
            );

            dal = null;
        }
    }
}
