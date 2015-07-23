namespace SimpleSupport.Models
{    
    public class Deduction : ISecureModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        // Foreign keys
        public virtual Party Party { get; set; }
        public virtual DeductionType DeductionType { get; set; }

        // Interface
        public string GetUserId() { return Party.Case.AspNetUserId; }  
    }
}
