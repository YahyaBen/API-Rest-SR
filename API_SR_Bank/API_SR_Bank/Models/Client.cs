using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_SR_Bank.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public float Solde { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
    }
}
