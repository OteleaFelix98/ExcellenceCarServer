using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ExcellenceCarServer.Models;

namespace ExcellenceCarServer.Controllers
{
    public class CarController : ApiController
    {
       public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
          
                 string query = @"Select * FROM Cars;";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDb"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        public string Post(Car cr)
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDb"].ConnectionString))
                {
                    connection.Open();
                    string sql = @"
                insert into dbo.Cars 
(
modelName,fueltype,bodytype,priceinterval,offroadrank,maximumspeedinterval,luxuryrank,reliabilityrank,safetyrank,practicalityrank,driverank,interiorrank,forcity,forlong,consumption,
electricconsumption,enginetype,cylindernumber,naot ,seatsnumber,cargo,years,details)
values  (  @param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9,@param10,@param11,@param12,@param13,@param14,@param15,@param16,@param17,@param18,@param19,@param20,@param21,@param22,@param23)
                    ";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {

                        cmd.Parameters.Add("@param1", SqlDbType.VarChar, 1000).Value = cr.modelName;
                        cmd.Parameters.Add("@param2", SqlDbType.VarChar, 1000).Value = cr.fueltype;
                        cmd.Parameters.Add("@param3", SqlDbType.VarChar, 1000).Value = cr.bodytype;
                        cmd.Parameters.Add("@param4", SqlDbType.VarChar, 1000).Value = cr.priceinterval;
                        cmd.Parameters.Add("@param5", SqlDbType.VarChar, 1000).Value = cr.offroadrank;
                        cmd.Parameters.Add("@param6", SqlDbType.VarChar, 1000).Value = cr.maximumspeedinterval;
                        cmd.Parameters.Add("@param7", SqlDbType.VarChar, 1000).Value = cr.luxuryrank;
                        cmd.Parameters.Add("@param8", SqlDbType.VarChar, 1000).Value = cr.reliabilityrank;
                        cmd.Parameters.Add("@param9", SqlDbType.VarChar, 1000).Value = cr.safetyrank;
                        cmd.Parameters.Add("@param10", SqlDbType.VarChar, 1000).Value = cr.practicalityrank;
                        cmd.Parameters.Add("@param11", SqlDbType.VarChar, 1000).Value = cr.driverank;
                        cmd.Parameters.Add("@param12", SqlDbType.VarChar, 1000).Value = cr.interiorrank;
                        cmd.Parameters.Add("@param13", SqlDbType.VarChar, 1000).Value = cr.forcity;
                        cmd.Parameters.Add("@param14", SqlDbType.VarChar, 1000).Value = cr.forlong;
                        cmd.Parameters.Add("@param15", SqlDbType.VarChar, 1000).Value = cr.consumption;
                        cmd.Parameters.Add("@param16", SqlDbType.VarChar, 1000).Value = cr.electricconsumption;
                        cmd.Parameters.Add("@param17", SqlDbType.VarChar, 1000).Value = cr.enginetype;
                        cmd.Parameters.Add("@param18", SqlDbType.VarChar, 1000).Value = cr.cylindernumber;
                        cmd.Parameters.Add("@param19", SqlDbType.VarChar, 1000).Value = cr.naot;
                        cmd.Parameters.Add("@param20", SqlDbType.VarChar, 1000).Value = cr.seatsnumber;
                        cmd.Parameters.Add("@param21", SqlDbType.VarChar, 1000).Value = cr.cargo;
                        cmd.Parameters.Add("@param22", SqlDbType.VarChar, 1000).Value = cr.years;
                        cmd.Parameters.Add("@param23", SqlDbType.VarChar, 1000).Value = cr.details;



                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Added succesfully";

            }
            catch (Exception ex)
            {
                return "Failed to add";
            }
        }








           
          public string Put(Car cr)
             {
                 try
                 {
                     DataTable table = new DataTable();
                     using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDb"].ConnectionString))
                     {
                         connection.Open();

                         string sql = @"

                          update dbo.Cars set
          modelName = @param1
          ,fueltype = @param2
          ,bodytype = @param3
          ,priceinterval = @param4
          ,offroadrank = @param5
          ,maximumspeedinterval = @param6
          ,luxuryrank = @param7
          ,reliabilityrank = @param8
          ,safetyrank = @param9
          ,practicalityrank = @param10
          ,driverank = @param11
          ,interiorrank = @param12
          ,forcity = @param13
          ,forlong = @param14
          ,consumption =@param15
          ,electricconsumption = @param16
          ,enginetype = @param17
          ,cylindernumber = @param18
          ,naot = @param19
          ,seatsnumber = @param20
          ,cargo = @param21
           ,years = @param22
          , details = @param23

          

          
      where id=@param24 

                         ";

                         using (SqlCommand cmd = new SqlCommand(sql, connection))
                         {
                             cmd.Parameters.Add("@param24", SqlDbType.Int).Value = cr.id;
                             cmd.Parameters.Add("@param1", SqlDbType.VarChar, 1000).Value = cr.modelName;
                             cmd.Parameters.Add("@param2", SqlDbType.VarChar, 1000).Value = cr.fueltype;
                             cmd.Parameters.Add("@param3", SqlDbType.VarChar, 1000).Value = cr.bodytype;
                             cmd.Parameters.Add("@param4", SqlDbType.VarChar, 1000).Value = cr.priceinterval;
                             cmd.Parameters.Add("@param5", SqlDbType.VarChar, 1000).Value = cr.offroadrank;
                             cmd.Parameters.Add("@param6", SqlDbType.VarChar, 1000).Value = cr.maximumspeedinterval;
                             cmd.Parameters.Add("@param7", SqlDbType.VarChar, 1000).Value = cr.luxuryrank;
                             cmd.Parameters.Add("@param8", SqlDbType.VarChar, 1000).Value = cr.reliabilityrank;
                             cmd.Parameters.Add("@param9", SqlDbType.VarChar, 1000).Value = cr.safetyrank;
                             cmd.Parameters.Add("@param10", SqlDbType.VarChar, 1000).Value = cr.practicalityrank;
                             cmd.Parameters.Add("@param11", SqlDbType.VarChar, 1000).Value = cr.driverank;
                             cmd.Parameters.Add("@param12", SqlDbType.VarChar, 1000).Value = cr.interiorrank;
                             cmd.Parameters.Add("@param13", SqlDbType.VarChar, 1000).Value = cr.forcity;
                             cmd.Parameters.Add("@param14", SqlDbType.VarChar, 1000).Value = cr.forlong;
                             cmd.Parameters.Add("@param15", SqlDbType.VarChar, 1000).Value = cr.consumption;
                             cmd.Parameters.Add("@param16", SqlDbType.VarChar, 1000).Value = cr.electricconsumption;
                             cmd.Parameters.Add("@param17", SqlDbType.VarChar, 1000).Value = cr.enginetype;
                             cmd.Parameters.Add("@param18", SqlDbType.VarChar, 1000).Value = cr.cylindernumber;
                             cmd.Parameters.Add("@param19", SqlDbType.VarChar, 1000).Value = cr.naot;
                             cmd.Parameters.Add("@param20", SqlDbType.VarChar, 1000).Value = cr.seatsnumber;
                             cmd.Parameters.Add("@param21", SqlDbType.VarChar, 1000).Value = cr.cargo;
                        cmd.Parameters.Add("@param22", SqlDbType.VarChar, 1000).Value = cr.years;
                        cmd.Parameters.Add("@param23", SqlDbType.VarChar, 1000).Value = cr.details;




                        cmd.CommandType = CommandType.Text;
                             cmd.ExecuteNonQuery();
                         }
                     }
                     return "Updated succesfully";


                 }
                 catch (Exception ex)
                 {
                     return "Failed to Update";
                 }
             }


        public string Delete(int id)
 {
     try
     {
         DataTable table = new DataTable();
         string query = @"
         delete from  dbo.Cars where id= " + id;

         using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDb"].ConnectionString))
         using (var cmd = new SqlCommand(query, con))
         using (var da = new SqlDataAdapter(cmd))
         {
             cmd.CommandType = CommandType.Text;
             da.Fill(table);
         }
         return "Deleted succesfully";

     }
     catch (Exception ex)
     {
         return "Failed to delete";
     }
 }
}
}
