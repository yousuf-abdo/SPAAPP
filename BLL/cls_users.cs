using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class cls_users
    {
        DatabaseClass db = new DatabaseClass();
        public DataTable getAllUsers()
        {
            try
            {
                string sql = String.Format("SELECT * FROM tbl_Users  ");
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getAllUsers(int userID)
        {
            try
            {
                string sql = String.Format("SELECT * FROM tbl_Users  WHERE  UserID = " + userID);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getAllUsersForPassword(string regID)
        {
            try
            {
                string sql = String.Format("SELECT   tbl_Users.* , tbl_Pharmacies.*  FROM tbl_Users JOIN  tbl_Pharmacies  ON   " +
                                                            "  tbl_Pharmacies.phID = tbl_Users.phID WHERE tbl_Users.phRegister_ID1 = '" + regID + "'");
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getAllUserPhID(int phID)
        {
            try
            {
                string sql = String.Format("SELECT * FROM tbl_Users  WHERE  phID = " + phID);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable validateNumber(string randNumber)
        {
            try
            {
                string sql = String.Format("SELECT *   FROM tbl_Users  WHERE  randNumber = " + randNumber);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int addUsers(string userNAME, string userPASSWORD, string userTYPE, string phID)
        {
            try
            {

                string sqlCmd = " INSERT    INTO  tbl_Users(userNAME,userPASSWORD,userTYPE,phID)  values ('" + userNAME + "','" + userPASSWORD + "','" + userTYPE + "','" + phID + "') ";

                int x = db.ExecuteNonQuery(sqlCmd);

                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int addUsers(string userNAME, string userPASSWORD, int phID, string phRegister_ID1)
        {
            try
            {

                string sqlCmd = " INSERT    INTO  tbl_Users(userNAME,userPASSWORD,phID , phRegister_ID1)  values ('" + userNAME + "','" + userPASSWORD + "'," + phID + ",'" + phRegister_ID1 + "') ";

                int x = db.ExecuteNonQuery(sqlCmd);

                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateUsers(string userNAME, string userPASSWORD, string regID, string userID)
        {
            string sqlCmd = " UPDATE   tbl_Users  SET  userNAME ='" + userNAME + "', userPASSWORD ='" + userPASSWORD + "' , phRegister_ID1 = '" + regID + "'    WHERE  userID = " + userID;

            return db.ExecuteNonQuery(sqlCmd);
        }

        public int updateUsersRanNumber(int randNumber, string userID)
        {

            try
            {
                string sqlCmd = " UPDATE   tbl_Users  SET  randNumber =" + randNumber + " WHERE  userID = " + userID;

                return db.ExecuteNonQuery(sqlCmd);
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int updateUsersPassword(string userPASSWORD, string phRegister_ID1)
        {
            try
            {
                string sqlCmd = " UPDATE   tbl_Users  SET  userPASSWORD ='" + userPASSWORD + "'    WHERE  phRegister_ID1 = '" + phRegister_ID1 + "'";

                return db.ExecuteNonQuery(sqlCmd);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int deleteUsers(int userNAME)
        {
            string sqlCmd = "DELETE    FROM   tbl_Users    WHERE userNAME =" + userNAME;

            return db.ExecuteNonQuery(sqlCmd);
        }

        public DataTable Login(string RegId, string Password)
        {
            try
            {
                string sql = String.Format("SELECT * FROM tbl_Users  WHERE  phRegister_ID1 = '" + RegId + " '   AND   userPASSWORD ='" + Password + "'");
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

//    public class cls_users
//    {
//        DatabaseClass db = new DatabaseClass();
//        public DataTable getAllUsers()
//        {
//            try
//            {
//                string sql = String.Format("SELECT * FROM tbl_Users  ");
//                return db.ExecuteQuery(sql);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }            
//        }

//        public DataTable getAllUsers(int userID)
//        {
//            try
//            {
//                string sql = String.Format("SELECT * FROM tbl_Users  WHERE  UserID = " + userID);
//                return db.ExecuteQuery(sql);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public DataTable getAllUserPhID(int phID)
//        {
//            try
//            {
//                string sql = String.Format("SELECT * FROM tbl_Users  WHERE  phID = " + phID);
//                return db.ExecuteQuery(sql);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public int addUsers(string userNAME, string userPASSWORD, string userTYPE, string phID)
//        {
//            try
//            {

//                string sqlCmd = " INSERT    INTO  tbl_Users(userNAME,userPASSWORD,userTYPE,phID)  values ('" + userNAME + "','" + userPASSWORD + "','" + userTYPE + "','" + phID + "') ";

//                int x =db.ExecuteNonQuery(sqlCmd);

//                return x;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public int addUsers(string userNAME, string userPASSWORD, int phID ,string phRegister_ID1)
//        {
//            try
//            {

//                string sqlCmd = " INSERT    INTO  tbl_Users(userNAME,userPASSWORD,phID , phRegister_ID1)  values ('" + userNAME + "','" + userPASSWORD  + "'," + phID + ",'"+ phRegister_ID1+"') ";

//                int x = db.ExecuteNonQuery(sqlCmd);

//                return x;
//            }
//            catch (Exception ex)
//            {
//                //throw ex;
//                return -1;
//            }
//        }

//        public int updateUsers(string userNAME, string userPASSWORD, string userID)
//        {
//            string sqlCmd = " UPDATE   tbl_Users  SET  userNAME ='" + userNAME + "', userPASSWORD ='" + userPASSWORD + "' WHERE  userID = " + userID;

//            return db.ExecuteNonQuery(sqlCmd);            
//        }

//        public  int deleteUsers(int userNAME)
//        {
//            string sqlCmd = "DELETE    FROM   tbl_Users    WHERE userNAME =" + userNAME;

//            return db.ExecuteNonQuery(sqlCmd);
//        }


//        public DataTable Login(string RegId , string Password)
//        {
//            try
//            {
//                string sql = String.Format("SELECT * FROM tbl_Users  WHERE  phRegister_ID1 = '" + RegId + " '   AND   userPASSWORD ='"+Password + "'" );
//                return db.ExecuteQuery(sql);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}
