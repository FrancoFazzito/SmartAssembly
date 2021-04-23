using Domain.Computers;

namespace Application.Computers.Commands.Build
{
    public class Specification : ISpecification
    {
        public Specification(int cpu, int fan, int ram, int gpu, int hdd, int ssd, string use)
        {
            Cpu = cpu;
            Fan = fan;
            Ram = ram;
            Gpu = gpu;
            Hdd = hdd;
            Ssd = ssd;
            TypeUse = use;
        }

        public int Cpu { get; }
        public int Mother => (int)(Cpu * 0.80);
        public int Fan { get; }
        public int Ram { get; }
        public int Gpu { get; }
        public int Hdd { get; }
        public int Ssd { get; }
        public string TypeUse { get; }
    }
}