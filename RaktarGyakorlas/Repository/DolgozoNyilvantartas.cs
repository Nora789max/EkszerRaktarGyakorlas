using RaktarGyakorlas.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RaktarGyakorlas.Repository
{
    internal class DolgozoNyilvantartas
    {
        private List<Dolgozo> dolgozoLista;

        public DolgozoNyilvantartas()
        {
            dolgozoLista = new List<Dolgozo>();
            Seeder();
        }
        public void Seeder()
        {
            var sorok = File.ReadAllLines(@"D:\go_project\Python\óraigyakorlás\0202\RaktarGyakorlas\Data\dolgozok.csv");
            foreach (var sor in sorok)
            {
                dolgozoLista.Add(new Dolgozo(sor));
            }
        }
        public void UjDolgozoFelvesz(string name, string email, string phone, string position)
        {
            var maxId = 1;
            if (dolgozoLista.Any())
            {
                maxId = dolgozoLista.Max(x => x.Id) + 1;
            }
            dolgozoLista.Add(new Dolgozo(maxId, name, email, phone, position));

        }
        public List<Dolgozo> OsszesDolgozoLekerdez()
        {
            return dolgozoLista;
        }

        public Dolgozo? DolgozoLekerdezIdAlapjan(int id)
        {
            return dolgozoLista.FirstOrDefault(x => x.Id == id);
        }
        public Dolgozo? DolgozoLekerdezNameAlapjan(string name)
        {
            return dolgozoLista.FirstOrDefault(x => x.Name.Contains(name));
        }
        public bool DolgozoTorleseIdAlapjan(int id)
        {
            var dolgozo = DolgozoLekerdezIdAlapjan(id);
            if (dolgozo != null)
            {
                dolgozoLista.Remove(dolgozo);
                return true;
            }
            return false;

        }
        public bool DolgozoModositasaIdAlapjan(int id, string name, string email, string phone, string position)
        {
            var dolgozo = DolgozoLekerdezIdAlapjan(id);
            if (dolgozo != null)
            {
                dolgozo.Name = name;
                dolgozo.Email = email;
                dolgozo.Phone = phone;
                dolgozo.Position = position;
                return true;
            }
            return false;
        }
    }
}
