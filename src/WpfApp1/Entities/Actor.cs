using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entities
{
    [Table("actor")]
    [SugarTable("actor")]
    internal class Actor
    {
        [Key]
        [Column("actor_id")]
        [SugarColumn(ColumnName = "actor_id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column("first_name")]
        [SugarColumn(ColumnName = "first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        [SugarColumn(ColumnName = "last_name")]
        public string LastName { get; set; }

        [Column("last_update")]
        [SugarColumn(ColumnName = "last_update")]
        public DateTime LastUpdate { get; set; }
    }
}
