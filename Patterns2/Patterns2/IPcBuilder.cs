namespace Patterns2;

interface IPcBuilder
{
    void AddRam(double clock, int size);
    void AddGpu(double clock, int vram);
    void AddCpu(double clock, int cores, int threads);

    Pc Build();
}