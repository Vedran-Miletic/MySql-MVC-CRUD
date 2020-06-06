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
    public class CrudImplementation
    {
        public List<CrudProp> GetProd()
        {
            List<CrudProp> prodlist = new List<CrudProp>();
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "SELECT * FROM products";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();
            foreach(DataRow dr in dt.Rows)
            {
                prodlist.Add(new CrudProp
                {
                    productCode = Convert.ToString(dr["productCode"]),
                    productName = Convert.ToString(dr["productName"]),
                    productLine = Convert.ToString(dr["productLine"]),
                    productScale = Convert.ToString(dr["productScale"]),
                    productVendor = Convert.ToString(dr["productVendor"]),
                    productDescription = Convert.ToString(dr["productDescription"]),
                    quantityInStock = Convert.ToInt32(dr["quantityInStock"]),
                    buyPrice = Convert.ToDecimal(dr["buyPrice"]),
                    MSRP = Convert.ToDecimal(dr["MSRP"]),

                });
            }
            return prodlist;
        }

        public bool insertprod(CrudProp prodinsert)
        {

            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "INSERT INTO products(productCode,productName,productLine,productScale,productVendor,productDescription,quantityInStock,buyPrice,MSRP) values ('"+ prodinsert.productCode + "','" + prodinsert.productName + "','" + prodinsert.productLine + "','" + prodinsert.productScale + "','" + prodinsert.productVendor + "','" + prodinsert.productDescription + "','" + prodinsert.quantityInStock + "','" + prodinsert.buyPrice + "','" + prodinsert.MSRP + "')";
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

        public bool editprod(CrudProp prodedit)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "update products set productName='" + prodedit.productName + "'," +
                " productLine='" + prodedit.productLine + "', productScale='" + prodedit.productScale + "'," +
                " productVendor='" + prodedit.productVendor + "', productDescription='" + prodedit.productDescription + "'," +
                " quantityInStock = '" + prodedit.quantityInStock + "', buyPrice = '" + prodedit.buyPrice + "'," +
                " MSRP = '" + prodedit.MSRP + "' where productCode='" +prodedit.productCode+"'";
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

        public bool deleteprod(string id)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "DELETE from products where productCode='"+id+"'";
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