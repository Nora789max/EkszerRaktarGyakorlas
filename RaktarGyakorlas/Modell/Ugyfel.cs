using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace RaktarGyakorlas.Modell
{
    public class Ugyfel
    {
        public Ugyfel() { }

        public Ugyfel(string row)
        {
            var values = row.Split(';');
            Id = int.Parse(values[0]);
            Name = values[1];
            Email = values[2];
            Phone = values[3];
            Address = values[4];
        }

        public Ugyfel(string name, string email, string phone, string address) : this(name)
        {
            Email = email;
            Phone = phone;
            Address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";

        public override string? ToString()
        {
            return $"{Id}, Név: {Name}, Email: {Email}, Telefonszám: {Phone}, Lakcím: {Address}";
        }
    }
}
