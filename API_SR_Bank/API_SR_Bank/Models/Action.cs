using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_SR_Bank.Models
{
    public class Action
    {
        public int Id { get; set; }
        public float Retrait { get; set; }
        public float Depot { get; set; }
        public virtual Client Client { get; set; }
        public virtual int ClientId { get; set; }
    }
}
