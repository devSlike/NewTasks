using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Tasks.DataAccess.Infrastructure;

namespace Tasks.DataAccess.Entities
{
    public class SubTask : IEntity
    {
        [Key]
        public int Id { get; set; }

        public bool Completed {get; set;}
        
        [Required, Display(Name = "Text"), DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public int TaskId { get; set; }
        
        public virtual Task Task { get; set; }
    }
}