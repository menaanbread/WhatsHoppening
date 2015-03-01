using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_v0
{
    public class CreatePost : CreateData
    {
        #region " Declartions - parameters "

        private int accountId;
        private int beerId;
        private int barId;
        private byte rating;
        private string description;
        private DateTime timeStamp;

        #endregion

        #region " Constants "

        const string PROC_NAME = "dbo.AddPost";

        #endregion

        #region " Constructor "

        public CreatePost(int accountId, int beerId, int barId, byte rating, string description, DateTime timeStamp)
        {
            this.accountId = accountId;
            this.beerId = beerId;
            this.barId = barId;
            this.rating= rating;
            this.description = description;
            this.timeStamp = timeStamp;
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

            cmd.Parameters.Add("@AccountId", System.Data.SqlDbType.Int).Value = accountId;
            cmd.Parameters.Add("@BeerId", System.Data.SqlDbType.Int).Value = beerId;
            cmd.Parameters.Add("@BarId", System.Data.SqlDbType.Int).Value = barId;
            cmd.Parameters.Add("@Rating", System.Data.SqlDbType.TinyInt).Value = rating;
            cmd.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 500).Value = description;
            cmd.Parameters.Add("@TimeStamp", System.Data.SqlDbType.DateTime).Value = timeStamp;

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
