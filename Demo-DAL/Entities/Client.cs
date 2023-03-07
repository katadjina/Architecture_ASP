using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Entities
{
    public class Client : IClient
    {
        //INTEGER
        public int idClient { get; set; }
        //NVARCHAR(255)
        public string email { get; set; }
        //NVARCHAR(32)
        public string pass { get; set; }
        //NVARCHAR(50)
        public string nom { get; set; }
        //NVARCHAR(50)
        public string prenom { get; set; }
        //NVARCHAR(MAX) NULL
        public string? adresse { get; set; }
    }
}
