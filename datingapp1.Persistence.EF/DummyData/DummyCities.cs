using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Domain.Entities;

namespace datingapp1.Persistence.EF.DummyData
{
    public class DummyCities
    {
        public static List<City> Get() {

            City c1 = new City() {
                Name = "Gddansk"
            };

            City c2 = new City() {
                Name = "Warszawa"
            };

            City c3 = new City() {
                Name = "Krakow"
            };

            List<City> p = new List<City>();
            p.Add(c1);
            p.Add(c2);
            p.Add(c3);

            return p;
        }
    }
}