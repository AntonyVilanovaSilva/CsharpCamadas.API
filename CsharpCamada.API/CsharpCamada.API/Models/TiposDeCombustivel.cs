using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CsharpCamada.API.Models
{
    [Table("TiposDeCombustivel")]
    public partial class TiposDeCombustivel
    {
        [Key]
        [Column("Tipo_id")]
        public int TipoId { get; set; }
        [Column("Tipo_nome")]
        [StringLength(255)]
        [Unicode(false)]
        public string? TipoNome { get; set; }
        [Column("Tipo_valor")]
        public double? TipoValor { get; set; }
        [Column("pos_id")]
        public int? PosId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(PosId))]
        [InverseProperty(nameof(Posto.TiposDeCombustivels))]
        public virtual Posto? Pos { get; set; }
    }
}
