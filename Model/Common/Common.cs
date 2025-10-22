using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Common
    {
        public DateTime? Created_at { get; set; } = DateTime.UtcNow;
    }
}
