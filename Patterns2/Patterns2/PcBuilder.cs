namespace Patterns2;

class PcBuilder : IPcBuilder
{
    private Ram? _ram;
    private Gpu? _gpu;
    private Cpu? _cpu;

    public PcBuilder()
    {
    }

    public void AddRam(double clock, int size)
    {
        if (clock < 0)
        {
            throw new InvalidOperationException("Clock cannot be less than 0.");
        }

        // validation

        _ram = new Ram { Frequency = clock, Size = size };
    }

    public void AddGpu(double clock, int vram)
    {
        // validation
        _gpu = new Gpu { Frequency = clock, Vram = vram };
    }

    public void AddCpu(double clock, int cores, int threads)
    {
        _cpu = new Cpu { BaseClock = clock, Cores = cores, Threads = threads };
    }

    public Pc Build()
    {
        if (_ram is null)
        {
            throw new InvalidOperationException("Ram cannot be null.");
        }

        if (_gpu is null)
        {
            throw new InvalidOperationException("Gpu cannot be null.");
        }

        if (_cpu is null)
        {
            throw new InvalidOperationException("Cpu cannot be null.");
        }


        var pc = new Pc
        {
            Cpu = _cpu,
            Gpu = _gpu,
            Ram = _ram
        };

        Reset();

        return pc;
    }

    private void Reset()
    {
        _ram = null;
        _gpu = null;
        _cpu = null;
    }
}