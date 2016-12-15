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
            statementLine.Amount = drStatementLine["Amount"].ToString();

            return statementLine;
        }
    }
}
