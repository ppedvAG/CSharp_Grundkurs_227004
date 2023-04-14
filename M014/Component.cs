namespace M014;

public class Component
{
	public event Action ProcessCompleted; //Wenn der Prozess fertig ist, wird dieses Event gefeuert

	public event Action<int> Progress; //Wenn der Prozess voranschreitet, wird dieses Event gefeuert

	public void Work() //Daten holen von einer Datenbank
	{
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(200);
			Progress?.Invoke(i);
		}
		ProcessCompleted?.Invoke(); //Wenn der User hier kein Event anhängt, wird es übersprungen
	}
}
