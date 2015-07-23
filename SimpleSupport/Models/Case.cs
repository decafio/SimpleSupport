namespace SimpleSupport.Models
{
    using System.Collections.Generic;

    public class Case : ISecureModel
    {
        public Case()
        {
            this.Parties = new HashSet<Party>();
            this.Children = new HashSet<Child>();
        }

        public int Id { get; set; }

        public string CaseNumber { get; set; }

        // Foreign Key (Inside Application Context)
        public string AspNetUserId { get; set; }

        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<Child> Children { get; set; }

        // Interface
        public string GetUserId() { return AspNetUserId; }
    }
}
