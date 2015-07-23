using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSupport.Models
{
    public interface ISecureModel
    {    
        // Need a generic way of returning Id
        int Id { get; set; }

        // Needed to verify a user has access to object
        string GetUserId();
    }
}