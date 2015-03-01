using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Infrastructure_v0
{
    public class CreateNewAccountData : CreateData
    {

        #region " Declartions - parameters "

        private string username;
        private string name;
        private string email;
        private DateTime dob;
        private string location;
        private string password;

        #endregion

        #region " Constants "

        const string PROC_NAME = "dbo.OpenAccount";

        #endregion

        #region " Constructors "

        public CreateNewAccountData(string username, string name, string email, DateTime dob, string location, string password)
        {
            this.username = username;
            this.name = name;
            this.email = email;
            this.dob = dob;
            this.location = location;
            this.password = password;
        }

        #endregion

        #region " Methods "

        /// <summary>
        /// Setup the SqlCommand object for use by CreateData. Set type as StoredProcedure, annd proc name, and set all the parameters. 
        /// </summary>
        /// <returns>Correctly formatted SqlCommand object</returns>
        public override SqlCommand MakeCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = PROC_NAME;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = username;
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 150).Value = name;
            cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 150).Value = email;
            cmd.Parameters.Add("@DOB", System.Data.SqlDbType.Date).Value = dob;
            cmd.Parameters.Add("@Location", System.Data.SqlDbType.NVarChar, 250).Value = location;
            cmd.Parameters.Add("@Image", System.Data.SqlDbType.Image).Value = DBNull.Value;       //ToDo implement me!
            cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = password;

            return cmd;
        }

        /// <summary>
        /// Assign value of CreateData.Cmd object to be result of MakeCommand(), and then run CreateData.DoInsert()
        /// </summary>
        /// <returns>Success indicator</returns>
        public override bool DoInsert()
        {
            base.Cmd = this.MakeCommand();
            return base.DoInsert();
        }

        #endregion

    }
}
