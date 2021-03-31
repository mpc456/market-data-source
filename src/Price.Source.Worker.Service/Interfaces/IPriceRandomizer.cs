namespace Price.Source.Worker.Service.Interfaces
{
    public interface IPriceRandomizer
    {
        decimal GetNext(decimal original, int volatility);
    }
}