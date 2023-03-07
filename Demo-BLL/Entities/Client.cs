using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Entities
{
    public class Client : IClient
    {
        public int idClient { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string? adresse { get; set; }
    }
}
