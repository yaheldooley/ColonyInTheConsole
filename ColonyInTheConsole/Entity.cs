using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyInTheConsole
{
	public abstract class Entity
	{
		public string Name;
		public int Age;
		public string Sex;
		public Vector2Int Pos;
		public char charRep { get; set; }

		
	}

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
