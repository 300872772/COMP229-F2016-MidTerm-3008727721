namespace COMP229_F2016_MidTerm_3008727721.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TodoContext1 : DbContext
    {
        public TodoContext1()
            : base("name=TodoContext1")
        {
        }

        public virtual DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
