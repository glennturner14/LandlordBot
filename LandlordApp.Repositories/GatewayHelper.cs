using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.Repositories {
    public static class GatewayHelper {

        public static MYOB.DAL.DAL GetDal() {
            MYOB.DAL.DAL dal = new MYOB.DAL.DAL(@".\LandlordBot\LandlordBot\SharedAssemblies\Lookup.xml", "0", false, true);
            return dal;
        }
    }
}
