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
  
    public class FoodAndDrinkPercistance
    {
      

        public FoodAndDrinkPercistance()
        {

        }

            

        public bool saveTable(Table TableToSave)
        {
            MySqlConnection conn = mysqlDbConnect.GetConnection();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReade = null;
            String sqlString = "SELECT * FROM reservation WHERE resrvId = '" + TableToSave.resrvId.ToString() + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlReade = cmd.ExecuteReader();

            if (mySqlReade.Read())
            {
                return true;
            }
            else {
                mySqlReade.Close();
                sqlString = "INSERT INTO reservation (contactNo,tableNo,pcount,rdate,stime,etime) VALUES ('" + TableToSave.contactNo + "','" + TableToSave.tableNo + "','" + TableToSave.pcount + "','" + TableToSave.rdate + "','" + TableToSave.stime + "','" + TableToSave.etime + "')";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return false;

            }
        }


        public ArrayList loadFood()
        {

          
            ArrayList FoodArray = new ArrayList();
            MySqlConnection conn = mysqlDbConnect.GetConnection();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReade = null;
            String sqlString = "SELECT * FROM food ";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlReade = cmd.ExecuteReader();

            while (mySqlReade.Read())
            {
                Food p = new Food();
                p.foodId = mySqlReade.GetInt32(0);

                FoodArray.Add(p);
            }

            return FoodArray;
        }


        public ArrayList loadDrink()
        {


            ArrayList DrinkArray = new ArrayList();
            MySqlConnection conn = mysqlDbConnect.GetConnection();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReade = null;
            String sqlString = "SELECT * FROM drink";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlReade = cmd.ExecuteReader();

            while (mySqlReade.Read())
            {
                Drink p = new Drink();
                p.drinkId = mySqlReade.GetInt32(0);

                DrinkArray.Add(p);
            }

            return DrinkArray;
        }

        public Drink loadDrinkDetails(int drinkId)
        {
            Drink p = new Drink();
            MySqlConnection conn = mysqlDbConnect.GetConnection();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReade = null;
            String sqlString = "SELECT * FROM drink WHERE drinkId='"+drinkId+"'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlReade = cmd.ExecuteReader();

            if (mySqlReade.Read())
            {
                p.drinkId = mySqlReade.GetInt32(0);
                p.drinkName = mySqlReade.GetString(1);
                p.drinkPrice = mySqlReade.GetInt32(2);
                
                return p;
            }

            else
            {
                return null;
            }

        }


        public Food loadFoodDetails(int foodId)
        {
            Food p = new Food();
            MySqlConnection conn = mysqlDbConnect.GetConnection();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReade = null;
            String sqlString = "SELECT * FROM food WHERE foodId='" + foodId + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlReade = cmd.ExecuteReader();

            if (mySqlReade.Read())
            {
                p.foodId = mySqlReade.GetInt32(0);
                p.foodName = mySqlReade.GetString(1);
                p.foodPrice = mySqlReade.GetInt32(2);

                return p;
            }

            else
            {
                return null;
            }

        }
    }
}