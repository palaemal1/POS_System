using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class UpdateInventoryTransactionDTO
    {
        public Guid productId { get; set; }
        public int? qtyChange { get; set; }
        public string? transactionType { get; set; }
        public Guid referenceId { get; set; }
        public bool? activeFlag { get; set; }
        public string? updatedBy { get; set; }
        public DateTime updateDate { get; set; } = DateTime.UtcNow;
    }
}
