namespace SimpleSupport.Models
{
    public class Income
    {
        public int IncomeId { get; set; }
        public decimal Amount { get; set; }
                
        // Foreign keys
        public virtual Party Party { get; set; }
        public virtual IncomeType IncomeType { get; set; }
    }
}
