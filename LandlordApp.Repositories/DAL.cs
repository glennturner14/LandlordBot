using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.Repositories {
    public class DAL {

        private string _connectionString = "Server=tcp:zteybqk82l.database.windows.net,1433;Initial Catalog=LandlordBot;Persist Security Info=False;User ID=vpmser;Password=BelfrY18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private SqlConnection GetConnection() {

            return new SqlConnection(_connectionString);
        }

        private SqlCommand CreateCommand(string spName) {
            SqlCommand CreateCommand = new SqlCommand(spName, GetConnection());
            CreateCommand.CommandTimeout = 600;
            CreateCommand.CommandType = CommandType.StoredProcedure;
            return CreateCommand;
        }

        internal DataSet RunSpReturnDs(string spName, List<DalParm> dalParms) {

            SqlCommand cmd = CreateCommand(spName);

            SqlDataAdapter daResult = new SqlDataAdapter();
            DataSet dsResult = new DataSet();

            daResult.SelectCommand = cmd;

            //CollectParms(cmd, Param)

            try {
                daResult.Fill(dsResult);
            } catch (Exception) {

            }

            return dsResult;
        }
    }
}
