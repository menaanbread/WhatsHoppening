using Infrastructure_v0;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web_v0._1.Models
{
    public class BeerModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public DateTime Started { get; set; }
        public int YearStarted { get; set; }
        public float ABV { get; set; }
        public int BreweryId { get; set; }
    }

    public interface IBeerRepository
    {

        List<BeerModel> GetBeers();
        bool AddBeer(BeerModel beer);

    }

    public class BeerRepository : IBeerRepository
    {
        public bool AddBeer(BeerModel beer)
        {
            bool wasSuccess = false;

            if (beer.Started.Year == 1)
            {
                beer.Started = new DateTime(beer.YearStarted, 1, 1);
            }

            CreateData newBeer = new CreateNewBeerData(beer.Name, beer.Style, beer.Started, beer.ABV, beer.BreweryId);
            wasSuccess = newBeer.DoInsert();

            return wasSuccess;
        }

        public List<BeerModel> GetBeers()
        {
            List<BeerModel> beers = new List<BeerModel>();
            GetData getBeers = new GetAllBeers();
            DataTable ds = getBeers.Execute().Tables[0];

            foreach (DataRow row in ds.Rows)
            {
                BeerModel beer = new BeerModel()
                {
                    ID = (int) row["ID"],
                    Name = row["Name"].ToString(),
                    Style = row["Style"].ToString(),
                    Started = (DateTime) row["Year"],
                    ABV = (float) Convert.ToDouble(row["ABV"]),
                    BreweryId = (int) row["BreweryID"]
                };
                beers.Add(beer);
            }
            return beers;
        }
    }
}