using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Infrastructure_v0
{
    public abstract class CreateData
    {

        #region " Declarations "

        private SqlCommand cmd;

        #endregion

        #region " Properties "

        internal SqlCommand Cmd
        {
            set
            {
                cmd = value;
            }
        }

        #endregion

        #region " Virtual methods "

        /// <summary>
        /// Using cmd object, execute the query to the database
        /// </summary>
        /// <returns>Success indicator boolean</returns>
        public virtual bool DoInsert()
        {
            bool complete = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbBeer"].ToString()))
                {
                    con.Open();
                    cmd.Connection = con;

                    int i = cmd.ExecuteNonQuery();
                    complete = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return complete;
        }

        /// <summary>
        /// Virtual MakeCommand object - to be inherited
        /// </summary>
        /// <returns>new SqlCommand object</returns>
        public virtual SqlCommand MakeCommand()
        {
            return new SqlCommand();
        }

        #endregion

    }
}
