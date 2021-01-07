using HerdManagement.Domain.Reproduction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicattion.Data.Messages
{
    public class ReproductionCreationResponse
    {
        public bool IsSuccessful { get; set; }

        public bool WasMaleAdult { get; set; }

        public bool CouldFemaleBeMated { get; set; }

        public Reproduction Reproduction { get; set; }
    }
}
