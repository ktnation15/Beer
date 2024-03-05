using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer
{
    public class BeersRepository : IBeersRepository
    {
        private int _nextId = 6;
        private List<Beer> _beers = new()
        {
            new Beer { Id = 1, Name = "Westvleteren XII", Abv = 10.2},
            new Beer { Id = 2, Name = "Russian River Pliny the Elder", Abv = 8.0},
            new Beer { Id = 3, Name = "The Alchemist Heady Topper", Abv = 8.0},
            new Beer { Id = 4, Name = "Rochefort Trappistes 10", Abv = 11.3},
            new Beer { Id = 5, Name = "Guinness Draught", Abv = 4.2}
        };
        public List<Beer> GetBeers(string? nameStart = null, string? sortby = null)
        {
            List<Beer> result = new List<Beer>(_beers);

            if (nameStart != null)
            {
                //result.Remove(b => !b.Title.StartsWith(titleStart));
                result = result.FindAll(b => b.Name.StartsWith(nameStart));
            }
            if (sortby != null)
            {
                switch (sortby)
                {
                    case "name":
                        result.Sort((b1, b2) => b1.Name.CompareTo(b2.Name));
                        break;
                    case "abv":
                        result.Sort((b1, b2) => b1.Abv.CompareTo(b2.Abv));
                        break;
                }
            }
            return result;
        }
        public Beer? GetById(int id)
        {
            return _beers.Find(beer => beer.Id == id);
        }
        public Beer AddBeer(Beer beer)
        {
            beer.Id = _nextId++;
            _beers.Add(beer);
            return beer;
        }
        //public Beer? GetBeer(int id) - Se GetById
        //{
        //    return _beers.Find(b => b.Id == id);
        //}

        public Beer? DeleteBeer(int id)
        {
            Beer? beer = _beers.Find(b => b.Id == id);
            if (beer != null)
            {
                _beers.Remove(beer);
            }
            return beer;
        }
        public Beer? UpdateBeers(int Id, Beer data)
        {
            Beer? beerToUpdate = _beers.Find(b => b.Id == Id);
            if (beerToUpdate != null)
            {
                beerToUpdate.Name = data.Name;
                beerToUpdate.Abv = data.Abv;
            }
            return beerToUpdate;
        }

    }
}