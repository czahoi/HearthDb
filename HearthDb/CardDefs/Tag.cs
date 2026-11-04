#region

using System.Xml.Serialization;

#endregion

namespace HearthDb.CardDefs
{
	public class Tag
	{
		[XmlAttribute("enumID")]
		public int EnumId { get; set; }

		private string _name;
		private string _typeString;

		// intern repeated tag attributes, XmlSerializer allocates a copy per tag
		[XmlAttribute("name")]
		public string Name
		{
			get => _name;
			set => _name = value == null ? null : string.Intern(value);
		}

		[XmlAttribute("type")]
		public string TypeString
		{
			get => _typeString;
			set => _typeString = value == null ? null : string.Intern(value);
		}

		[XmlAttribute("value")]
		public int Value { get; set; }

		[XmlText]
		public string InnerValue { get; set; }

		[XmlElement("enUS")]
		public string LocStringEnUs { get; set; }

		[XmlElement("deDE")]
		public string LocStringDeDe { get; set; }

		[XmlElement("esES")]
		public string LocStringEsEs { get; set; }

		[XmlElement("esMX")]
		public string LocStringEsMx { get; set; }

		[XmlElement("frFR")]
		public string LocStringFrFr { get; set; }

		[XmlElement("itIT")]
		public string LocStringItIt { get; set; }

		[XmlElement("jaJP")]
		public string LocStringJaJp { get; set; }

		[XmlElement("koKR")]
		public string LocStringKoKr { get; set; }

		[XmlElement("plPL")]
		public string LocStringPlPl { get; set; }

		[XmlElement("ptBR")]
		public string LocStringPtBr { get; set; }

		[XmlElement("ruRU")]
		public string LocStringRuRu { get; set; }

		[XmlElement("zhCN")]
		public string LocStringZhCn { get; set; }

		[XmlElement("zhTW")]
		public string LocStringZhTw { get; set; }

		[XmlElement("thTH")]
		public string LocStringThTh { get; set; }
	}
}