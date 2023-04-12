namespace M008;

class AccessModifier //Member ohne Modifier sind internal
{
	public string Name { get; set; } //Überall sichtbar, auch außerhalb vom Projekt

	private int Alter { get; set; } //Nur innerhalb der Klasse sichtbar in der das Feld angelegt wurde

	internal string Wohnort { get; set; } //Überall sichtbar, aber nur innerhalb vom Projekt


	protected string Lieblingsfarbe { get; set; } //Nur innerhalb der Klasse (effektiv private) und in Unterklassen (auch außerhalb vom Projekt)

	protected internal string Lieblingsnahrung { get; set; } //Überall im Projekt (internal) und in Unterklassen außerhalb vom Projekt

	protected private DateTime Geburtsdatum { get; set; } //Kann nur in dieser Klasse und in Unterklassen nur im Projekt gesehen werden
}
