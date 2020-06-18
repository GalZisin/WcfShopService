using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WcfShopeService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ShopService : IShop
    {
        private string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetAllVentors", Method = "POST")]
        public List<Ventor> GetAllVentors()
        {
            List<Ventor> ventorDetails = new List<Ventor>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Ventor";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read() == true)
                    {
                        Ventor vd = new Ventor
                        {
                            VentorNumber = (int)reader["VentorNumber"],
                            Name = reader["Name"].ToString().Trim(),
                            City = reader["City"].ToString().Trim(),
                            Street = reader["Street"].ToString().Trim(),
                            ZipCode = reader["ZipCode"].ToString().Trim(),
                            PhoneNumber = reader["PhoneNumber"].ToString().Trim(),

                        };
                        ventorDetails.Add(vd);
                    }
                }
            }
            return ventorDetails;

        }
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetAllVentorItems", Method = "POST")]
        public List<VentorItems> GetAllVentorItems()
        {
            List<VentorItems> ventorItems = new List<VentorItems>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT v.VentorNumber, v.Name,v.City, v.ZipCode, v.Street, v.PhoneNumber, i.ItemId, i.Description, i.CurrentQuantity, i.Item");
                sb.Append(" FROM Ventor as v INNER JOIN Inventory as i ON v.VentorNumber = i.VentorNumber");
                string query = sb.ToString();
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read() == true)
                    {
                        VentorItems vi = new VentorItems
                        {
                            VentorNumber = (int)reader["VentorNumber"],
                            Name = reader["Name"].ToString().Trim(),
                            City = reader["City"].ToString().Trim(),
                            Street = reader["Street"].ToString().Trim(),
                            ZipCode = reader["ZipCode"].ToString().Trim(),
                            PhoneNumber = reader["PhoneNumber"].ToString().Trim(),

                            Item = reader["Item"].ToString().Trim(),
                            ItemId = (int)reader["ItemId"],
                            Description = reader["Description"].ToString().Trim(),
                            CurrentQuantity = reader["CurrentQuantity"].ToString().Trim(),

                        };
                        ventorItems.Add(vi);
                    }
                }
            }
            return ventorItems;

        }
    }
}
