using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaktarGyakorlas.Modell;

namespace RaktarGyakorlas.Repository
{
    public class AruNyilvantartas
    {
        private List<Aru> aruLista;

        public AruNyilvantartas()
        {
            aruLista = new List<Aru>();
            Seeder();
        }
        public void Seeder()
        {
            var sorok = File.ReadAllLines(@"D:\go_project\Python\óraigyakorlás\0202\RaktarGyakorlas\Data\ekszerek.csv");
            foreach (var sor in sorok)
            {
                aruLista.Add(new Aru(sor));
            }
        }
        public void UjaruFelvesz(string title, string description, decimal price)
        {
            var maxId = 1;
            if (aruLista.Any())
            {
                maxId = aruLista.Max(x => x.Id)+1;
            }
            aruLista.Add(new Aru(maxId, title, description, price));
            
        }
        public List<Aru> OsszesAruLekerdez() 
        {
            return aruLista;
        }

        public Aru? AruLekerdezIdAlapjan(int id) 
        {
            return aruLista.FirstOrDefault(x => x.Id == id);
        }
        public Aru? AruLekerdezTitleAlapjan(string title) 
        {
            return aruLista.FirstOrDefault(x => x.Title.Contains(title));
        }
        public bool AruTorleseIdAlapjan(int id) 
        {
            var aru = AruLekerdezIdAlapjan(id);
            if (aru != null)
            {
                aruLista.Remove(aru);
                return true;
            }
            return false;

        }
        public bool AruModositasaIdAlapjan(int id, string title, string description, decimal price) 
        {
            var aru = AruLekerdezIdAlapjan(id);
            if (aru != null)
            {
                aru.Title = title;
                aru.Description = description;
                aru.Price = price;
                return true;
            }
            return false;
        }

    }
}
