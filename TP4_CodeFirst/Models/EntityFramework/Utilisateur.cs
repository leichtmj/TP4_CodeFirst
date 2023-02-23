using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP4_CodeFirst.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    public class Utilisateur
    {
        [Key]
        [ForeignKey("utl_id")]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("utl_nom")]
        [StringLength(50)]
        public string Nom { get; set; } = null!;

        [Column("utl_prenom")]
        [StringLength(50)]
        public string Prenom { get; set; }

        [Column("utl_mobile", TypeName = "char(10)")]
        public string Mobile { get; set; }

        [Column("utl_mail")]
        [StringLength(100)]
        public string Mail { get; set; } = null!;


        [Column("utl_pwd")]
        [StringLength(64)]
        public string Pwd { get; set; } = null!;

        [Column("utl_rue")]
        [StringLength(200)]
        public string Rue { get; set; }

        [Column("utl_cp", TypeName = "char(5)")]
        public string CodePostal { get; set; }

        [Column("utl_ville")]
        [StringLength(50)]
        public string Ville { get; set; }

        [Column("utl_pays")]
        [StringLength(50)]
        public string Pays { get; set; } = "France";

        [Column("utl_latitude", TypeName = "real")]
        public float Latitude { get; set; }


        [Column("utl_latitude", TypeName = "real")]
        public float Longitude { get; set; }


        [Column("utl_datecreation", TypeName = "Date")]
        public DateTime DateCreation { get; set; } = DateTime.Now;


        [ForeignKey("Notation")]
        [InverseProperty("UtilisateurNotant")]
        public virtual Notation NotesUtilisateur { get; set; } = null!;
    }
}
