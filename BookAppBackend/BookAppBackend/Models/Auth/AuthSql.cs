using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookAppBackend.Models.Auth
{
    public class AuthSql : IAuth
    {

        private string connectionString;


        public AuthSql()
        {
            this.connectionString= ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        }


        public Response Login(Login credentials)
        {
            SqlDataReader dr;
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;

                comm.CommandText = "SELECT * FROM Users WHERE (Email= '" + credentials.Email + "' AND Password='" + credentials.Password + "') ";
                conn.Open();
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                    return new Response { Status = true, Success = "Logged In Succesfully" };

            }
           
            
                return new Response { Status = false, Success = "Invalid username and password" };
        }


        public Response Register(Register userDetails)
        {
            int Id = 0;

            if((userDetails.Name)==null || (userDetails.Email==null) || (userDetails.Phone.ToString().Length==0) || (userDetails.Password == null))
                return new Response { Status = false, Success = "Some error occured" };
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into Users (Id, Name, Email, Phone, Password ) values (" + Id + ", '" + userDetails.Name + "', '" + userDetails.Email + "' , " + Convert.ToInt32(userDetails.Phone) + " , '" + userDetails.Password + "')";
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                if(rows!=0)
                    return new Response { Status = true, Success = "User Registered Succesfully" };
            }
           


            return new Response { Status = false, Success = "Some error occured" };
        }
    }
}