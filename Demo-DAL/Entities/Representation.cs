using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Entities
{
    public class Representation : IRepresentation
    {
        public int idRepresentation { get; set; }
        public DateTime dateRepresentation { get; set; }
        public TimeSpan heureRepresentation { get; set; }
        public int idSpectacle { get; set; }
    }
}
