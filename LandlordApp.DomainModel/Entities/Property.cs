using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.DomainModel.Entities
{
    public enum PropertyType
    {
        UKProperty,
        UKFurnishedHolidayLet,
        EEAFurnishedHolidayLet
    }

    public class Property
    {
        public Address Address { get; set; }
        public PropertyType Type { get; set; }
        public Landlord Owner { get; set; }
    }
}
