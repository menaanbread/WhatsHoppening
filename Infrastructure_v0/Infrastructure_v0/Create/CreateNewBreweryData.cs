using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Infrastructure_v0
{
    public class CreateNewBreweryData : CreateData
    {

        #region " Declartions - parameters "

        private string name;
        private string location;
        private DateTime year;
        private string website;

        #endregion

        #region " Constants "

        const string PROC_NAME = "dbo.AddBrewery";

        #endregion

        #region " Constructor "

        public CreateNewBreweryData(string name, string location, DateTime year, string website)
        {
            this.name = name;
            this.location = location;
            this.year = year;
            this.website = website;
        }

        #endregion

        #region " Methods "

        /// <summary>
        /// Setup the SqlCommand object for use by CreateData. Set type as StoredProcedure, and proc name, and set all the parameters. 
        /// </summary>
        /// <returns>Correctly formatted SqlCommand object</returns>
        public override SqlCommand MakeCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = PROC_NAME;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 50).Value = name;
            cmd.Parameters.Add("@Location", System.Data.SqlDbType.NVarChar, 200).Value = location;
            cmd.Parameters.Add("@Year", System.Data.SqlDbType.Date).Value = year;
            cmd.Parameters.Add("@Website", System.Data.SqlDbType.NVarChar, 250).Value = website;

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
