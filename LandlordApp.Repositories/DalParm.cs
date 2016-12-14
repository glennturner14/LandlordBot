using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.Repositories {

    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Data.SqlClient;
    using System.Web;
    using System.Xml.Serialization;
    using System.IO;

    [Serializable()]
    public class DalParm {

        #region "Declarations"

        public string ParamName;
        public System.Data.SqlDbType ParamType;
        public int Size;
        public object Value;
        public ParameterDirection Direction;

        public string StructuredTypeName;


        #endregion

        #region "Constructors"

        [DebuggerStepThrough()]
        public DalParm(string ParamName, SqlDbType ParamType, int Size, object value) {
            this.ParamName = ParamName;
            this.ParamType = ParamType;
            this.Size = Size;
            this.Value = value;
            this.Direction = ParameterDirection.Input;
        }

        public DalParm(string ParamName, string structuredTypeName, int Size, object value) {
            this.ParamName = ParamName;
            this.ParamType = SqlDbType.Structured;
            this.StructuredTypeName = structuredTypeName;
            this.Size = Size;
            this.Value = value;
            this.Direction = ParameterDirection.Input;
        }

        public DalParm(string ParamName, SqlDbType ParamType, int Size, ParameterDirection Direction, object value) {
            this.ParamName = ParamName;
            this.ParamType = ParamType;
            this.Size = Size;
            this.Value = value;
            this.Direction = Direction;
        }


        public DalParm() {
        }
        #endregion

        #region "Methods"

        public string GetSerialised() {
            string returnString = null;


            try {
                XmlSerializer xml_serializer = new XmlSerializer(typeof(DalParm));
                StringWriter string_writer = new StringWriter();

                xml_serializer.Serialize(string_writer, this);
                returnString = string_writer.ToString();

                string_writer.Close();

            } catch (Exception ex) {
                returnString = "Unable to serialise parameter";
            }

            return returnString;

        }

        #endregion

    }

}
