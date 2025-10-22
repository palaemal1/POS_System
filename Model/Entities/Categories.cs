using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Model.Common;
namespace Model.Entities
{
    public class Categories:CommonCreated
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? CategoryCode { get; set; }
    }
}
