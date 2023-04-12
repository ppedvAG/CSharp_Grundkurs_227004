namespace M006;

internal class Program
{
	static void Main(string[] args)
	{
		Fenster f = new Fenster();
		f.SetLaenge(5);
		f.Breite = 5;

		//f.Status = FensterStatus.Offen;

		Fenster f2 = new Fenster(5, 5, 10);

		//Console -> System
		//File -> System.IO
		//HttpClient -> System.Net.Http
	}
}