using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CsharpCamada.API.Models
{
    [Table("Posto")]
    public partial class Posto
    {
        public Posto()
        {
            TiposDeCombustivels = new HashSet<TiposDeCombustivel>();
        }

        [Key]
        [Column("pos_id")]
        public int PosId { get; set; }
        [Column("pos_nome")]
        [StringLength(255)]
        [Unicode(false)]
        public string? PosNome { get; set; }
        [Column("pos_cidade")]
        [StringLength(255)]
        [Unicode(false)]
        public string? PosCidade { get; set; }
        [Column("pos_endereco")]
        [StringLength(255)]
        [Unicode(false)]
        public string? PosEndereco { get; set; }

        [InverseProperty(nameof(TiposDeCombustivel.Pos))]
        public virtual ICollection<TiposDeCombustivel> TiposDeCombustivels { get; set; }
    }
}
