using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Entities
{
    public class Spectacle : ISpectacle
    {
        private string _nom;
        public int idSpectacle { get; set; }
        public string nom {
            get {
                return _nom;
            }
            set { 
                _nom = value.Trim();
            } 
        }
        public string description { get; set; }

        public IEnumerable<Representation> representations { get; set; }

        public Spectacle(int id, string nom, string desc)
        {
            if (string.IsNullOrWhiteSpace(nom)) throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(desc)) throw new ArgumentNullException();
            idSpectacle = id;
            this.nom = nom;
            description = desc;
        }
        public Spectacle(Demo_DAL.Entities.Spectacle dto):this(dto.idSpectacle, dto.nom, dto.description)
        {

        }
    }
}
