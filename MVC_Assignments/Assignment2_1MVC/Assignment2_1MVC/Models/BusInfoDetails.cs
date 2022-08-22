using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Assignment2_1MVC.Models
{
    public class BusInfoDetails
    {
        public List<BusInfo> businfosbyamount()
        {
            List<BusInfo> buslist = new List<BusInfo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["businfoContext"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select BoardingPoint, TravelDate from BusInfo where Amount> 450", con);
             
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    buslist.Add(
                        new BusInfo
                        {
                            
                            BoardingPoint = Convert.ToString(dr["BoardingPoint"]),
                            TravelDate = Convert.ToDateTime(dr["TravelDate"])
                        });

                }
                return buslist;
            }
        }


        public List<BusInfo> businfosbydate()
        {
            List<BusInfo> buslist = new List<BusInfo>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["businfoContext"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select BusID, BoardingPoint  from BusInfo where TravelDate = '2017-12-10'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    buslist.Add(
                        new BusInfo
                        {
                            BusID = Convert.ToInt32(dr["BusId"]),
                            BoardingPoint = Convert.ToString(dr["BoardingPoint"]),
                            

                        });

                }
                return buslist;
            }
        }
    }
}