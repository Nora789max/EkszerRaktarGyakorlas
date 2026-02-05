using RaktarGyakorlas.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktarGyakorlas.Repository
{
    public class UgyfelNyilvantartas
    {
        private List<Ugyfel> ugyfelLista;

        public UgyfelNyilvantartas()
        {
            ugyfelLista = new List<Ugyfel>();
            Seeder();
        }
        public void Seeder()
        {
            var sorok = File.ReadAllLines(@"D:\go_project\Python\óraigyakorlás\0202\RaktarGyakorlas\Data\ugyfelek.csv");
            foreach (var sor in sorok)
            {
               ugyfelLista.Add(new Ugyfel(sor));
            }
        }
        public void UjUgyfelFelvesz(string name, string email, string phone, string address)
        {
            var maxId = 1;
            if (ugyfelLista.Any())
            {
                maxId = ugyfelLista.Max(x => x.Id) + 1;
            }
            ugyfelLista.Add(new Ugyfel(maxId, name, email, phone, address));
        
        }
        public List<Ugyfel> OsszesUgyfelLekerdez()
        {
            return ugyfelLista;
        }

        public Ugyfel? UgyfelLekerdezIdAlapjan(int id)
        {
            return ugyfelLista.FirstOrDefault(x => x.Id == id);
        }
        public Ugyfel? UgyfelLekerdezNameAlapjan(string name)
        {
            return ugyfelLista.FirstOrDefault(x => x.Name.Contains(name));
        }
        public bool UgyfelTorleseIdAlapjan(int id)
        {
            var ugyfel = UgyfelLekerdezIdAlapjan(id);
            if (ugyfel != null)
            {
                ugyfelLista.Remove(ugyfel);
                return true;
            }
            return false;

        }
        public bool UgyfelModositasaIdAlapjan(int id, string name, string email, string phone, string address)
        {
            var ugyfel = UgyfelLekerdezIdAlapjan(id);
            if (ugyfel != null)
            {
                ugyfel.Name = name;
                ugyfel.Email = email;
                ugyfel.Phone = phone;
                ugyfel.Address = address;
                return true;
            }
            return false;
        }
    }
}
