using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure_v0;
using System.Data;

namespace Web_v0._1.Models
{
    public class BreweryModel
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Opened { get; set; }
        public int YearOpened { get; set; }
        public string Website { get; set; }
    }

    public interface IBreweryRepository
    {

        bool Add(BreweryModel brewery);
        List<BreweryModel> GetBreweries();

    }

    public class BreweryRepository : IBreweryRepository
    {

        public bool Add(BreweryModel brewery)
        {
            bool wasSuccess = false;

            if (brewery.Opened.Year == 1){
                brewery.Opened = new DateTime(brewery.YearOpened, 1, 1);
            } 

            CreateData newBrewery = new CreateNewBreweryData(brewery.Name, brewery.Location, brewery.Opened, brewery.Website);
            wasSuccess = newBrewery.DoInsert();

            return wasSuccess;
        }

        public List<BreweryModel> GetBreweries()
        {
            List<BreweryModel> breweries = new List<BreweryModel>();

            GetData getBreweries = new GetAllBreweriesData();
            foreach (DataRow row in getBreweries.Execute().Tables[0].Rows)
            {
                breweries.Add(ParseDataSetToBreweryModel(row));
            }

            return breweries;
        }

        private BreweryModel ParseDataSetToBreweryModel(DataRow rowBrewery)
        {
            try
            {
                return new BreweryModel()
                {
                    ID = int.Parse(rowBrewery["ID"].ToString()),
                    Name = rowBrewery["Name"].ToString(),
                    Location = rowBrewery["Location"].ToString(),
                    Opened = Convert.ToDateTime(rowBrewery["Year"].ToString()),
                    Website = rowBrewery["Website"].ToString()
                };
            }
            catch
            {
                return new BreweryModel();
            }
        }
    }

}