using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Model.Common;
namespace Model.Entities
{
    public class InventoryTransactions:CommonCreated
    {
        [Key]
        public Guid TransactionId { get; set; }
        public string? ProductId { get; set; }
        public int QtyChange { get; set; }
        public string? TransactionType { get; set; }
        

    }
}
