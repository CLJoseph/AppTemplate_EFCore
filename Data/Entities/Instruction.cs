using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public enum Instructionstatus { Open, Sent, Overdue, PartPaid, Paid, Cancelled }
    public enum Instructiontype { Invoice,PurchaseOrder,Order,ExpenseRequest }
    public class InstructionItem
    {
        public Guid Id { get; set; }
        public Guid InstructionId { get; set; }
        public string Item { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string Price { get; set; }
        public string Tax { get; set; }
        public string Total { get; set; }
        public string Image { get; set; }
    }
    public  class Instruction:LineId
    {
        public Instruction()
        {
            Items = new List<InstructionItem>();
        }

        public string Code { get; set; }

        public string ReferenceCode { get; set; }
        public string Instructiontype { get; set; }
        public Instructionstatus Status { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }
        public string From { get; set; }
        public string AttentionOf { get; set; }
        public string To { get; set; }
        public string ToEmail { get; set; }
        public string Price { get; set; }
        public string Tax { get; set; }
        public string Total { get; set; }
        // navigation properties   
        public Guid ApplicationUserId { get; set; }
        public List<InstructionItem> Items { get; set; }

    }

}
