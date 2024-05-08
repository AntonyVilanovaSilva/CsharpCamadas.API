using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CsharpCamada.API.Models
{
    public partial class Motoristum
    {
        [Key]
        [Column("mot_id")]
        public int MotId { get; set; }
        [Column("mot_nome")]
        [StringLength(255)]
        [Unicode(false)]
        public string? MotNome { get; set; }
        [Column("mot_idade")]
        public int? MotIdade { get; set; }
        [Column("vei_id")]
        public int? VeiId { get; set; }

        [ForeignKey(nameof(VeiId))]
        [InverseProperty(nameof(Veiculo.Motorista))]
        public virtual Veiculo? Vei { get; set; }
    }
}
