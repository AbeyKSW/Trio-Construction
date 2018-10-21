using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;

namespace TRIO_Constructions
{
    class DBConnector
    {
        int EqType_ID_START = 1;
        int Site_ID_START = 1;
        int PREFIX_START = 1;
        int Category_ID_START = 1;

        SqlConnection myConnection;

        private static DBConnector _instance;

        public static DBConnector getInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }

            _instance = new DBConnector();
            return _instance;
        }

        private DBConnector()
        {
            myConnection = new SqlConnection("Data Source=ABEY-KSW;Initial Catalog=TRIOConstructionsInventory;User ID=sa;Password=abeyksw");

            myConnection.Open();
        }

        public void Disconnect()
        {
            myConnection.Close();
        }

        /*=================================== Login ===================================*/

        public ArrayList GetUserNameListFromPost(string post)
        {
            string sqlQuery = "select username from dbo.user_details_table where post = '" + post + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            ArrayList userName = new ArrayList();
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    userName.Add(reader.GetString(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return userName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return userName;
            }
        }

        public string GetPasswordFromUsername(string username)
        {
            string sqlQuery = "select password from dbo.user_details_table where username = '" + username + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string passWord = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                passWord = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return passWord;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return passWord;
            }
        }

        /*=================================== User Details ===================================*/

        public bool AddToUserDetailsTable(string username, string password, string fullname, string address, string contactno, string post)
        {
            string sqlCommand = "INSERT into dbo.user_details_table (username, password, fullname, address, contactno, post)" +
            " VALUES('" + username + "','" + password + "','" + fullname + "','" + address + "','" + contactno + "','" + post + "')";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool RemoveFromUserDetailsTable(string username)
        {
            string sqlCommand = "DELETE FROM dbo.user_details_table WHERE username = '" + username + "'";
            SqlCommand deleteCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                deleteCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool IsPasswordExists(string passWord)
        {
            string post = "Admin";
            string sqlQuery = "select password from dbo.user_details_table where password = '" + passWord + "' and post ='" + post + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                queryCommand.Dispose();
                
                if (counter != 0)
                    return true;
                return false;

                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return true;
            }
        }

        public bool IsUserNameExists(string userName)
        {

            string sqlQuery = "select username from dbo.user_details_table where username='" + userName + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                queryCommand.Dispose();

                if (counter != 0)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return true;
            }
        }

        public bool UpdateUserDetailsTable(string username, string newpassword, string oldpassword)
        {
            string sqlCommand = "Update Registration set password = '" + newpassword + "' where username= '" + username + "' and password = '" + oldpassword + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        /*=================================== Add Items ===================================*/

        public string GetPrefixFromEQtype(string eqType)
        {
            string sqlQuery = "select eq_short_name from dbo.asset_type_table where eq_type ='" + eqType + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string pre_fix = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                pre_fix = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return pre_fix;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return pre_fix;
            }
        }

        public int GetAssetIDFromAssetCode(string assetCode)
        {
            string sqlQuery = "select id from dbo.asset_details_table where asset_code = '" + assetCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int id;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                id = reader.GetInt32(0);

                reader.Close();

                queryCommand.Dispose();

                return id;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return id = 0;
            }
        }

        public string GetCategoryFromEqShortName(string eqShortName)
        {
            string sqlQuery = "select category from dbo.asset_categories_table where eq_short_name = '" + eqShortName + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string category;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                category = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return category;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return category = "";
            }
        }

        public string GetCategoryFromAssetCode(string assetCode)
        {
            string sqlQuery = "select category from dbo.asset_details_table where asset_code = '" + assetCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string category;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                category = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return category;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return category = "";
            }
        }

        public ArrayList GetCategoryList(string astshortname)
        {
            ArrayList CategoryList = new ArrayList();

            string sqlQuery = "select category from dbo.asset_categories_table where eq_short_name = '" + astshortname + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    CategoryList.Add(reader.GetString(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return CategoryList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return CategoryList;
            }
        }

        public ArrayList GetAssetNameList()
        {
            ArrayList assetNameList = new ArrayList();

            string sqlQuery = "select asset_name from dbo.asset_details_table";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    assetNameList.Add(reader.GetString(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return assetNameList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetNameList;
            }
        }

        public int GetNextPrefixID(string prefix)
        {

            string sqlQuery = "select id from dbo.asset_details_table where pre_fix = '" + prefix + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                queryCommand.Dispose();

                if (counter != 0)
                    return counter + PREFIX_START;
                return PREFIX_START;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return PREFIX_START;
            }
        }

        public DateTime GetWarrantyFromAssetCode(string astCode)
        {
            string sqlQuery = "select expirydateof_warranty from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            DateTime warranty = System.DateTime.Now;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                warranty = reader.GetDateTime(0);

                reader.Close();

                queryCommand.Dispose();

                return warranty;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return warranty;
            }
        }

        public bool IsAssetCodeExists(string asset_code, string location)
        {
            string sqlQuery = "select asset_code from dbo.site_inventory_table where asset_code ='" + asset_code + "' and site ='" + location + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                queryCommand.Dispose();

                if (counter != 0)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return true;
            }
        }

        public bool AddToAssetDetailsTable(string pre_fix, int id, string category, string asset_name, string asset_code, int quantity, string quality, DateTime launch_date, string supplier, string asset_description, string location, int po_number, string grn_no, string serial_no, string invoice_no, DateTime expirydateof_warranty, string repair_history, string remarks, int cost)
        {
            string sqlCommand = "INSERT into dbo.asset_details_table (pre_fix, id, category, asset_name, asset_code, quantity, quality, launch_date, supplier, asset_description, location, po_number, grn_no, serial_no, invoice_no, expirydateof_warranty, repair_history, remarks, cost)" +
            " VALUES('" + pre_fix + "'," + id + ",'" + category + "','" + asset_name + "','" + asset_code + "'," + quantity + ",'" + quality + "','" + launch_date.ToShortDateString() + "','" + supplier + "','" + asset_description + "','" + location + "'," + po_number + ",'" + grn_no + "','" + serial_no + "','" + invoice_no + "','" + expirydateof_warranty.ToShortDateString() + "','" + repair_history + "','" + remarks + "'," + cost + ");";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public ArrayList GetEquipmentTypeList()
        {
            ArrayList EquipmentTypeList = new ArrayList();

            string sqlQuery = "select eq_type from dbo.asset_type_table";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    EquipmentTypeList.Add(reader.GetString(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return EquipmentTypeList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return EquipmentTypeList;
            }
        }

        public ArrayList GetSupplierList()
        {
            ArrayList SupplierList = new ArrayList();

            string sqlQuery = "select sup_name from dbo.supplier_details_table";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    SupplierList.Add(reader.GetString(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return SupplierList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return SupplierList;
            }
        }

        public ArrayList GetMTNNoListFromMTNStatusTable(string status)
        {
            ArrayList mtnNoList = new ArrayList();

            string sqlQuery = "select mtn_no from dbo.mtn_status_table where dilivery_status = '" + status + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    mtnNoList.Add(reader.GetString(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return mtnNoList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return mtnNoList;
            }
        }

        public ArrayList GetSiteList(int act)
        {
            ArrayList SiteList = new ArrayList();

            string sqlQuery = "select site_name from dbo.site_details_table where active =" + act + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    SiteList.Add(reader.GetString(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return SiteList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return SiteList;
            }
        }

        public int GetMainStoreQuantityFromAssetCode(string astCode)
        {
            string sqlQuery = "select quantity from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int quantity;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                quantity = reader.GetInt32(0);

                reader.Close();

                return quantity;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return quantity = 0;
            }
        }

        public string GetQualityFromAssetCode(string astCode)
        {
            string sqlQuery = "select quality from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string quality;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                quality = reader.GetString(0);

                reader.Close();

                return quality;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return quality = "";
            }
        }

        public DateTime GetLaunchDateFromAssetCode(string astCode)
        {
            string sqlQuery = "select launch_date from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            DateTime date;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                date = reader.GetDateTime(0);

                reader.Close();

                return date;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return date = DateTime.Now;
            }
        }

        public string GetSupplierFromAssetCode(string astCode)
        {
            string sqlQuery = "select supplier from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string str;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                str = reader.GetString(0);

                reader.Close();

                return str;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return str = "";
            }
        }

        public string GetAssetDescriptionFromAssetCode(string astCode)
        {
            string sqlQuery = "select asset_description from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string str;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                str = reader.GetString(0);

                reader.Close();

                return str;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return str = "";
            }
        }

        public int GetPoNumberFromAssetCode(string astCode)
        {
            string sqlQuery = "select po_number from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int str;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                str = reader.GetInt32(0);

                reader.Close();

                return str;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return str = 0;
            }
        }

        public string GetGrnNoFromAssetCode(string astCode)
        {
            string sqlQuery = "select grn_no from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string str;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                str = reader.GetString(0);

                reader.Close();

                return str;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return str = "";
            }
        }

        public string GetSerialNoFromAssetCode(string astCode)
        {
            string sqlQuery = "select serial_no from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string str;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                str = reader.GetString(0);

                reader.Close();

                return str;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return str = "";
            }
        }

        public string GetInvoiceNoFromAssetCode(string astCode)
        {
            string sqlQuery = "select invoice_no from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string str;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                str = reader.GetString(0);

                reader.Close();

                return str;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return str = "";
            }
        }

        public string GetRepairFromAssetCode(string astCode)
        {
            string sqlQuery = "select repair_history from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string str;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                str = reader.GetString(0);

                reader.Close();

                return str;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return str = "";
            }
        }

        public string GetRemarksFromAssetCode(string astCode)
        {
            string sqlQuery = "select remarks from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string str;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                str = reader.GetString(0);

                reader.Close();

                return str;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return str = "";
            }
        }

        public int GetCostFromAssetCode(string astCode)
        {
            string sqlQuery = "select cost from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int str;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                str = reader.GetInt32(0);

                reader.Close();

                return str;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return str = 0;
            }
        }

        /*================================= site_invetory_table =================================*/

        public bool AddToSiteInventoryTable(int transid, int id, string asset_code, string site, int quantity, string dilistat)
        {
            string sqlCommand = "INSERT into dbo.site_inventory_table (transfer_id, id, asset_code, site, quantity, status)" +
            " VALUES(" + transid + "," + id + ",'" + asset_code + "','" + site + "'," + quantity + ",'" + dilistat + "')";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool UpdateSiteInventoryTable(string assetCode, string deliStat)
        {
            string sqlCommand = "Update site_inventory_table set status = '" + deliStat + "' where asset_code ='" + assetCode + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool UpdateSiteInventoryTableFromClaim(int totalQty, string astCode, string defaultlocation)
        {
            string sqlCommand = "Update site_inventory_table set quantity = " + totalQty + " where asset_code ='" + astCode + "' and site = '" + defaultlocation + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool UpdateSiteInventoryTableFromReturn(string assetCode, int quantity, string location)
        {
            string sqlCommand = "Update site_inventory_table set quantity = " + quantity + " where asset_code ='" + assetCode + "' and site = '" + location + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool UpdateSiteInventoryTableFromMTN(int TransID, int quantity, string deliStat)
        {
            string sqlCommand = "Update site_inventory_table set quantity = " + quantity + ", status = '" + deliStat + "' where transfer_id ='" + TransID + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool UpdateSiteInventoryTableFromMTNEdit(string astCode, string location, int balancedQty)
        {
            string sqlCommand = "Update site_inventory_table set quantity = " + balancedQty + " where asset_code = '" + astCode + "' and site = '" + location + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public string GetDefaultLocationFromAssetCode(string astCode)
        {
            string sqlQuery = "select location from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string location = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                location = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return location;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return location;
            }
        }

        public bool UpdateAssetDetailsTable(string assetCode, int quantity)
        {
            string sqlCommand = "Update asset_details_table set quantity = '" + quantity + "' where asset_code ='" + assetCode + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool UpdateSiteInventoryTableFromQuantity(string assetCode, int qty)
        {
            string sqlCommand = "Update site_inventory_table set quantity = '" + qty + "' where asset_code ='" + assetCode + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        /*=============================== site_details_table ================================*/

        public bool AddNewSite(int site_id, string site_name, string site_code, int contact, string address, int active)
        {
            string sqlCommand = "INSERT into dbo.site_details_table (site_id, site_name, site_code, contact, address, active)" +
            " VALUES(" + site_id + ", '" + site_name + "', '" + site_code + "', " + contact + ", '" + address + "', " + active + ")";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool UpdateSiteDetailsTableActive(string siteName, int active)
        {
            string sqlCommand = "UPDATE dbo.site_details_table SET active = " + active + " WHERE site_name = '" + siteName + "'";

            SqlCommand updateCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                updateCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool UpdateSiteDetailsTable(int id, string siteName, string siteCode, int contact, string address)
        {
            string sqlCommand = "UPDATE dbo.site_details_table SET site_name = '" + siteName + "', site_code = '" + siteCode + "', contact = " + contact + ", address = '" + address + "' WHERE site_id = '" + id + "'";

            SqlCommand updateCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                updateCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public ArrayList GetSiteIDList(int act)
        {
            ArrayList SiteIDList = new ArrayList();

            string sqlQuery = "select site_id from dbo.site_details_table where active = " + act + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    SiteIDList.Add(reader.GetInt32(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return SiteIDList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return SiteIDList;
            }
        }

        public int GetActiveCellValueFromSiteID(int siteID)
        {
            string sqlQuery = "select active from dbo.site_details_table where site_id = '" + siteID + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int act;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                act = reader.GetInt32(0);

                reader.Close();

                queryCommand.Dispose();

                return act;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return act = 0;
            }
        }

        public string GetSiteNameFromSiteID(int siteID)
        {
            string sqlQuery = "select site_name from dbo.site_details_table where site_id = " + siteID + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string siteName = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                siteName = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return siteName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return siteName;
            }
        }

        public string GetSiteCodeFromSiteID(int siteID)
        {
            string sqlQuery = "select site_code from dbo.site_details_table where site_id = " + siteID + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string siteCode = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                siteCode = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return siteCode;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return siteCode;
            }
        }

        public string GetAddressFromSiteID(int siteID)
        {
            string sqlQuery = "select address from dbo.site_details_table where site_id = " + siteID + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string address = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                address = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return address;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return address;
            }
        }

        public int GetContactFromSiteID(int siteID)
        {
            string sqlQuery = "select contact from dbo.site_details_table where site_id = " + siteID + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int contact = 0;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                contact = reader.GetInt32(0);

                reader.Close();

                queryCommand.Dispose();

                return contact;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return contact;
            }
        }

        public ArrayList GetSiteIDListNow()
        {
            ArrayList SiteIDList = new ArrayList();

            string sqlQuery = "select site_id from dbo.site_details_table";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    SiteIDList.Add(reader.GetInt32(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return SiteIDList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return SiteIDList;
            }
        }

        public int GetNextSiteID()
        {

            string sqlQuery = "select site_id from dbo.site_details_table";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                queryCommand.Dispose();

                if (counter != 0)
                    return counter + Site_ID_START;
                return Site_ID_START;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return Site_ID_START;
            }

        }

        /*=============================== supplier_details_table ================================*/

        public bool AddNewSupplier(int supplier_id, string supplier_name, string supplier_type, string company, int contact, string address)
        {
            string sqlCommand = "INSERT into dbo.supplier_details_table (supplier_id, sup_name, sup_type, company, contact_no, address)" +
            " VALUES(" + supplier_id + ", '" + supplier_name + "', '" + supplier_type + "', '" + company + "', " + contact + ", '" + address + "')";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public int GetNextSupplierID()
        {

            string sqlQuery = "select supplier_id from dbo.supplier_details_table";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                queryCommand.Dispose();

                if (counter != 0)
                    return counter + Site_ID_START;
                return Site_ID_START;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return EqType_ID_START;
            }

        }

        public ArrayList GetSupplierIDListNow()
        {
            ArrayList supplierIDList = new ArrayList();

            string sqlQuery = "select supplier_id from dbo.supplier_details_table";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    supplierIDList.Add(reader.GetInt32(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return supplierIDList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return supplierIDList;
            }
        }

        public string GetSupplierNameFromSiteID(int supplierID)
        {
            string sqlQuery = "select sup_name from dbo.supplier_details_table where supplier_id = " + supplierID + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string siteName = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                siteName = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return siteName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return siteName;
            }
        }

        public string GetSupplierTypeFromSiteID(int supplierID)
        {
            string sqlQuery = "select sup_type from dbo.supplier_details_table where supplier_id = " + supplierID + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string siteCode = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                siteCode = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return siteCode;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return siteCode;
            }
        }

        public string GetSupplierAddressFromSiteID(int supplierID)
        {
            string sqlQuery = "select address from dbo.supplier_details_table where supplier_id = " + supplierID + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string address = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                address = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return address;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return address;
            }
        }

        public string GetSupplierCompanyFromSiteID(int supplierID)
        {
            string sqlQuery = "select company from dbo.supplier_details_table where supplier_id = " + supplierID + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string address = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                address = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return address;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return address;
            }
        }

        public int GetSupplierContactFromSiteID(int supplierID)
        {
            string sqlQuery = "select contact_no from dbo.supplier_details_table where supplier_id = " + supplierID + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int contact = 0;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                contact = reader.GetInt32(0);

                reader.Close();

                queryCommand.Dispose();

                return contact;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return contact;
            }
        }

        /*================================= asset_type_table ====================================*/

        public bool AddToEquipmentTypeTable(int id, string eq_type, string eq_short_name)
        {
            string sqlCommand = "INSERT into dbo.asset_type_table (id, eq_type, eq_short_name)" + " VALUES(" + id + ",'" + eq_type + "','" + eq_short_name + "')";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public int GetNextEqTypeID()
        {

            string sqlQuery = "select id from dbo.asset_type_table";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                queryCommand.Dispose();

                if (counter != 0)
                    return counter + EqType_ID_START;
                return EqType_ID_START;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return EqType_ID_START;
            }

        }

        //=============================== asset_categories_table ===============================

        public bool AddAssetCategories(int id, string shortName, string category)
        {
            string sqlCommand = "INSERT into dbo.asset_categories_table (id, eq_short_name, category)" +
            " VALUES('" + id + "', '" + shortName + "','" + category + "')";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public int GetCountOfShortName(string shortName)
        {
            string sqlQuery = "select eq_short_name from dbo.asset_categories_table where eq_short_name ='" + shortName + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);
            int counter = 0;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();
                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                if (counter != 0)
                    return counter;
                return counter = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return counter = 0;
            }
        }
        
        public ArrayList GetAssetCategoriesFromShortName(string shortName)
        {
            ArrayList assetCategoryList = new ArrayList();

            string sqlQuery = "SELECT category from dbo.asset_categories_table WHERE eq_short_name ='" + shortName + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    assetCategoryList.Add(reader.GetString(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return assetCategoryList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetCategoryList;
            }
        }

        public string GetIDFromEQtype(string shortName)
        {
            string sqlQuery = "select id from dbo.asset_categories_table WHERE eq_short_name ='" + shortName + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string pre_fix = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                pre_fix = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return pre_fix;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return pre_fix;
            }
        }

        public ArrayList GetAssetCategoryIDListNow(string shortName)
        {
            ArrayList CategoryIDList = new ArrayList();

            string sqlQuery = "select id from dbo.asset_categories_table WHERE eq_short_name ='" + shortName + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    CategoryIDList.Add(reader.GetInt32(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return CategoryIDList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return CategoryIDList;
            }
        }

        public string GetassetCategoryNameFromCategoryID(int categoryID)
        {
            string sqlQuery = "select category from dbo.asset_categories_table WHERE id = " + categoryID + " ORDER BY id";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string category = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                category = reader.GetString(0);

                reader.Close();

                queryCommand.Dispose();

                return category;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return category;
            }
        }

        public bool IsCategoryNameExists(string shortName, string category)
        {
            string sqlQuery = "select category from dbo.asset_categories_table where eq_short_name ='" + shortName + "' and category ='" + category + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                queryCommand.Dispose();

                if (counter != 0)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return true;
            }
        }

        public int GetNextCategoryID()
        {

            string sqlQuery = "select id from dbo.asset_categories_table";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                queryCommand.Dispose();

                if (counter != 0)
                    return counter + Category_ID_START;
                return Category_ID_START;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return Category_ID_START;
            }

        }

        //=============================== mtn_details_table ===============================

        public bool AddMTNToMtnDetailsTable(string mtnNo, DateTime transDate, string fromWhere, string toWhere, string asset_code, int quantity, string working_status, string hireName)
        {
            string sqlCommand = "INSERT into dbo.mtn_details_table (mtn_no, transferred_date, from_where, to_where, asset_code, quantity, working_status, hire_name)" +
            " VALUES('" + mtnNo + "','" + transDate.ToShortDateString() + "','" + fromWhere + "','" + toWhere + "','" + asset_code + "'," + quantity + ",'" + working_status + "','" + hireName + "')";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool AddToMTNStatusTable(string mtnNo, DateTime transDate, string diliStat)
        {
            string sqlCommand = "INSERT into dbo.mtn_status_table (mtn_no, transferred_date, dilivery_status)" + " VALUES('" + mtnNo + "','" + transDate.ToShortDateString() + "','" + diliStat + "')";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool UpdateQuantityofSiteInventoryTable(int tabletransID, int quantity)
        {
            string sqlCommand = "UPDATE dbo.site_inventory_table SET quantity = " + quantity + " WHERE transfer_id = '" + tabletransID + "'";

            SqlCommand updateCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                updateCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool UpdateMTNDetailsTableFromEdit(string mtnNo, string astCode, int correctQty)
        {
            string sqlCommand = "Update mtn_details_table set quantity = '" + correctQty + "' where mtn_no ='" + mtnNo + "' and asset_code = '" + astCode + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public ArrayList GetAssetIDListFromAssetTypeandCategory(string pre_fix, string category)
        {
            ArrayList assetIDList = new ArrayList();

            string sqlQuery = "SELECT id from dbo.asset_details_table WHERE pre_fix ='" + pre_fix + "' AND category = '" + category + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    assetIDList.Add(reader.GetInt32(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return assetIDList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetIDList;
            }
        }

        public ArrayList GetAssetIDListFromLocationInSiteInventoryTable(string location)
        {
            ArrayList assetIDList = new ArrayList();

            string sqlQuery = "SELECT id from dbo.site_inventory_table WHERE site ='" + location + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    assetIDList.Add(reader.GetInt32(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return assetIDList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetIDList;
            }
        }

        public ArrayList GetAssetCodeListFromLocationInSiteInventoryTable(string location)
        {
            ArrayList assetCodeList = new ArrayList();

            string sqlQuery = "SELECT asset_code from dbo.site_inventory_table WHERE site ='" + location + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    assetCodeList.Add(reader.GetString(0));
                }

                reader.Close();

                queryCommand.Dispose();

                return assetCodeList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetCodeList;
            }
        }

        public int GetAvailableQuantityInSiteInventory(string assetCode, string location)
        {
            string sqlQuery = "select quantity from dbo.site_inventory_table where asset_code ='" + assetCode + "' and site = '" + location + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int TransferID = 0;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();
                if (reader.Read())
                {
                    TransferID = reader.GetInt32(0);
                }
                while (reader.Read())
                {
                    TransferID = reader.GetInt32(0);
                    if (TransferID == 0)
                    {
                        return TransferID = 0;
                    }
                }
                reader.Close();

                return TransferID;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return TransferID = 0;
            }
        }

        public bool UpdateSiteInventoryFromMTN(string assetCode, string location, int quantity, string deliStat)
        {
            string sqlCommand = "Update site_inventory_table set quantity = " + quantity + ", status = '" + deliStat + "' where asset_code ='" + assetCode + "' and site = '" + location + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public string GetDiliveryStatusFromMtnNo(string mtnNo)
        {
            string sqlQuery = "select dilivery_status from dbo.mtn_status_table where mtn_no = '" + mtnNo + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string status = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                status = reader.GetString(0);

                reader.Close();
                reader.Dispose();

                return status;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return status;
            }
        }

        public int GetTransferIDFromIDAndLocation(int assetID, string location)
        {
            string sqlQuery = "select transfer_id from dbo.site_inventory_table where id =" + assetID + " and site = '" + location + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int TransferID = 0;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();
                if (reader.Read())
                {
                    TransferID = reader.GetInt32(0);
                }
                while (reader.Read())
                {
                    TransferID = reader.GetInt32(0);
                    if (TransferID == 0)
                    {
                        return TransferID = 0;
                    }
                }
                reader.Close();

                return TransferID;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return TransferID = 0;
            }
        }

        public int GetTransferIDFromCodeAndLocation(string assetCode, string location)
        {
            string sqlQuery = "select transfer_id from dbo.site_inventory_table where asset_code ='" + assetCode + "' and site = '" + location + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int TransferID = 0;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();
                if (reader.Read())
                {
                    TransferID = reader.GetInt32(0);
                }
                while (reader.Read())
                {
                    TransferID = reader.GetInt32(0);
                    if (TransferID == 0)
                    {
                        return TransferID = 0;
                    }
                }
                reader.Close();

                return TransferID;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return TransferID = 0;
            }
        }

        public string GetAssetCodeFromIDAndLocation(int assetID)
        {
            string sqlQuery = "select asset_code from dbo.asset_details_table where id =" + assetID + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string assetName = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                assetName = reader.GetString(0);

                reader.Close();

                return assetName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetName;
            }
        }

        public string GetAssetNameFromIDAndLocation(int assetID)
        {
            string sqlQuery = "select asset_name from dbo.asset_details_table where id =" + assetID + "";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string assetName = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                assetName = reader.GetString(0);

                reader.Close();

                return assetName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetName;
            }
        }

        public string GetAssetNameFromCodeAndLocation(string assetCode)
        {
            string sqlQuery = "select asset_name from dbo.asset_details_table where asset_code ='" + assetCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string assetName = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                assetName = reader.GetString(0);

                reader.Close();

                return assetName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetName;
            }
        }

        public int GetAvailableQuantityInSiteFromAssetCode(string assetCode, string status, string location)
        {
            string sqlQuery = "select quantity from dbo.site_inventory_table where asset_code = '" + assetCode + "' and status = '" + status + "' and site = '" + location + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int quantity = 0;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();
                if (reader.Read())
                {
                    quantity = reader.GetInt32(0);
                }
                while (reader.Read())
                {
                    quantity = reader.GetInt32(0);
                    if (quantity == 0)
                    {
                        return quantity = 0;
                    }
                }
                reader.Close();

                return quantity;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return quantity;
            }
        }

        public ArrayList GetPendingMTNListFromDiliStat(string diliStat)
        {
            ArrayList mtnList = new ArrayList();

            string sqlQuery = "select mtn_no from dbo.mtn_status_table WHERE dilivery_status = '" + diliStat + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    mtnList.Add(reader.GetString(0));
                }

                reader.Close();

                return mtnList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return mtnList;
            }
        }

        public ArrayList GetAssetCodeListFromMTNNo(string mtnNo)
        {
            ArrayList assetCode = new ArrayList();

            string sqlQuery = "select asset_code from dbo.mtn_details_table where mtn_no = '" + mtnNo + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    assetCode.Add(reader.GetString(0));
                }
                reader.Close();

                return assetCode;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetCode;
            }
        }

        public string GetAssetNameFromAssetCode(string astCode)
        {
            string sqlQuery = "select asset_name from dbo.asset_details_table where asset_code = '" + astCode + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string assetName = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                assetName = reader.GetString(0);

                reader.Close();

                return assetName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetName;
            }
        }

        public string GetWorkingStatFromAssetCode(string astCode, string mtnNo)
        {
            string sqlQuery = "select working_status from dbo.mtn_details_table where asset_code = '" + astCode + "' and mtn_no = '" + mtnNo + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string workStat = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                workStat = reader.GetString(0);

                reader.Close();

                return workStat;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return workStat;
            }
        }

        public int GetQuantityFromAssetCode(string astCode, string mtnNo)
        {
            string sqlQuery = "select quantity from dbo.mtn_details_table where asset_code = '" + astCode + "' and mtn_no = '" + mtnNo + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int quantity;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                quantity = reader.GetInt32(0);

                reader.Close();

                return quantity;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return quantity = 0;
            }
        }

        public string GetAssetCodeFromAssetName(string astName)
        {
            string sqlQuery = "select asset_code from dbo.asset_details_table where asset_name = '" + astName + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string assetCode = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                assetCode = reader.GetString(0);

                reader.Close();

                return assetCode;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetCode;
            }
        }

        public string GetSenderLocationFromMTNandAstCode(string astCode, string mtnNo)
        {
            string sqlQuery = "select from_where from dbo.mtn_details_table where asset_code = '" + astCode + "' and mtn_no = '" + mtnNo + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string location = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                location = reader.GetString(0);

                reader.Close();

                return location;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return location;
            }
        }

        public int GetSenderAvailableQuantityFromLocationandAssetCode(string astCode, string location)
        {
            string sqlQuery = "select quantity from dbo.site_inventory_table where asset_code = '" + astCode + "' and site = '" + location + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int quantity;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                quantity = reader.GetInt32(0);

                reader.Close();

                return quantity;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return quantity = 0;
            }
        }

        public int GetNextTransferID()
        {
            int TRANSFER_ID_START = 1;

            string sqlQuery = "select transfer_id from dbo.site_inventory_table";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                if (counter != 0)
                    return counter + TRANSFER_ID_START;
                return TRANSFER_ID_START;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return TRANSFER_ID_START;
            }
        }

        public bool DeleteItem(string assetCode)
        {
            string sqlCommand = "DELETE FROM dbo.asset_details_table WHERE asset_code = '" + assetCode + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool DeleteSupplier(int supplierId)
        {
            string sqlCommand = "DELETE FROM dbo.supplier_details_table WHERE supplier_id = '" + supplierId + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool DeleteItemFromSiteInventory(string assetCode)
        {
            string sqlCommand = "DELETE FROM dbo.site_inventory_table WHERE asset_code = '" + assetCode + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool DeleteRecordsFromMTNNo(string mtnNo)
        {
            string sqlCommand = "DELETE FROM dbo.mtn_details_table WHERE mtn_no = '" + mtnNo + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool DeleteRecordsInMTNStatusFromMTNNo(string mtnNo)
        {
            string sqlCommand = "DELETE FROM dbo.mtn_status_table WHERE mtn_no = '" + mtnNo + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool IsMtnNoExists(string mtn_No)
        {
            string sqlQuery = "select mtn_no from dbo.grn_details_table where mtn_no = '" + mtn_No + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                if (counter != 0)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return true;
            }

        }

        public bool IsMtnNoExistsInMTNStatusTable(string mtn_No)
        {
            string sqlQuery = "select mtn_no from dbo.mtn_status_table where mtn_no = '" + mtn_No + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();
                reader.Dispose();

                if (counter != 0)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return true;
            }

        }

        //================================= mtn_edit_table ==================================

        public bool AddToMTNEditTable(string mtnNo, string astCode, int currentQty, int correctQty, string editor)
        {
            string sqlCommand = "INSERT into dbo.mtn_edit_table (mtn_no, asset_code, old_quantity, new_quantity, editor)" + " VALUES('" + mtnNo + "','" + astCode + "'," + currentQty + "," + correctQty + ",'" + editor + "')";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        /*================================= grn_details_table ===================================*/

        public bool AddGRNToGRNDetailsTable(string mtnNo, string grnNo, string transDate, string recDate, string receiver, string asset_code, int quantity, string working_status, string currentStatus)
        {
            string sqlCommand = "INSERT into dbo.grn_details_table (mtn_no, grn_no, transferred_date, received_date, receiver, asset_code, quantity, working_status, current_status)" +
            " VALUES('" + mtnNo + "','" + grnNo + "','" + transDate + "','" + recDate + "','" + receiver + "','" + asset_code + "'," + quantity + ",'" + working_status + "','" + currentStatus + "')";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool UpdateMTNStatusTableFromGRN(string mtnNo, string deliStat)
        {
            string sqlCommand = "Update mtn_status_table set dilivery_status = '" + deliStat + "' where mtn_no = '" + mtnNo + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public DateTime GetTransferredDateFromMTNNo(string mtnNo)
        {
            string sqlQuery = "select transferred_date from dbo.mtn_details_table where mtn_no = '" + mtnNo + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            DateTime transDate;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                transDate = reader.GetDateTime(0);

                reader.Close();

                return transDate;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return transDate = DateTime.Now;
            }
        }

        public string GetDiliveryLocationFromMTNNo(string mtnNo)
        {
            string sqlQuery = "select to_where from dbo.mtn_details_table where mtn_no = '" + mtnNo + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string location = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                location = reader.GetString(0);

                reader.Close();

                return location;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return location;
            }
        }

        public bool UpdateSiteInventoryTableFromGRN(string assetCode, int quantity, string location)
        {
            string sqlCommand = "Update site_inventory_table set quantity = " + quantity + " where asset_code ='" + assetCode + "' and site = '" + location + "'";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        /*================================= claim_details_table =================================*/

        public bool AddToClaimDetailsTable(int tablleID, string asset_code, int quantity, DateTime filtered_date, DateTime done_date, string action, string site, string remarks, string status)
        {
            string sqlCommand = "INSERT into dbo.claim_details_table (table_id, asset_code, quantity, filtered_date, done_date, action, site, remarks, status)" +
            " VALUES(" + tablleID + ",'" + asset_code + "'," + quantity + ",'" + filtered_date + "','" + done_date + "','" + action + "','" + site + "','" + remarks + "','" + status + "')";

            SqlCommand saveCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                saveCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public bool UpdateClaimDetailsTableFromArrangeAssets(int id, DateTime doneDate, string status, string action)
        {
            string sqlCommand = "UPDATE dbo.claim_details_table SET done_date = '" + doneDate + "', status = '" + status + "' WHERE table_id = " + id + " and action = '" + action + "'";

            SqlCommand updateCommand = new SqlCommand(sqlCommand, myConnection);

            try
            {
                updateCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public int GetNextTableID()
        {
            int TRANSFER_ID_START = 1;

            string sqlQuery = "select table_id from dbo.claim_details_table";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    //get rows
                    counter++;
                }

                reader.Close();

                if (counter != 0)
                    return counter + TRANSFER_ID_START;
                return TRANSFER_ID_START;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return TRANSFER_ID_START;
            }
        }

        public ArrayList GetTableIDListFromClaimDetailsTable(string action, string astCode, string site)
        {
            ArrayList assetIDList = new ArrayList();
            string status = "Pending";
            string sqlQuery = "SELECT table_id from dbo.claim_details_table WHERE action ='" + action + "' and status ='" + status + "' and asset_code = '" + astCode + "' and site = '" + site + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    assetIDList.Add(reader.GetInt32(0));
                }

                reader.Close();

                return assetIDList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetIDList;
            }
        }

        public ArrayList GetTableIDList(string action, string site)
        {
            ArrayList assetIDList = new ArrayList();
            string status = "Pending";
            string sqlQuery = "SELECT table_id from dbo.claim_details_table WHERE action ='" + action + "' and status ='" + status + "' and site ='" + site + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                while (reader.Read())
                {
                    assetIDList.Add(reader.GetInt32(0));
                }

                reader.Close();

                return assetIDList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetIDList;
            }
        }

        public string GetAssetCodeFromIDAndAction(int tableID, string action)
        {
            string sqlQuery = "select asset_code from dbo.claim_details_table where table_id =" + tableID + " and action = '" + action + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string assetName = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                assetName = reader.GetString(0);

                reader.Close();

                return assetName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetName;
            }
        }

        public int GetQuantityFromIDAndAction(int tableID, string action)
        {
            string sqlQuery = "select quantity from dbo.claim_details_table where table_id = " + tableID + " and action = '" + action + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            int quantity;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                quantity = reader.GetInt32(0);

                reader.Close();

                return quantity;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return quantity = 0;
            }
        }

        public DateTime GetSendDateFromIDAndAction(int tableID, string action)
        {
            string sqlQuery = "select filtered_date from dbo.claim_details_table where table_id = " + tableID + " and action = '" + action + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            DateTime transDate;
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                transDate = reader.GetDateTime(0);

                reader.Close();

                return transDate;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return transDate = DateTime.Now;
            }
        }

        public string GetRemarksFromIDAndAction(int tableID, string action)
        {
            string sqlQuery = "select remarks from dbo.claim_details_table where table_id =" + tableID + " and action = '" + action + "'";

            SqlCommand queryCommand = new SqlCommand(sqlQuery, myConnection);

            string assetName = "";
            try
            {
                SqlDataReader reader = queryCommand.ExecuteReader();

                reader.Read();

                assetName = reader.GetString(0);

                reader.Close();

                return assetName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return assetName;
            }
        }

    }
}
