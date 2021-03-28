using Domain.Computers;

namespace Application.Commands.BuildComputers.Specifications
{
    public class Specification : ISpecification //pasar a domain y poner un manager
    {
        public Specification(int cpu, int fan, int ram, int gpu, int hdd, int ssd, TypeUse use)
        {
            Cpu = cpu;
            Fan = fan;
            Ram = ram;
            Gpu = gpu;
            Hdd = hdd;
            Ssd = ssd;
            Use = use;
        }

        public int Cpu { get; }
        public int Mother => (int)(Cpu * 0.80);
        public int Fan { get; }
        public int Ram { get; }
        public int Gpu { get; }
        public int Hdd { get; }
        public int Ssd { get; }
        public TypeUse Use { get; }
    }
}
