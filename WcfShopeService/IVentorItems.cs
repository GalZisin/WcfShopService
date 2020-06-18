using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfShopeService
{
    [ServiceContract]
    public interface IVentorItems
    {
        [OperationContract]
        List<VentorItems> GetAllVentorItems();
    }

    [DataContract]
    public class VentorItems
    {
        int ventorNumber;
        string name;
        string city;
        string street;
        string zipCode;
        string phoneNumber;
        int itemId;
        string description;
        string currentQuantity;
        string item;

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
        [DataMember]
        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        [DataMember]
        public string Item
        {
            get { return item; }
            set { item = value; }
        }
        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [DataMember]
        public string CurrentQuantity
        { 
            get { return currentQuantity; }
            set { currentQuantity = value; }
        }
    }
}
