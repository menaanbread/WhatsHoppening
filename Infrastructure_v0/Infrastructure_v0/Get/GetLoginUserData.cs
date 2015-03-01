using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Infrastructure_v0
{
    public class GetLoginUserData : GetData
    {

        #region " Declartions - parameters "

        private string username;
        private string password;

        #endregion

        #region " Constants "

        const string PROC_NAME = "dbo.LoginUser";

        #endregion

        #region " Constructors "

        public GetLoginUserData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        #endregion

        #region " Methods " 

        public override SqlCommand MakeCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = PROC_NAME;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = username;
            cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = password;

            return cmd;
        }

        public override DataSet Execute()
        {
            base.Cmd = this.MakeCommand();
            return base.Execute();
        }

        #endregion

    }
}
