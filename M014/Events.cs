namespace M014;

internal class Events
{
	//event: Statischer Punkt an den Methoden angehängt werden können (kann nicht erstellt werden)
	static event EventHandler TestEvent;

	static event EventHandler<TestEventArgs> ArgsEvent;

	static event EventHandler<int> IntEvent;

	static void Main(string[] args)
	{
		TestEvent += Events_TestEvent; //Anwenderseite: Methode anhängen, die beim feuern der Events ausgeführt wird
		TestEvent(null, EventArgs.Empty); //Programmierseite: Event feuern wenn etwas passiert

		ArgsEvent += Events_ArgsEvent;
		ArgsEvent(null, new TestEventArgs() { Status = "Fertig" });

		IntEvent += Events_IntEvent;
		IntEvent(null, 4);
	}

	private static void Events_TestEvent(object sender, EventArgs e)
	{
		Console.WriteLine("TestEvent aufgerufen");
	}

	private static void Events_ArgsEvent(object sender, TestEventArgs e)
	{
		Console.WriteLine(e.Status);
	}

	private static void Events_IntEvent(object sender, int e)
	{
		Console.WriteLine(e);
	}
}

public class TestEventArgs : EventArgs
{
	public string Status;
}