using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.SpectacleViewModels
{
    public class SpectacleDelete
    {
        [DisplayName("Identifiant : ")]
        [ScaffoldColumn(false)]
        public int idSpectacle { get; set; }
        [DisplayName("Spectacle")]
        public string nom { get; set; }
    }
}
