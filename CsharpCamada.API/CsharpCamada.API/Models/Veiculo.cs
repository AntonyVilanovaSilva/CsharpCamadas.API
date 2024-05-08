using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CsharpCamada.API.Models
{
    [Table("Veiculo")]
    public partial class Veiculo
    {
        public Veiculo()
        {
            Motorista = new HashSet<Motoristum>();
        }

        [Key]
        [Column("vei_id")]
        public int VeiId { get; set; }
        [Column("vei_nome")]
        [StringLength(255)]
        [Unicode(false)]
        public string? VeiNome { get; set; }
        [Column("vei_placa")]
        [StringLength(255)]
        [Unicode(false)]
        public string? VeiPlaca { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(Motoristum.Vei))]
        public virtual ICollection<Motoristum> Motorista { get; set; }
    }
}
