namespace WpfApp2.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Researches : IEntity
    { 
        public int Id { get; set; }

        public int IdMaterial { get; set; }

        public int IdLaborant { get; set; }

        public string Result { get; set; }

        public virtual Laborants Laborants { get; set; }

        public virtual Materials Materials { get; set; }
    }
}
