namespace M012;

public static class ExtensionMethods
{
	public static int Quersumme(this int x) //mit this sich auf einen Typen beziehen
	{
		return x.ToString().Sum(e => (int) char.GetNumericValue(e));
		//return x.ToString().Aggregate(0, (sum, i) => sum + (int) char.GetNumericValue(i));
	}

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> x)
	{
		return x.OrderBy(e => Random.Shared.Next());
	}
}
