using System.Data.SqlClient;
using System.Data;
using System;
using Microsoft.AspNetCore.DataProtection;
using Crud.Models;

namespace Crud.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-PRK8D2BP;Initial Catalog=Curd;User Id=sa; Password=Karthick@27;Integrated Security=True");

        public string EmployeeOpt(Employee emp)
         {
            string msg = string.Empty;
            
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", emp.ID);
                com.Parameters.AddWithValue("@Email", emp.Email);
                com.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
                com.Parameters.AddWithValue("@Designation", emp.Designation);
                com.Parameters.AddWithValue("@type", emp.Type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;  
        }

        //Get Record

        public DataSet EmployeeGet(Employee emp, out string msg)
       {
             msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", emp.ID);
                com.Parameters.AddWithValue("@Email", emp.Email);
                com.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
                com.Parameters.AddWithValue("@Designation", emp.Designation);
                com.Parameters.AddWithValue("@type", emp.Type);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
                
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        
            return ds;
        }


        #region Task
       
        //Get Record

        public DataSet TaskGet(Task tsk, out string msg)
                {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("CreateTask", con);
                //SqlCommand com = new SqlCommand("getTask", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Flag", 1);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }


        public string CreateTask(Task tsk)
        {

            string msg = string.Empty;

            try
            {
                SqlCommand com = new SqlCommand("CreateTask", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Task_ID", tsk.Task_ID);
                com.Parameters.AddWithValue("@Task_Name", tsk.Task_Name);
                com.Parameters.AddWithValue("@Description", tsk.Description);
                com.Parameters.AddWithValue("@Flag", 2);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }



        public string EditTask(Task tsk)
        {
            string msg = string.Empty;

            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("CreateTask", con);
                //SqlCommand com = new SqlCommand("getTask", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Task_ID", tsk.Task_ID);
                com.Parameters.AddWithValue("@Task_Name", tsk.Task_Name);
                com.Parameters.AddWithValue("@Description", tsk.Description);
                com.Parameters.AddWithValue("@Flag", 3);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }


        public string DeleteTask(Task tsk)
        {
            string msg = string.Empty;
          
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("CreateTask", con);
                //SqlCommand com = new SqlCommand("getTask", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Task_ID", tsk.Task_ID);
                com.Parameters.AddWithValue("@Task_Name", tsk.Task_Name);
                com.Parameters.AddWithValue("@Description", tsk.Description);
                com.Parameters.AddWithValue("@Flag", 4);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }

        public DataSet getTaskById(Task tsk , out string msg)
        { 
            
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("CreateTask", con);
                //SqlCommand com = new SqlCommand("getTask", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Task_ID", tsk.Task_ID);
                com.Parameters.AddWithValue("@Task_Name", tsk.Task_Name);
                com.Parameters.AddWithValue("@Description", tsk.Description);
                com.Parameters.AddWithValue("@Flag", 5);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

        #endregion




        #region MyInfo

        public DataSet MyInfoGet(MyTaskInfo mi, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("getMyInfo", con);
                //SqlCommand com = new SqlCommand("getTask", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }


        public string CreateMyInfo(MyInfo mi)
        {

            string msg = string.Empty;

            try
            {
                SqlCommand com = new SqlCommand("CreateMyInfo", con);
                com.CommandType = CommandType.StoredProcedure;
               /* com.Parameters.AddWithValue("@ID", mi.ID);*/
                com.Parameters.AddWithValue("@Task_ID", mi.Task_ID);
                com.Parameters.AddWithValue("@Emp_ID", mi.Emp_ID);
                com.Parameters.AddWithValue("@Emp_Name", mi.Emp_Name);
                com.Parameters.AddWithValue("@Task_Name", mi.Task_Name);
          

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }


        public string DeleteMyInfo(MyInfo mi)
        {
            string msg = string.Empty;

            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("DeleteMyInfo", con);
                //SqlCommand com = new SqlCommand("getTask", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Emp_ID", mi.Emp_ID);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }


        #endregion
    }
}





