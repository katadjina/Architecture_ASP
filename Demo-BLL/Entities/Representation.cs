using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Entities
{
    public class Representation : IRepresentation
    {
        public int idRepresentation { get; set; }
        public DateTime dateheureRepresentation { get; set; }
        public int idSpectacle { get; set; }
        public Spectacle spectacle { get; set; }
    }
}
