using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Infrastructure_v0
{
    /// <summary>
    /// This references a stored proc with no parameters - hence the lightweight class
    /// </summary>
    public class GetAllBreweriesData : GetData
    {

        #region " Constants "

        const string PROC_NAME = "dbo.GetAllBreweries";

        #endregion

        #region " Methods "

        public override SqlCommand MakeCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = PROC_NAME;
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
