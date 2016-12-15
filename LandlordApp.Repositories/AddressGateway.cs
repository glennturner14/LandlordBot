using LandlordApp.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.Repositories
{
    public class AddressGateway {

        //public DataSet AddAddress(Address address) {
        //    List<DalParm> parms = new List<DalParm>();
        //    parms.Add(new DalParm("AddressLine1", SqlDbType.VarChar, 100, address.AddressLine1));
        //    parms.Add(new DalParm("AddressLine2", SqlDbType.VarChar, 100, address.AddressLine2));
        //    parms.Add(new DalParm("Town", SqlDbType.VarChar, 100, address.Town));
        //    parms.Add(new DalParm("County", SqlDbType.VarChar, 100, address.County));

        //    MYOB.DAL.DAL dal = GetDal();
        //    return dal.RunSpReturnDs("AddAddress");
        //}

        public List<Address> GetAddresses() {
            MYOB.DAL.DAL dal = GatewayHelper.GetDal();
            List<Address> addresses = new List<Address>();
            DataSet ds = dal.RunSpReturnDs("GetAddresses");
            if (ds.Tables.Count > 0) {
                foreach (DataRow row in ds.Tables[0].Rows) {
                    addresses.Add(new Address {
                        AddressLine1 = row["AddressLine1"].ToString(),
                        AddressLine2 = row["AddressLine1"].ToString(),
                        Town = row["Town"].ToString(),
                        County = row["County"].ToString()
                    });
                }
            }
            return addresses;
        }


    }
}
