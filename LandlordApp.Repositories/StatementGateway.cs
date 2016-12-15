using LandlordApp.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.Repositories {
    public class StatementGateway {

        public List<StatementLine> GetStatementLines() {

            MYOB.DAL.DAL dal = GatewayHelper.GetDal();

            DataSet dsStatementLines = dal.RunSpReturnDs("GetStatementLines"); //new MYOB.DAL.DalParm()

            if (dsStatementLines.Tables.Count > 0) {
                List<StatementLine> statementLines = new List<StatementLine>();
                //LoadStatementLines
                foreach (DataRow drStatementLine in dsStatementLines.Tables[0].Rows) {
                    //Date, Desc, Amount
                    statementLines.Add(LoadStatementLine(drStatementLine));
                }

                return statementLines;
            }

            dal = null;

            return null;
        }

        private StatementLine LoadStatementLine(DataRow drStatementLine) {
            //Date, Desc, Amount
            StatementLine statementLine = new StatementLine();
            statementLine.Date = Convert.ToDateTime(drStatementLine["Date"]).ToShortDateString();
            statementLine.Description = drStatementLine["Description"].ToString();
            statementLine.Amount = Convert.ToDecimal(drStatementLine["Amount"]); //GetFormattedAmount(drStatementLine["Amount"]);

            return statementLine;
        }

        //private string GetFormattedAmount(decimal Amount) {
        //    decimal decimalAmount;

        //    if (decimal.TryParse(Amount, out decimalAmount))
        //        return decimalAmount.ToString("#,##0.00;(#,##0.00)");
        //    else
        //        return "0";
        //}
    }
}
