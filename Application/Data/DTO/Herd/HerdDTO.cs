using Applicattion.Data.DTO.SpecieBreed;

namespace Applicattion.Data.DTO.Herd
{
    public class HerdDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public SpecieDTO Specie { get; set; }
    }
}
