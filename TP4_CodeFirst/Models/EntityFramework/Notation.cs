using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP4_CodeFirst.Models.EntityFramework
{

    [Table("t_j_notation_not")]

    public class Notation
    {
        [Key]
        [ForeignKey("utl_id")]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }


        [Key]
        [ForeignKey("flm_id")]
        [Column("flm_id")]
        public int FilmId { get; set; }



        [Column("not_note")]
        [Range(0, 5)]
        public int? Note { get; set; } = null!;


        [InverseProperty("FilmNote")]
        public virtual ICollection<Utilisateur> UtilisateurNotant { get; } = new List<Utilisateur>();

        [InverseProperty("NotesFilm")]
        public virtual ICollection<Film> FilmNote { get; } = new List<Film>();

    }
}
