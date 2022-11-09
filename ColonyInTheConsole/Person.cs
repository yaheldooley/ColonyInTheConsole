namespace ColonyInTheConsole
{
	public class Person : Entity
	{
		public Person(string name, int age, char character, int[,,]pos)
		{
			Name = name;
			Age = age;
			charRep = character;
			Pos = pos;
			Game.ActiveScene.EntityLocations.Add(Pos, charRep);
		}

		public override void Update()
		{
			
		}
	}
}
