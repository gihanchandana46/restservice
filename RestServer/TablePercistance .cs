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
  
    public class TablePercistance
    {
      

        public TablePercistance()
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


        public ArrayList freeTable()
        {

          
            ArrayList TableArray = new ArrayList();
            MySqlConnection conn = mysqlDbConnect.GetConnection();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReade = null;
            String sqlString = "SELECT tableNo FROM tabledetails WHERE status = '0'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlReade = cmd.ExecuteReader();

            while (mySqlReade.Read())
            {
                TableSts p = new TableSts();
                p.tableNo = mySqlReade.GetInt32(0);
               
                TableArray.Add(p);
            }

            return TableArray;
        }
    }
}