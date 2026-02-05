using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace RaktarGyakorlas.Modell
{
    public class Aru
    {
        public Aru() { }
        public Aru(int id, string title, string description, decimal price)
        {
            Id = id;
            Title = title ;
            Description = description;
            Price = price;
        }
        public Aru(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
        }
        public Aru(string row)
        {
            var values = row.Split(';');
            Id = int.Parse(values[0]);
            Title = values[1];
            Description = values[2];
            Price = decimal.Parse(values[3]);
        }
        public override string? ToString()
        {
            return $"{Id}, Név - {Title}, Leírás - {Description}, Ár - {Price} ft";
        }
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
