using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_v0
{
    public class CreateNewBeerData : CreateData
    {
        #region " Declartions - parameters "

        private string name;
        private string style;
        private DateTime year;
        private float abv;
        private int breweryId;

        #endregion

        #region " Constants "

        const string PROC_NAME = "dbo.AddBeer";

        #endregion

        #region " Constructor "

        public CreateNewBeerData(string name, string style, DateTime year, float abv, int breweryId)
        {
            this.name = name;
            this.style = style;
            this.year = year;
            this.abv = abv;
            this.breweryId = breweryId;
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
            cmd.Parameters.Add("@Style", System.Data.SqlDbType.NVarChar, 50).Value = style;
            cmd.Parameters.Add("@Year", System.Data.SqlDbType.Date).Value = year;
            cmd.Parameters.Add("@ABV", System.Data.SqlDbType.Float).Value = abv;
            cmd.Parameters.Add("@BreweryID", System.Data.SqlDbType.Int).Value = breweryId;

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
