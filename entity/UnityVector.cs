using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalCompanySaveManager.entity
{
	public class UnityVector
	{
		// {"x":4.802082,"y":0.7417145,"z":-12.491188}
		public float x; public float y; public float z;

		public override string ToString()
		{
			return "{\"x\":" + x.ToString() + ",\"y\":" + y.ToString() + ",\"z\":" + z.ToString() + '}';
		}
	}
}
