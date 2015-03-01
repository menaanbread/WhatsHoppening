using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_v0
{
    public class GetAllBeers : GetData
    {
        #region " Constants "

        const string PROC_NAME = "dbo.GetAllBeers";

        #endregion

        #region " Methods "

        public override SqlCommand MakeCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = PROC_NAME;
            cmd.CommandType = CommandType.StoredProcedure;

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
