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
    public class ManageAddresses {

        public DataSet AddAddress(Address address) {
            List<DalParm> parms = new List<DalParm>();
            parms.Add(new DalParm("AddressLine1", SqlDbType.VarChar, 100, address.AddressLine1));
            parms.Add(new DalParm("AddressLine2", SqlDbType.VarChar, 100, address.AddressLine2));
            parms.Add(new DalParm("Town", SqlDbType.VarChar, 100, address.Town));
            parms.Add(new DalParm("County", SqlDbType.VarChar, 100, address.County));

            DAL dal = new DAL();
            return dal.RunSpReturnDs("AddAddress", parms);
        }
    }
}
