using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDatabaseLibrary.Models
{
    public class ToDoModel
    {
        [Key ,Required, NotNull]
        public int Id { get; set; }
        [Required, NotNull]
        public string Content { get; set; }
        [Required]
        public bool IsDone { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
