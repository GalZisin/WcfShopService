using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfShopService
{
    [ServiceContract]
    public interface IVentor
    {
        [OperationContract]
        List<Ventor> GetAllVentors();
    }
    [DataContract]
    public class Ventor
    {
        int ventorNumber;
        string name;
        string city;
        string street;
        string zipCode;
        string phoneNumber;

        [DataMember]
        public int VentorNumber
        {
            get { return ventorNumber; }
            set { ventorNumber = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        [DataMember]
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        [DataMember]
        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }
        [DataMember]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }

}
