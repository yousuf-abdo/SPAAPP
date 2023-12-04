using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class cls_medicines
    {
        DatabaseClass db = new DatabaseClass();
        public DataTable getAllMedicines()
        {
            try
            {
                string sql = String.Format("SELECT * FROM tbl_Medicine  ");
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public DataTable getAllReqMedicines()
        {
            try
            {
                string sql = String.Format("SELECT reqID as ID, medName as 'Medicine Name', custPhone as 'Customer Phone No' FROM tbl_Requested  ");
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getAllMedicines(int medNAME)
        {
            try
            {
                string sql = String.Format("SELECT * FROM tbl_Medicine  WHERE  medNAME = " + medNAME);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getAllMedicinesByphID(int phID)
        {
            try
            {
                string sql = String.Format("SELECT * FROM tbl_Medicine  WHERE  phId = " + phID);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getAllMedicinesByphmedID(int medID)
        {
            try
            {
                string sql = String.Format("SELECT * FROM tbl_Medicine  WHERE  medID = " + medID);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int addMedicines(string medNAME, string medPRICE, string medQUANTITY, string phID)
        {
            try
            {
                
                string sqlCmd = " INSERT    INTO  tbl_Medicine (medNAME,medPRICE,medQuantaty,phID)  values ('" + medNAME + "','" + medPRICE + "','" + medQUANTITY + "'," + phID + ") ";
                
                int x =db.ExecuteNonQuery(sqlCmd);
               
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int addReqMedicine(string medName, string custPhone)
        {
            try
            {
                string sqlCmd = " INSERT INTO tbl_Requested (medName,custPhone) values ('" + medName + "','" + custPhone + "')";

                int x = db.ExecuteNonQuery(sqlCmd);

                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updateMedicines(string medNAME, string medPRICE, string medQUANTITY, string medID)
        {
            string sqlCmd = "UPDATE tbl_Medicine SET  medName ='" + medNAME + "', medPrice =" + medPRICE + ",medQuantaty =" + medQUANTITY  + "  WHERE medID =" +medID;

            return db.ExecuteNonQuery(sqlCmd);            
        }    
        public  int deleteMedicines(int medID)
        {
            string sqlCmd = "DELETE    FROM   tbl_Medicine    WHERE medID =" + medID;

            return db.ExecuteNonQuery(sqlCmd);
        }
        public int deleteReqMedicines(int reqID)
        {
            string sqlCmd = "DELETE FROM tbl_Requested WHERE reqID=" + reqID;

            return db.ExecuteNonQuery(sqlCmd);
        }
        public DataTable SearchMed(string medName  , string tblName)
        {
            try
            {
                /*
                select phID as ID,phName as Name ,phEmail as 'E - mail' ,phLocation as 'Location' ,phPhone1 as Phone1 ,phPhone2 as Phone2 from tbl_Pharmacies WHERE phID NOT IN (SELECT  phID FROM tbl_Users  WHERE userTYPE = 1) 
                */
                string sql = String.Format(" SELECT  tbl_Medicine.medName as Medicine, tbl_Medicine.medPrice as Price,  tbl_Medicine.medQuantaty as Quantity, tbl_Pharmacies.phID as phID,tbl_Pharmacies.phNAME as Pharmacy, tbl_Pharmacies.phLOCATION as Address  FROM tbl_Medicine  join tbl_Pharmacies on tbl_Medicine.phID = tbl_Pharmacies.phID " + 
                    " where  " + tblName + "='"+ medName + "'  AND tbl_Pharmacies.phID NOT IN (SELECT  phID FROM tbl_Users  WHERE userTYPE = 1) ");
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
         
         tbl_Pharmacies.phNAME = 'Almk_niemer'
         tbl_Pharmacies.phNAME = 'Almk_niemer'

SELECT tbl_Medicine.medID, tbl_Medicine.medNAME,tbl_Medicine.medPRICE , tbl_Medicine.medQUANTITY ,tbl_Pharmacies.phNAME ,tbl_Pharmacies.phLOCATION
 FROM tbl_Medicine join tbl_Pharmacies on tbl_Medicine.phID= tbl_Pharmacies.phID
 where tbl_Pharmacies.phNAME = 'Almk_niemer';

         */
    }
}
