namespace Domain.Specification
{
    public interface ISpecification
    {
        string Name { get; }
        int? Cpu { get; }
        int? Mother { get; }
        int? Fan { get; }
        int? Ram { get; }
        int? Gpu { get; }
        int? Hdd { get; }
        int? Ssd { get; }
    }
}