using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LethalCompanySaveManager
{
	public class LCPlayer : ISaveInterface
	{
		public string saveData = "";

		#region SaveAttributes
		// attributes of the player file
		public static readonly string LastSelectedFile = "SelectedFile"; //int
		public static readonly string LastPlayedVersion = "LastVerPlayed"; //int
		public static readonly string PlayerXP = "PlayerXPNum"; //int
		public static readonly string PlayerLevel = "PlayerLevel"; //int
		public static readonly string PlayerFinishedSetup = "PlayerFinishedSetup"; //bool
		public static readonly string HasUsedTerminal = "HasUsedTerminal"; //bool

		// Player stats
		public static readonly string FinishedShockMinigame = "FinishedShockMinigame"; // int
		public static readonly string TimesLanded = "TimesLanded"; //int

		// Player parameters
		public static readonly string Gamma = "Gamma"; //float
		public static readonly string MasterVolume = "MasterVolume"; //float
		public static readonly string StartInOnlineMode = "StartInOnlineMode"; // bool
		public static readonly string HostPublicGame = "HostSettings_Public"; // bool
		public static readonly string HostName = "HostSettings_Name"; // string
		#endregion

		#region SaveProperties
		private int _lastSelectedFile;
		public int lastSelectedFile {  
			get {
				return _lastSelectedFile;
			} 

			set { 
			_lastSelectedFile = value;
				WriteToAttribute(LastSelectedFile, value.ToString());
			} 
		}
		private int _lastPlayedVersion;
		public int lastPlayedVersion
		{
			get
			{
				return _lastPlayedVersion;
			}

			set
			{
				_lastPlayedVersion = value;
				WriteToAttribute(LastPlayedVersion, value.ToString());
			}
		}
		private int _playerXP;
		public int playerXP
		{
			get
			{
				return _playerXP;
			}

			set
			{
				WriteToAttribute(PlayerXP, value.ToString());
				_playerXP = value;
			}
		}
		private int _playerLevel;
		public int playerLevel
		{
			get
			{
				return _playerLevel;
			}

			set
			{
				_playerLevel = value;
				WriteToAttribute(PlayerLevel, value.ToString());
			}
		}
		private bool _playerFinishedSetup;
		public bool playerFinishedSetup
		{
			get
			{
				return _playerFinishedSetup;
			}

			set
			{
				_playerFinishedSetup = value;
				WriteToAttribute(PlayerFinishedSetup, value.ToString().ToLowerInvariant());
			}
		}
		private bool _hasUsedTerminal;
		public bool hasUsedTerminal
		{
			get
			{
				return _hasUsedTerminal;
			}

			set
			{
				_hasUsedTerminal = value;
				WriteToAttribute(HasUsedTerminal, value.ToString().ToLowerInvariant());
			}
		}
		private int _finishedShockMinigame;
		public int finishedShockMinigame
		{
			get
			{
				return _finishedShockMinigame;
			}

			set
			{
				_finishedShockMinigame = value;
				WriteToAttribute(FinishedShockMinigame, value.ToString());
			}
		}
		private int _timesLanded;
		public int timesLanded
		{
			get
			{
				return _timesLanded;
			}

			set
			{
				_timesLanded = value;
				WriteToAttribute(TimesLanded, value.ToString());
			}
		}
		private float _gamma;
		public float gamma
		{
			get
			{
				return _gamma;
			}

			set
			{
				_gamma = value;
				WriteToAttribute(Gamma, value.ToString());
			}
		}
		private float _masterVolume;
		public float masterVolume
		{
			get
			{
				return _masterVolume;
			}

			set
			{
				_masterVolume = value;
				WriteToAttribute(MasterVolume, value.ToString());
			}
		}
		private bool _startInOnlineMode;
		public bool startInOnlineMode
		{
			get
			{
				return _startInOnlineMode;
			}

			set
			{
				_startInOnlineMode = value;
				WriteToAttribute(StartInOnlineMode, value.ToString().ToLowerInvariant());
			}
		}
		private bool _hostPublicGame;
		private string _hostName;
		public bool hostPublicGame
		{
			get
			{
				return _hostPublicGame;
			}

			set
			{
				_hostPublicGame = value;
				WriteToAttribute(HostPublicGame, value.ToString().ToLowerInvariant());
			}
		}
		public string hostName
		{
			get
			{
				return _hostName;
			}

			set
			{
				_hostName = value;
				WriteToAttribute(HostName, value);
			}
		}
		#endregion

		public LCPlayer()
		{
			Load();
		}

		public void Load()
		{
			FileInfo PlayerSaveFile = new FileInfo(LCSE.GameSavePath + LCSE.PlayerSave);
			if (!PlayerSaveFile.Exists) { return; }

			bool boul = false;
			int ount = 1;
			float flout = 0f;

			saveData = LCSecurity.Decrypt(File.ReadAllBytes(PlayerSaveFile.ToString()));

			lastSelectedFile = int.TryParse(GetDataFromSave(LastSelectedFile), out ount) ? ount : 1;
			lastPlayedVersion = int.TryParse(GetDataFromSave(LastPlayedVersion), out ount) ? ount : 45;
			playerXP = int.TryParse(GetDataFromSave(PlayerXP), out ount) ? ount : 0;
			playerLevel = int.TryParse(GetDataFromSave(PlayerLevel), out ount) ? ount : 0;
			playerFinishedSetup = bool.TryParse(GetDataFromSave(PlayerFinishedSetup), out boul) ? boul : false;
			hasUsedTerminal = bool.TryParse(GetDataFromSave(HasUsedTerminal), out boul) ? boul : false;
			finishedShockMinigame = int.TryParse(GetDataFromSave(FinishedShockMinigame), out ount) ? ount : 0;
			timesLanded = int.TryParse(GetDataFromSave(TimesLanded), out ount) ? ount : 0;
			gamma = float.TryParse(GetDataFromSave(Gamma), out flout) ? flout : 0.0f;
			masterVolume = float.TryParse(GetDataFromSave(MasterVolume), out flout) ? flout : 0.0f;
			startInOnlineMode = bool.TryParse(GetDataFromSave(StartInOnlineMode), out boul) ? boul : false;
			hostPublicGame = bool.TryParse(GetDataFromSave(HostPublicGame), out boul) ? boul : false;
			//remove '"' at the beginning and end of the hostname
			string tempHost = GetDataFromSave(HostName);
			tempHost = tempHost.Remove(0, 1);
			tempHost = tempHost.Remove(tempHost.Length - 1, 1);
			hostName = tempHost;
		}

		public string GetDataFromSave(string attribute)
		{
			if (!saveData.Contains(attribute))
				return "";
			int first = saveData.IndexOf(attribute) + attribute.Length + 2;

			string tempStr = saveData.Substring(first, saveData.Length - first);
			tempStr = tempStr.Substring(0, tempStr.IndexOf('}'));
			string resultStr = tempStr.Substring(tempStr.IndexOf("\"value\":") + 8, tempStr.Length - (tempStr.IndexOf("\"value\":") + 8));

			return resultStr;
		}

		public string WriteToAttribute(string attribute, string newValue)
		{
			if (!saveData.Contains(attribute))
				return "";

			int firstIndexOfAttribute = saveData.IndexOf(attribute) + attribute.Length;

			string tempStr = saveData.Substring(firstIndexOfAttribute, saveData.Length - firstIndexOfAttribute);

			int firstIndexOfValue = firstIndexOfAttribute + tempStr.IndexOf("\"value\":") + 8;

			try
			{
				tempStr = tempStr.Substring(tempStr.IndexOf("\"value\":") + 8, tempStr.Length - (tempStr.IndexOf("\"value\":") + 8));
				tempStr = tempStr.Substring(0, tempStr.IndexOf('}'));

				saveData = saveData.Remove(firstIndexOfValue, tempStr.Length);
				saveData = saveData.Insert(firstIndexOfValue, newValue);

				return saveData;
			}
			catch (Exception)
			{
				return "";
				throw;
			}
		}
	}
}
