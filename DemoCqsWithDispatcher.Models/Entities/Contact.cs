using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCqsWithDispatcher.Models.Entities
{
    public class Contact
    {
        internal Contact(int id, string nom, string prenom)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
