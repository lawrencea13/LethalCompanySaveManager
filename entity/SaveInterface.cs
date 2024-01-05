using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalCompanySaveManager
{
	internal interface ISaveInterface
	{
		string GetDataFromSave(string attribute);
		string WriteToAttribute(string attribute, string newValue);

	}
}
