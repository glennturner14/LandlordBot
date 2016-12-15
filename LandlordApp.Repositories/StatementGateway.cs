using LandlordApp.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.Repositories {
    public class StatementGateway {

        public void GetStatement() {

            MYOB.DAL.DAL dal = GatewayHelper.GetDal();

            DataSet dsStatementLines = dal.RunSpReturnDs("GetStatementLines", new MYOB.DAL.DalParm());

            if (dsStatementLines.Tables.Count > 0) {
                List<StatementLine> statementLines = new List<StatementLine>();
                //LoadStatementLines
                foreach (DataRow drStatementLine in dsStatementLines.Tables) {
                    //Date, Desc, Amount
                    statementLines.Add(LoadStatementLine(drStatementLine));
                }
            }

            dal = null;
        }

        private StatementLine LoadStatementLine(DataRow drStatementLine) {
            //Date, Desc, Amount
            StatementLine statementLine = new StatementLine();
            statementLine.Date = drStatementLine["Date"].ToString();
            statementLine.Description = drStatementLine["Description"].ToString();
            statementLine.Amount = GetFormattedAmount(drStatementLine["Amount"].ToString());

            return statementLine;
        }

        private string GetFormattedAmount(string Amount) {
            decimal decimalAmount;

            if (decimal.TryParse(Amount, out decimalAmount))
                return decimalAmount > 0 ? decimalAmount.ToString() : string.Format("{(0)}", decimalAmount * -1);
            else
                return "0";
        }
    }
}
