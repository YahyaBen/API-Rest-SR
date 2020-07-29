using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ActionsData
    {
        public int Id { get; set; }
        public float Retrait { get; set; }
        public float Depot { get; set; }
        public virtual ClientData Client { get; set; }
        public virtual int ClientId { get; set; }
    }
}
