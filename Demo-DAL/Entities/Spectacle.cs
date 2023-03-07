using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Entities
{
    public class Spectacle : ISpectacle
    {
        //INTEGER
        public int idSpectacle { get; set; }
        //NVARCHAR(50)
        public string nom { get; set; }
        //NVARCHAR(MAX)
        public string description { get; set; }
    }
}
