using System;
using System.Collections.Generic;

namespace Game21.Models
{
    public class ApplicationResult
    {
        public virtual bool Success { get; set; } = true;
        
        public virtual IEnumerable<string> ErrorMessages { get; set; }
        
        public virtual IEnumerable<string> SuccessMessages { get; set; }
        
        public Object Result { get; set; }
        
    }
}