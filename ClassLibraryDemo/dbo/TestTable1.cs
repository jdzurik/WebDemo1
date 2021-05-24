using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ClassLibraryDemo.dbo
{
    [Keyless]
    [Table("TestTable1")]
    public partial class TestTable1
    {
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(90)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime InsertDate { get; set; }
    }
}
