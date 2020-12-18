using System;
using System.Collections.Generic;
using System.Text;

namespace HerdManagement.Domain.Common
{
    public class ValidationResult
    {
        public bool isValid { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
