using System.Text;
using Patterns2;

var builder = new PcBuilder();

builder.AddCpu(4.2, 8, 16);
builder.AddGpu(2610, 12);
builder.AddRam(3666, 32);


var pc = builder.Build();

Console.WriteLine(pc.ToString());


class PcDirector
{
    private readonly IPcBuilder _pcBuilder;

    public PcDirector(IPcBuilder pcBuilder)
    {
        _pcBuilder = pcBuilder;
    }

    public Pc BuildGamingPc()
    {
        _pcBuilder.AddCpu(4.2, 8, 16);
        _pcBuilder.AddGpu(2610, 12);
        _pcBuilder.AddRam(3666, 32);

        return _pcBuilder.Build();
    }

    public Pc BuildPotatoPc()
    {
        _pcBuilder.AddCpu(2, 2, 4);
        _pcBuilder.AddGpu(1610, 4);
        _pcBuilder.AddRam(1666, 8);

        return _pcBuilder.Build();
    }
}


interface IButton
{
    void Click();
    event Action OnClick;
}


class WebButton : IButton
{
    public WebButton(object? obj)
    {
        
    }
    public void Click()
    {
        OnClick?.Invoke();
    }

    public event Action? OnClick;
}

class WinButton : IButton
{
    public WinButton(object? obj)
    {
        
    }
    
    public void Click()
    {
        OnClick?.Invoke();
    }

    public event Action? OnClick;
}

enum ButtonType
{
    Web,
    Win
}

interface IButtonFactory
{
    IButton CreateButton(ButtonType type);
}

class ButtonFactory : IButtonFactory
{
    private readonly object _obj;

    public ButtonFactory(object obj)
    {
        _obj = obj;
    }
    
    public IButton CreateButton(ButtonType type)
    {
        switch (type)
        {
            case ButtonType.Web:
                return new WebButton(_obj);
            case ButtonType.Win:
                return new WinButton(_obj);
            default: // this won't happen
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}

class WinButtonFactory : IButtonFactory
{
    private readonly object _dependency;

    public WinButtonFactory(object dependency)
    {
        _dependency = dependency;
    }
    
    public IButton CreateButton(ButtonType type)
    {
        return new WinButton(_dependency);
    }
}