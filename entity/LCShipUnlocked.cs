using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalCompanySaveManager.entity
{
	public class LCShipUnlocked
	{
		#region SaveAttributes
		public static readonly string ShipGrabbableItems = "shipGrabbableItemIDs"; // Multiple IDs values, represents any objects that can be held by a player in inventory (memo included)
		public static readonly string UnlockedShipObjects = "UnlockedShipObjects"; // Multiple IDs values, represents ship upgrades objects
		public static readonly string ShipGrabbableItemPos = "shipGrabbableItemPos"; // Mutiple Unity Engine Vector3 values, represents any objects that can be held by a player in inventory (memo included)
		public static readonly string ShipUnlockRot = "ShipUnlockRot_"; //Single Vector 3 value, _ is followed by item name with whitespaces
		public static readonly string ShipUnlockPos = "ShipUnlockPos_"; //Single Vector 3 value, _ is followed by item name with whitespaces
		public static readonly string ShipUnlockMoved = "ShipUnlockMoved_"; // Single bool value, _ is followed by item name with whitespaces
		public static readonly string ShipUnlockStored = "ShipUnlockStored_"; // Single bool value, _ is followed by item name with whitespaces
		#endregion

		#region Single values
		internal string name = "";
		internal int id = 0;
		internal int arrayPosition = 0;

		private UnityVector _rotation;
		public UnityVector rotation
		{
			get	{ return _rotation; }

			set
			{
				_rotation = value;
				//WriteToAttribute(Credits, value.ToString());
			}
		}

		private UnityVector _position;
		public UnityVector position
		{
			get	{return _position;}

			set
			{
				_position = value;
				//WriteToAttribute(Credits, value.ToString());
			}
		}

		private bool _moved;
		public bool moved
		{
			get	{return _moved;}

			set
			{
				_moved = value;
				//WriteToAttribute(Credits, value.ToString());
			}
		}
		private bool _stored;
		public bool stored
		{
			get {return _stored;}

			set
			{
				_stored = value;
				//WriteToAttribute(Credits, value.ToString());
			}
		}
		#endregion
	}
}
