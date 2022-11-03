namespace ColonyInTheConsole
{
	public class Person : Entity
	{
		public Person(string name, int age, char character)
		{
			Name = name;
			Age = age;
			charRep = character;
			Pos = new Vector2Int(0, 0);
		}
	}
}
