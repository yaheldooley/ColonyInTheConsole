﻿using System;
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
		public int[,,] Pos;
		public char charRep { get; set; }

		public virtual void Update()
		{
		
		}
	}
}
