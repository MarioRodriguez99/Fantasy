using Fantasy.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Literals))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
        public string Name { get; set; } = null!;

        public ICollection<Team>? Teams { get; set; }// Relacion (1 pais tiene N equipos)
        public int TeamsCount => Teams == null ? 0 : Teams.Count();//Propiedad solo lectura, conteo de los Teams dentro de Country
    }                   //Si teams == null conteo = 0 sino Dame el count de Teams
}