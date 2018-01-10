using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using RestServer.Models;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using MySql.Data.MySqlClient;

namespace RestServer
{
  
    public class CustomerPercistance
    {
      

        public CustomerPercistance()
        {

        }

        public Customer getCustomer(long contactNo) {

            Customer p = new Customer();
            MySqlConnection conn = mysqlDbConnect.GetConnection();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReade = null;
            String sqlString = "SELECT * FROM customer WHERE contactNo = '" + contactNo.ToString()+"'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlReade = cmd.ExecuteReader();

            if (mySqlReade.Read())
            {
                p.contactNo = mySqlReade.GetInt32(0);
                p.firstName = mySqlReade.GetString(1);
                p.lastName = mySqlReade.GetString(2);
                p.email = mySqlReade.GetString(3);
                p.address = mySqlReade.GetString(4);
                p.password = mySqlReade.GetString(5);
                return p;
            }

            else
            {
                return null;
            }

        }


        public ArrayList getCustomer()
        {

            ArrayList CustomerArray = new ArrayList();
            MySqlConnection conn = mysqlDbConnect.GetConnection();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReade = null;
            String sqlString = "SELECT * FROM customer";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlReade = cmd.ExecuteReader();

            while (mySqlReade.Read())
            {
                Customer p = new Customer();
                p.contactNo = mySqlReade.GetInt32(0);
                p.firstName = mySqlReade.GetString(1);
                p.lastName = mySqlReade.GetString(2);
                p.email = mySqlReade.GetString(3);
                p.address = mySqlReade.GetString(4);
                p.password = mySqlReade.GetString(5);
                CustomerArray.Add(p);
            }

            return CustomerArray;
        }


        public bool deleteCustomer(long contactNo)
        {

            Customer p = new Customer();
            MySqlConnection conn = mysqlDbConnect.GetConnection();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReade = null;
            String sqlString = "SELECT * FROM customer WHERE contactNo = '" + contactNo.ToString() + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlReade = cmd.ExecuteReader();

            if (mySqlReade.Read())
            {
                mySqlReade.Close();
                sqlString = "DELETE FROM customer WHERE contactNo = '" + contactNo.ToString() + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return true;

            }

            else
            {
                return false;
            }

        }


        public bool updateCustomer(long contactNo, Customer CustomerToSave)
        {
            MySqlConnection conn = mysqlDbConnect.GetConnection();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReade = null;
            String sqlString = "SELECT * FROM customer WHERE contactNo = '" + contactNo.ToString() + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlReade = cmd.ExecuteReader();

            if (mySqlReade.Read())
            {
                mySqlReade.Close();
                sqlString = "UPDATE customer SET firstName='" + CustomerToSave.firstName + "',lastName='" + CustomerToSave.lastName + "',email='" + CustomerToSave.email + "',address='" + CustomerToSave.address + "',password='" + CustomerToSave.password + "' WHERE contactNo = '" + contactNo.ToString() + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return true;

            }

            else
            {
                return false;
            }

        }

        public bool saveCustomer(Customer CustomerToSave)
        {
            MySqlConnection conn = mysqlDbConnect.GetConnection();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReade = null;
            String sqlString = "SELECT * FROM customer WHERE contactNo = '" + CustomerToSave.contactNo.ToString() + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlReade = cmd.ExecuteReader();

            if (mySqlReade.Read())
            {
                return true;
            }
            else {
                mySqlReade.Close();
                sqlString = "INSERT INTO customer (contactNo,firstName,lastName,email,address,password) VALUES ('" + CustomerToSave.contactNo + "','" + CustomerToSave.firstName + "','" + CustomerToSave.lastName + "','" + CustomerToSave.email + "','" + CustomerToSave.address + "','" + CustomerToSave.password + "')";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return false;

            }
        }


        public bool checkLogin(long contactNo,String password)
        {

            Customer p = new Customer();
            MySqlConnection conn = mysqlDbConnect.GetConnection();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReade = null;
            String sqlString = "SELECT * FROM customer WHERE contactNo = '" + contactNo.ToString() + "' AND password= '" + password + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlReade = cmd.ExecuteReader();

            if (mySqlReade.Read())
            {
                
                return true;

            }

            else
            {
                return false;
            }

        }
    }
}