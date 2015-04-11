namespace SimpleSupport.Models
{    
    public class Deduction
    {
        public int DeductionId { get; set; }
        public decimal Amount { get; set; }

        // Foreign keys
        public virtual Party Party { get; set; }
        public virtual DeductionType DeductionType { get; set; }
    }
}
