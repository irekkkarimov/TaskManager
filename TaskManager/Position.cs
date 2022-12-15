namespace TaskManager;

public class Position
{
    private int _BaseHourlyRate;
    private int _Code;
    private string _Name;

    public int BaseHourlyRate => _BaseHourlyRate;

    public int Code => _Code;
    

    public string Name => _Name;

    public Position(int baseHourlyRate, int code, string name)
    {
        _BaseHourlyRate = baseHourlyRate;
        _Code = code;
        _Name = name;
    }
}