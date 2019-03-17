namespace model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contant")]
    public partial class Contant
    {
        public int Id { get; set; }

        public string Tittle { get; set; }

        [Column(TypeName = "ntext")]
        public string Text { get; set; }
    }
}
