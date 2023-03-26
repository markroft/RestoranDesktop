using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDesktopApp.Modules
{
    public class Menu
    {
        public int id { get; set; }

        public string nomi { get; set; }

        public int narxi { get; set; }
        
        public int TaomTuri { get; set; }

        public List<Buyurtmalar> Buyurtmalars { get; set; }

        public Menu()
        {
            Buyurtmalars = new List<Buyurtmalar>();
        }
    }
}
