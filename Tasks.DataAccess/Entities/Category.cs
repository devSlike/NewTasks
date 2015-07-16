using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tasks.DataAccess.Infrastructure;

namespace Tasks.DataAccess.Entities
{
    public class Category : IEntity
    {
        public Category()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required, Display(Name = "Category name")]
        public string CategoryName { get; set; }
        public string SecondName { get; set; }

        public virtual HashSet<Task> Tasks { get; set; }
    }
}
