using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using MVC_RNWA.Models;

namespace MVC_RNWA.Models
{
    public class CrudEmployee
    {

        public List<CrudEmp> GetEmp()
        {
            List<CrudEmp> emplist = new List<CrudEmp>();
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "SELECT * FROM employees";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                emplist.Add(new CrudEmp
                {
                    employeeNumber = Convert.ToInt32(dr["employeeNumber"]),
                    lastName = Convert.ToString(dr["lastName"]),
                    firstName = Convert.ToString(dr["firstName"]),
                    extension = Convert.ToString(dr["extension"]),
                    email = Convert.ToString(dr["email"]),
                    officeCode = Convert.ToString(dr["officeCode"]),
                    reportsTo = Convert.ToInt32(dr["reportsTo"]),
                    jobTitle = Convert.ToString(dr["jobTitle"]),

                });
            }
            return emplist;
        }

        public bool insertemp(CrudEmp empinsert)
        {

            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "INSERT INTO employees(lastName,firstName,extension,email,officeCode,reportsTo,jobTitle) values ('" + empinsert.lastName + "','" + empinsert.firstName + "','" + empinsert.extension + "','" + empinsert.email + "','" + empinsert.officeCode + "','" + empinsert.reportsTo + "','" + empinsert.jobTitle + "')";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            int i = sqlcomm.ExecuteNonQuery();

            mysqlconn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool editemp(CrudEmp empinsert)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "update employees set lastName='" + empinsert.lastName + "'," +
                " firstName='" + empinsert.firstName + "', extension='" + empinsert.extension + "'," +
                " email='" + empinsert.email + "', officeCode='" + empinsert.officeCode + "'," +
                " reportsTo = '" + empinsert.reportsTo + "', jobTitle = '" + empinsert.jobTitle + "' where employeeNumber='" + empinsert.employeeNumber + "'";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            int i = sqlcomm.ExecuteNonQuery();

            mysqlconn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteemp(int id)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "DELETE from employees where employeeNumber='" + id + "'";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            int i = sqlcomm.ExecuteNonQuery();

            mysqlconn.Close();
            if (i >= 1)
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