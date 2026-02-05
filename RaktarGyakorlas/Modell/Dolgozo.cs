using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RaktarGyakorlas.Modell
{
    public class Dolgozo
    {

        public Dolgozo() { }

        public Dolgozo(string row)
        {
            var values = row.Split(';');
            Id = int.Parse(values[0]);
            Name = values[1];
            Email = values[2];
            Phone = values[3];
            Position = values[4];
        }
        public Dolgozo(string name, string email, string phone, string position)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Position = position;
        }

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Position { get; set; } = "";

        public override string? ToString()
        {
            return $"{Id}, Név: {Name}, Email: {Email}, Telefonszám: {Phone}, Pozíció: {Position}";
        }
    }
}
