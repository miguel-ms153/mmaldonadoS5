using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace mmaldonadoS5.Models
{
    [Table ("persona")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        
    }
}
