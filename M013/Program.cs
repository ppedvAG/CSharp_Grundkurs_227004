namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		//throw new Exception();

		try //Codeblock markieren + Rechtsklick -> Surround with -> try(f)
		{
			string eingabe = Console.ReadLine(); //Maus über Methode -> Exceptions
			int x = int.Parse(eingabe); //3 mögliche Exceptions: ArgumentNullException, FormatException, OverflowException

			if (x == 0)
			{
				throw new TestException("Zahl darf nicht 0 sein");
			}
		}
		catch (FormatException) //Keine Zahl eingegeben
		{
			Console.WriteLine("Keine Zahl eingegeben");
		}
		catch (OverflowException e) //Zahl ist zu groß/klein
		{
			Console.WriteLine("Die Zahl ist zu groß/klein");
			Console.WriteLine();
			Console.WriteLine(e.Message); //Die .NET interne Nachricht
			Console.WriteLine(e.StackTrace); //Nachverfolgung vom Fehler im Code
		}
		catch (Exception e) //Alle anderen Fehler
		{
			Console.WriteLine("Anderer Fehler");
			Console.WriteLine(e.Message);
			Console.WriteLine(e.StackTrace);
			throw; //Fataler Fehler
		}
		catch { } //Selbiges wie catch (Exception) { }
		finally //Wird immer ausgeführt (auch bei Fehlern)
		{
			Console.WriteLine("Parsen abgeschlossen");
		}
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = e.ExceptionObject as Exception; //as-Cast: Funktioniert wie ein normaler Cast nur kann nicht mit non-null Typen verwendet werden
		File.WriteAllText("Log.txt", $"{ex.Message}\n{ex.StackTrace}");
	}
}

public class TestException : SystemException
{
	public string Status;

	public TestException(string? message) : base(message)
	{

	}
}