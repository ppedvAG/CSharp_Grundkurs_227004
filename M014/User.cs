namespace M014;

internal class User
{
	static void Main(string[] args)
	{
		Component comp = new Component();
		comp.ProcessCompleted += () => Console.WriteLine("Prozess fertig"); //Log, Datenbank schreiben, Webrequest, ...
		comp.Progress += (x) => Console.WriteLine($"Fortschritt: {x}"); //Log, Datenbank schreiben, Webrequest, ...
		comp.Work();
	}
}
