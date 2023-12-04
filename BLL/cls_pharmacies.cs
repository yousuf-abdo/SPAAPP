using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class cls_pharmacies
    {
        DatabaseClass db = new DatabaseClass();
        public DataTable getAllPharmacies()
        {
            try
            {
                string sql = String.Format("SELECT * FROM tbl_Pharmacies  ");
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public DataTable getAllPharmacies1()
        {
            try
            {
                string sql = String.Format("select phID as ID,phName as Name ,phEmail as 'E - mail' ,phLocation as 'Location' ,phPhone1 as Phone1 ,phPhone2 as Phone2 from tbl_Pharmacies WHERE phID NOT IN (SELECT  phID FROM tbl_Users  WHERE userTYPE = 1) ");
                
                //string sql = String.Format(" SELECT  * FROM tbl_Pharmacies WHERE phID NOT IN (SELECT  phID FROM tbl_Users  WHERE userTYPE = 1) ");
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getAllPharmacies(int  phID)
        {
            try
            {
                string sql = String.Format("SELECT * FROM tbl_Pharmacies  WHERE  phID = "+phID);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getPharmacyForUpdate(int phID)
        {
            try
            {
                string sql = String.Format(" select tbl_Users.*, tbl_Pharmacies.* from tbl_Pharmacies join tbl_Users on tbl_Pharmacies.phID = tbl_Users.phID  where tbl_Users.phID =" + phID);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }     
        public int addPharmacyOld(string PhName, string PhLocation, string phPhone1, string phPhone2, string PhEmail, string PhRegisterID ,string  phImage_Path)
        {
            
            try
            {
                string sqlCmd = " INSERT    INTO  tbl_Pharmacies (phName,phLocation,phPhone1,phPhone2,phEmail,phRegister_ID , phImage_Path)  values ('" + PhName + "','" + PhLocation + "','" + phPhone1 + "','" + phPhone2 + "','" + PhEmail + "','" + PhRegisterID + "','"+phImage_Path+ "')  Select @@Identity";                

                var  x = db.ExecuteScalar(sqlCmd);
                int res = int.Parse(x.ToString());
                return res;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public int addPharmacy(string PhName, string PhLocation, string phPhone1, string phPhone2, string PhEmail, string PhRegisterID, string phImage_Path ,string LocLat , string LocLong)
        {

            try
            {
                string sqlCmd = " INSERT INTO tbl_Pharmacies(phName ,phLocation ,phPhone1 ,phPhone2 ,phEmail ,phRegister_ID ,phImage_Path ,LocLat ,LocLong) VALUES('" + PhName + "','" + PhLocation + "','" + phPhone1 + "','" + phPhone2 + "','" + PhEmail + "','" + PhRegisterID + "','" + phImage_Path + "','"+LocLat+"','" + LocLong + "')  Select @@Identity ;";

                int x = int.Parse(db.ExecuteScalar(sqlCmd).ToString());
                //int res = int.Parse(x.ToString());
                return x;
            }
            catch (Exception  ex)
            {
                throw ex;
            }
        }

        public int updatePharmacyOld(string PhName, string PhLocation, string phPhone1, string phPhone2, string PhEmail, string phImage_Path, string PhRegisterID, string phID)
        {
            string sqlCmd = " UPDATE   tbl_Pharmacies  SET  PhName ='" + PhName + "', PhLocation ='" + PhLocation + "',phPhone1 = '" + phPhone1 + "', phPhone2 ='" + phPhone2
                + "', PhEmail ='" + PhEmail + "', PhImage_Path = '" + phImage_Path + "',PhRegister_ID = '" + PhRegisterID + "'  WHERE phID = " + phID;

            return db.ExecuteNonQuery(sqlCmd);
        }
        public int  updatePharmacy(string PhName, string PhLocation, string phPhone1, string phPhone2, string PhEmail, string phImage_Path, string PhRegisterID ,string phID , string LocLong, string LocLat)
        {
            string sqlCmd = " UPDATE   tbl_Pharmacies  SET  PhName ='" + PhName + "', PhLocation ='" + PhLocation + "',phPhone1 = '" + phPhone1 + "', phPhone2 ='" + phPhone2
                + "', PhEmail ='" + PhEmail + "', PhImage_Path = '" + phImage_Path + "',PhRegister_ID = '" +PhRegisterID + "' ,LocLong = '" + LocLong + "',LocLat ='"+ LocLat+"' WHERE phID = " + phID;

            return db.ExecuteNonQuery(sqlCmd);            
        }    
        public  int  deletePharacy(int phID)
        {
            string sqlCmd = "DELETE    FROM   tbl_Pharmacies    WHERE phID = " + phID;      
            return db.ExecuteNonQuery(sqlCmd);
        }
        public int deletePharacy1(int phID)
        {
            string sqlCmd = "DELETE FROM   tbl_USers WHERE phID = " + phID +
                                        "     DELETE FROM   tbl_Medicine WHERE phID = " + phID +
                                        "     DELETE FROM   tbl_Pharmacies WHERE phID = " + phID;

            return db.ExecuteNonQuery(sqlCmd);
        }
        /**********************************************************************************************************************************/
        public DataTable getPhaMap()
        {
            try
            {
                string sql = String.Format("SELECT * FROM tbl_Pharmacies ");
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getPhaMap(string phID)
        {
            try
            {
                string sql = String.Format("SELECT * FROM tbl_Pharmacies  WHERE   phID =" + phID);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    
}
}
