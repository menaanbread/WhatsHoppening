using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Infrastructure_v0
{
    public class GetAccountData : GetData
    {

        #region " Declartions - parameters "

        private int accountId;
        private string username;

        #endregion

        #region " Constants "

        const string PROC_NAME_BY_ID = "dbo.GetAccount";
        const string PROC_NAME_BY_USERNAME = "dbo.GetAccountByUsername";

        #endregion

        #region " Constructors "

        public GetAccountData(int accountId)
        {
            this.accountId = accountId;
            this.username = "";
        }

        public GetAccountData(string username)
        {
            this.username = username;
            this.accountId = 0;
        }

        #endregion

        #region " Methods "

        public override SqlCommand MakeCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            if (accountId > 0)
            {
                cmd.CommandText = PROC_NAME_BY_ID;
                cmd.Parameters.Add("@accountId", System.Data.SqlDbType.Int).Value = accountId;
            }
            else
            {
                cmd.CommandText = PROC_NAME_BY_USERNAME;
                cmd.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = username;
            }
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
