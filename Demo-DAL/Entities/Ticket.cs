using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Entities
{
    public class Ticket : ITicket
    {
        public int idTicket { get; set; }
        public DateTime dateTicket { get; set; }
        public int idType { get; set; }
        public int idRepresentation { get; set; }
        public int idClient { get; set; }
    }
}
