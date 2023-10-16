using System;

namespace AwehProductionsVaccineStatus
{
    class VaccineInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public VaccineInfo()
        {
            Id = Guid.NewGuid().ToString();
            var random = new Random();
            var list = new[]
            {
                "Pfizer",
                "Moderna",
                "Johnson & Johnson",
                "AstraZeneca"
            };
            int index = random.Next(list.Length);
            Name = list[index];
        }

        public override string ToString()
        {
            return $"Vaccine ID: {Id}, Name: {Name}";
        }
    }
}
