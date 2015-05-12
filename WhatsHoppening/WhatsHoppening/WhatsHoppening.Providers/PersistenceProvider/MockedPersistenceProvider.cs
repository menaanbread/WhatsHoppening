using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain.Interfaces;
using WhatsHoppening.Domain;
using WhatsHoppening.Providers.UserManager;

namespace WhatsHoppening.Providers.PersistenceProvider
{
    public class MockedPersistenceProvider : IPersistenceProvider
    {
        private static List<Beer> beers = null;
        private static List<IVenue> bars = null;
        private static List<Brewery> breweries = null;
        private static List<Post> posts = null;

        public MockedPersistenceProvider()
        {
            beers = new List<Beer>();
            bars = new List<IVenue>();
            breweries = new List<Brewery>();
            posts = new List<Post>();

            var userManager = new MockedUserManager();

            var styles = new List<BeerStyle>();
            styles.Add(new BeerStyle() { Id = Guid.NewGuid(), Name = "Bitter", Description = string.Empty });
            styles.Add(new BeerStyle() { Id = Guid.NewGuid(), Name = "IPA", Description = string.Empty });
            styles.Add(new BeerStyle() { Id = Guid.NewGuid(), Name = "Porter", Description = string.Empty });
            styles.Add(new BeerStyle() { Id = Guid.NewGuid(), Name = "Barley Wine", Description = string.Empty });
            styles.Add(new BeerStyle() { Id = Guid.NewGuid(), Name = "Lager", Description = string.Empty });
            styles.Add(new BeerStyle() { Id = Guid.NewGuid(), Name = "Mild", Description = string.Empty });
            styles.Add(new BeerStyle() { Id = Guid.NewGuid(), Name = "Tripel", Description = string.Empty });
            styles.Add(new BeerStyle() { Id = Guid.NewGuid(), Name = "Dunkel", Description = string.Empty });

            // --------- Beers ---------
            beers.Add(new Beer() { Id = 1, Name = "Barnsley Bitter", Abv = 4.0, Style = styles[0] });
            beers.Add(new Beer() { Id = 2, Name = "Punk IPA", Abv = 5.0, Style = styles[1] });
            beers.Add(new Beer() { Id = 3, Name = "Smog Rocket", Abv = 5.5, Style = styles[2] });
            beers.Add(new Beer() { Id = 4, Name = "Anchor Barley Wine", Abv = 8.2, Style = styles[3] });
            beers.Add(new Beer() { Id = 5, Name = "Cruz Campo", Abv = 4.0, Style = styles[4] });
            beers.Add(new Beer() { Id = 6, Name = "Born to be Mild", Abv = 4.0, Style = styles[5] });
            beers.Add(new Beer() { Id = 7, Name = "Tripel Karemeliet", Abv = 9.1, Style = styles[6] });
            beers.Add(new Beer() { Id = 8, Name = "Erdinger Dunkel", Abv = 5.5, Style = styles[7] });
            beers.Add(new Beer() { Id = 9, Name = "Sierra Nevada Pale Ale", Abv = 5.4, Style = styles[1] });
            beers.Add(new Beer() { Id = 10, Name = "Boston Lager", Abv = 5.1, Style = styles[4] });
            beers.Add(new Beer() { Id = 11, Name = "Tally ho", Abv = 7.2, Style = styles[3] });
            beers.Add(new Beer() { Id = 12, Name = "Lees Bitter", Abv = 4.0, Style = styles[0] });

            // --------- Bars ---------
            bars.Add(new Bar("www.grad.com", "GradBar", "Lancaster", BarStyle.Pub, Country.UnitedKingdom) { Id = 1 });
            bars.Add(new Bar("www.brewdog.com", "Brewdog Manchester", "Manchester", BarStyle.Bar, Country.UnitedKingdom) { Id = 2 });
            bars.Add(new HomeVenue(BarStyle.Home) { Id = 3 });
            bars.Add(new HomeVenue(BarStyle.MatesHouse) { Id = 4 });
            bars.Add(new Festival() { Location = "Lancaster", Name = "Lancaster beer festival", StartDate = DateTime.Now.AddDays(- 10.0), EndDate = DateTime.Now, Website = "www.lancasterbeerfest.com", Id = 5 });

            // --------- Breweries ---------
            breweries.Add(new Brewery() { Id = 1, Name = "Acorn", Country = Country.UnitedKingdom, Description = string.Empty, Location = "Barnsley", BeersBrewed = new List<Beer>() { beers[0] } });
            breweries.Add(new Brewery() { Id = 2, Name = "Brewdog", Country = Country.UnitedKingdom, Description = string.Empty, Location = "Aberdeen", BeersBrewed = new List<Beer>() { beers[1] } });
            breweries.Add(new Brewery() { Id = 3, Name = "Beavertown", Country = Country.UnitedKingdom, Description = string.Empty, Location = "London", BeersBrewed = new List<Beer>() { beers[2] } });
            breweries.Add(new Brewery() { Id = 4, Name = "Anchor", Country = Country.UnitedStatesOfAmerica, Description = string.Empty, Location = "San Fansisco", BeersBrewed = new List<Beer>() { beers[3] } });
            breweries.Add(new Brewery() { Id = 5, Name = "Cruzcampo", Country = Country.Spain, Description = string.Empty, Location = "Madrid", BeersBrewed = new List<Beer>() { beers[4] } });
            breweries.Add(new Brewery() { Id = 6, Name = "Bank Top", Country = Country.UnitedKingdom, Description = string.Empty, Location = "Bolton", BeersBrewed = new List<Beer>() { beers[5] } });
            breweries.Add(new Brewery() { Id = 7, Name = "Brauerwij Karamel", Country = Country.Belgium, Description = string.Empty, Location = "Ypres", BeersBrewed = new List<Beer>() { beers[6] } });
            breweries.Add(new Brewery() { Id = 8, Name = "Brauerei Erdinger", Country = Country.Germany, Description = string.Empty, Location = "Bielefeld", BeersBrewed = new List<Beer>() { beers[7] } });
            breweries.Add(new Brewery() { Id = 9, Name = "Sierra Nevada", Country = Country.UnitedStatesOfAmerica, Description = string.Empty, Location = "Death Valley", BeersBrewed = new List<Beer>() { beers[8] } });
            breweries.Add(new Brewery() { Id = 10, Name = "Samuel Adams", Country = Country.UnitedStatesOfAmerica, Description = string.Empty, Location = "Boston", BeersBrewed = new List<Beer>() { beers[9] } });
            breweries.Add(new Brewery() { Id = 11, Name = "Adnams", Country = Country.UnitedKingdom, Description = string.Empty, Location = "Southwold", BeersBrewed = new List<Beer>() { beers[10] } });
            breweries.Add(new Brewery() { Id = 12, Name = "J.W. Lees", Country = Country.UnitedKingdom, Description = string.Empty, Location = "Middleton", BeersBrewed = new List<Beer>() { beers[11] } });

            // --------- Posts ---------
            posts.Add(new Post() { Id = 1, Beer = beers[0], Bar = bars[0], TimeStamp = DateTime.Now, User =  userManager.GetUser(1), Rating = 5.0, Content = "THE BEST EVER."});
            posts.Add(new Post() { Id = 2, Beer = beers[2], Bar = bars[1], TimeStamp = DateTime.Now, User = userManager.GetUser(2), Rating = 2.3, Content = "Bat naff really." });
            posts.Add(new Post() { Id = 3, Beer = beers[3], Bar = bars[2], TimeStamp = DateTime.Now, User = userManager.GetUser(3), Rating = 4.2, Content = "Mmm this was good." });
            posts.Add(new Post() { Id = 4, Beer = beers[4], Bar = bars[3], TimeStamp = DateTime.Now, User = userManager.GetUser(4), Rating = 1.0, Content = "Awful, yuck." });
            posts.Add(new Post() { Id = 5, Beer = beers[5], Bar = bars[4], TimeStamp = DateTime.Now, User = userManager.GetUser(5), Rating = 0.0, Content = "I'd rather die." });
            posts.Add(new Post() { Id = 6, Beer = beers[6], Bar = bars[0], TimeStamp = DateTime.Now, User = userManager.GetUser(6), Rating = 4.8, Content = "So close to BB it's untrue." });
            posts.Add(new Post() { Id = 7, Beer = beers[7], Bar = bars[1], TimeStamp = DateTime.Now, User = userManager.GetUser(7), Rating = 4.9, Content = "Me tastebuds are alight." });
            posts.Add(new Post() { Id = 8, Beer = beers[8], Bar = bars[2], TimeStamp = DateTime.Now, User = userManager.GetUser(1), Rating = 3.1, Content = "Pretty decent yo." });
            posts.Add(new Post() { Id = 9, Beer = beers[9], Bar = bars[3], TimeStamp = DateTime.Now, User = userManager.GetUser(2), Rating = 4.0, Content = "Really solidly good beer." });
            posts.Add(new Post() { Id = 10, Beer = beers[1], Bar = bars[4], TimeStamp = DateTime.Now, User = userManager.GetUser(3), Rating = 2.5, Content = "Definition of average." });
            posts.Add(new Post() { Id = 11, Beer = beers[1], Bar = bars[0], TimeStamp = DateTime.Now, User = userManager.GetUser(4), Rating = 1.6, Content = "POOR." });
            posts.Add(new Post() { Id = 12, Beer = beers[0], Bar = bars[1], TimeStamp = DateTime.Now, User = userManager.GetUser(5), Rating = 5.0, Content = "THE BEST EVER." });
            posts.Add(new Post() { Id = 13, Beer = beers[10], Bar = bars[2], TimeStamp = DateTime.Now, User = userManager.GetUser(6), Rating = 3.8, Content = "Could be better, but not bad." });
            posts.Add(new Post() { Id = 14, Beer = beers[11], Bar = bars[3], TimeStamp = DateTime.Now, User = userManager.GetUser(7), Rating = 2.2, Content = "Just a bad beer." });

        }


        public Beer GetBeer(int id)
        {
            return beers.Find(b => b.Id == id);
        }

        public Beer GetBeer(string name)
        {
            return beers.Find(b => b.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public void SaveBeer(Beer beer)
        {
            beers.RemoveAll(b => b.Id == beer.Id);
            beers.Add(beer);
        }

        public IVenue GetBar(int id)
        {
            return bars.Find(b => b.Id == id);
        }

        public IVenue GetBar(string name)
        {
            return bars.Find(b => b.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public void SaveBar(IVenue bar)
        {
            bars.RemoveAll(b => b.Id == bar.Id);
            bars.Add(bar);
        }

        public Brewery GetBrewery(int id)
        {
            return breweries.Find(b => b.Id == id);
        }

        public Brewery GetBrewery(string name)
        {
            return breweries.Find(b => b.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public void SaveBrewery(Brewery brewery)
        {
            breweries.RemoveAll(b => b.Id == brewery.Id);
            breweries.Add(brewery);
        }

        public List<Post> ListPosts()
        {
            return posts;
        }

        public List<Post> SearchPosts(SearchPostQuery searchPostQuery)
        {
            throw new NotImplementedException();
        }

        public void Post(Post post)
        {
            posts.Add(post);
        }
    }
}
