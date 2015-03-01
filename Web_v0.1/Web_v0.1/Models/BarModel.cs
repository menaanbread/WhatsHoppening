using Infrastructure_v0;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web_v0._1.Models
{
    public class BarModel
    {
        public enum BarType
        {
            Type = 0,
            Pub = 1,
            Bar = 2,
            Home = 3,
            Club = 4
        };

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public BarType Type { get; set; }
        public string Website { get; set; }
    }

    public interface IBarRepository
    {
        List<BarModel> GetBars();
        bool AddBar(BarModel bar);
    }

    public class BarRepository : IBarRepository
    {

        public List<BarModel> GetBars()
        {
            List<BarModel> bars = new List<BarModel>();
            GetData getBars = new GetAllBars();
            DataTable dt = getBars.Execute().Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                BarModel bar = new BarModel()
                {
                    ID = (int)row["ID"],
                    Name = row["Name"].ToString(),
                    Address = row["Address"].ToString(),
                    Type = (BarModel.BarType) Enum.Parse(typeof(BarModel.BarType), row["Type"].ToString()),
                    Website = row["Website"].ToString()
                };
                bars.Add(bar);
            }
            return bars;
        }

        public bool AddBar(BarModel bar)
        {
            bool wasSuccess = false;
            
            CreateData newBar = new CreateNewBarData(bar.Name, bar.Address, (int)bar.Type, bar.Website);
            wasSuccess = newBar.DoInsert();

            return wasSuccess;
        }
    }
}