using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain.Interfaces;
using WhatsHoppening.Domain;

namespace WhatsHoppening.Providers.PersistenceProvider
{
    public class MockedPersistenceProvider : IPersistenceProvider
    {
        public Beer GetBeer(int id)
        {
            throw new NotImplementedException();
        }

        public Beer GetBeer(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveBeer(Beer beer)
        {
            throw new NotImplementedException();
        }

        public IVenue GetBar(int id)
        {
            throw new NotImplementedException();
        }

        public IVenue GetBar(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveBar(IVenue bar)
        {
            throw new NotImplementedException();
        }

        public Brewery GetBrewery(int id)
        {
            throw new NotImplementedException();
        }

        public Brewery GetBrewery(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveBrewery(Brewery brewery)
        {
            throw new NotImplementedException();
        }

        public List<Post> ListPosts()
        {
            throw new NotImplementedException();
        }

        public List<Post> SearchPosts(SearchPostQuery searchPostQuery)
        {
            throw new NotImplementedException();
        }

        public void Post(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
