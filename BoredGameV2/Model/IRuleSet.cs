namespace BoredGameV2.Model;

public interface IRuleSet
{
    Outcome Evaluate(IReadOnlyBoard board);
}