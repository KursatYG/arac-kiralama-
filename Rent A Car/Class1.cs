using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Rent_A_Car
{
     class Class1
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=RentACar;Integrated Security=True");

        public DataTable GetAllList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From Users", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            dr.Close();
            con.Close();
            return dataTable;
        }

        public void ADD(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Users(UserID,UserName,Password,usertype) VALUES (@UserID,@UserName,@Password,@usertype)", con);
            cmd.Parameters.AddWithValue("@UserID", codes.UserID);
            cmd.Parameters.AddWithValue("@UserName", codes.UserName);
            cmd.Parameters.AddWithValue("@Password", codes.Password);
            cmd.Parameters.AddWithValue("@usertype", codes.usertype);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DELETE(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE from Users WHERE UserID=@UserID", con);
            cmd.Parameters.AddWithValue("@UserID", codes.UserID);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UPDATE(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Users set UserName=@UserName,Password=@Password,usertype=@usertype WHERE UserID=@UserID", con);
            cmd.Parameters.AddWithValue("@UserID", codes.UserID);
            cmd.Parameters.AddWithValue("@UserName", codes.UserName);
            cmd.Parameters.AddWithValue("@Password", codes.Password);
            cmd.Parameters.AddWithValue("@usertype", codes.usertype);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public DataTable GetAllList_Cars()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From Cars", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            dr.Close();
            con.Close();
            return dataTable;
        }

        public void ADD_Cars(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Cars(CarsID,ReqNo,Brand,Model,Available,Price) VALUES (@CarsID,@ReqNo,@Brand,@Model,@Available,@Price)", con);
            cmd.Parameters.AddWithValue("@CarsID", codes.CarsID);
            cmd.Parameters.AddWithValue("@ReqNo", codes.ReqNo);
            cmd.Parameters.AddWithValue("@Brand", codes.Brand);
            cmd.Parameters.AddWithValue("@Model", codes.Model);
            cmd.Parameters.AddWithValue("@Available", codes.Available);
            cmd.Parameters.AddWithValue("@Price", codes.Price);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DELETE_Cars(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE from Cars WHERE CarsID=@CarsID", con);
            cmd.Parameters.AddWithValue("@CarsID", codes.CarsID);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UPDATE_Cars(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Cars set Brand=@Brand,Model=@Model,Available=@Available,Price=@Price WHERE CarsID=@CarsID", con);
            cmd.Parameters.AddWithValue("@CarsID", codes.CarsID);
            cmd.Parameters.AddWithValue("@ReqNo", codes.ReqNo);
            cmd.Parameters.AddWithValue("@Brand", codes.Brand);
            cmd.Parameters.AddWithValue("@Model", codes.Model);
            cmd.Parameters.AddWithValue("@Available", codes.Available);
            cmd.Parameters.AddWithValue("@Price", codes.Price);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable GetAllList_Customer()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From Customers", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            dr.Close();
            con.Close();
            return dataTable;
        }

        public void ADD_Customer(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Customers(CustID,Cust_TC,CustName,CustSurName,Adress,Phone) VALUES (@CustID,@Cust_TC,@CustName,@CustSurName,@Adress,@Phone)", con);
            cmd.Parameters.AddWithValue("@CustID", codes.CustID);
            cmd.Parameters.AddWithValue("@Cust_TC", codes.Cust_TC);
            cmd.Parameters.AddWithValue("@CustName", codes.CustName);
            cmd.Parameters.AddWithValue("@CustSurName", codes.CustSurName);
            cmd.Parameters.AddWithValue("@Adress", codes.Adress);
            cmd.Parameters.AddWithValue("@Phone", codes.Phone);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DELETE_Customer(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE from Customers WHERE CustID=@CustID", con);
            cmd.Parameters.AddWithValue("@CustID", codes.CustID);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UPDATE_Customer(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Customers set Cust_TC=@Cust_TC,CustName=@CustName,CustSurName=@CustSurName,Adress=@Adress,Phone=@Phone WHERE CustID=@CustID", con);
            cmd.Parameters.AddWithValue("@CustID", codes.CustID);
            cmd.Parameters.AddWithValue("@Cust_TC", codes.Cust_TC);
            cmd.Parameters.AddWithValue("@CustName", codes.CustName);
            cmd.Parameters.AddWithValue("@CustSurName", codes.CustSurName);
            cmd.Parameters.AddWithValue("@Adress", codes.Adress);
            cmd.Parameters.AddWithValue("@Phone", codes.Phone);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public DataTable GetAllList_Rental()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From Rent", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            dr.Close();
            con.Close();
            return dataTable;
        }

        public void ADD_Rental(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Rent(RentID,ReqNo,CustName,Rent_Date,Return_Date,Fee) VALUES (@RentID,@ReqNo,@CustName,@Rent_Date,@Return_Date,@Fee)", con);
            cmd.Parameters.AddWithValue("@RentID", codes.RentID);
            cmd.Parameters.AddWithValue("@ReqNo", codes.ReqNo);
            cmd.Parameters.AddWithValue("@CustName", codes.CustName);
            cmd.Parameters.AddWithValue("@Rent_Date", codes.Rent_Date);
            cmd.Parameters.AddWithValue("@Return_Date", codes.Return_Date);
            cmd.Parameters.AddWithValue("@Fee", codes.Fee);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DELETE_Rental(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE from Rent WHERE RentID=@RentID", con);
            cmd.Parameters.AddWithValue("@RentID", codes.RentID);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UPDATE_Rental(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Rent set ReqNo=@ReqNo,CustName=@CustName,Rent_Date=@Rent_Date,Return_Date=@Return_Date,Fee=@Fee WHERE RentID=@RentID", con);
            cmd.Parameters.AddWithValue("@RentID", codes.RentID);
            cmd.Parameters.AddWithValue("@ReqNo", codes.ReqNo);
            cmd.Parameters.AddWithValue("@CustName", codes.CustName);
            cmd.Parameters.AddWithValue("@Rent_Date", codes.Rent_Date);
            cmd.Parameters.AddWithValue("@Return_Date", codes.Return_Date);
            cmd.Parameters.AddWithValue("@Fee", codes.Fee);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable GetAllList_Return()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From [Return]", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            dr.Close();
            con.Close();
            return dataTable;
        }

        public void ADD_Return(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Return](ReturnID,ReqNo,CustName,Return_Date,Delay,Fine) VALUES (@RentID,@ReqNo,@CustName,@Return_Date,@Delay,@Fine)", con);
            cmd.Parameters.AddWithValue("@ReturnID", codes.ReturnID);
            cmd.Parameters.AddWithValue("@ReqNo", codes.ReqNo);
            cmd.Parameters.AddWithValue("@CustName", codes.CustName);
            cmd.Parameters.AddWithValue("@Return_Date", codes.Return_Date);
            cmd.Parameters.AddWithValue("@Delay", codes.Delay);
            cmd.Parameters.AddWithValue("@Fine", codes.Fine);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DELETE_Return(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE from [Return] WHERE ReturnID=@ReturnID", con);
            cmd.Parameters.AddWithValue("@ReturnID", codes.ReturnID);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UPDATE_Return(Codes codes)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [Return] set ReqNo=@ReqNo,CustName=@CustName,Return_Date=@Return_Date,Delay=@Delay,Fine=@Fine, WHERE ReturnID=@ReturnID", con);
            cmd.Parameters.AddWithValue("@ReturnID", codes.ReturnID);
            cmd.Parameters.AddWithValue("@ReqNo", codes.ReqNo);
            cmd.Parameters.AddWithValue("@CustName", codes.CustName);
            cmd.Parameters.AddWithValue("@Return_Date", codes.Return_Date);
            cmd.Parameters.AddWithValue("@Delay", codes.Delay);
            cmd.Parameters.AddWithValue("@Fine", codes.Fine);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
