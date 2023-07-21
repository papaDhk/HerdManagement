using HerdManagement.Domain.Reproduction.Entities;

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
