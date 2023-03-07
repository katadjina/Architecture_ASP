using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.SpectacleViewModels
{
    public class SpectacleEditForm
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [DisplayName("Spectacle : ")]
        public string nom { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(4000)]
        [DisplayName("Description (max. 4000 caractères) : ")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
    }
}
