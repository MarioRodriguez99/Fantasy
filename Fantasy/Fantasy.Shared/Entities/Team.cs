using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Shared.Entities
{
    public class Team
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = null!;

        public string? Image { get; set; }

        public Country Country { get; set; } = null!;//Relacion 1 equipo pertenece a un pais
        public int CountryId { get; set; }
    }
}