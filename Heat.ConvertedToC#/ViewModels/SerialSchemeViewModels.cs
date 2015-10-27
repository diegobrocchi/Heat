using System;
using System.ComponentModel.DataAnnotations;
namespace Heat
{

    public class CreateSerialSchemeViewModel
	{

		[Key()]
		public int ID { get; set; }

		[Required()]
		[Display(Name = "Nome simbolico dello schema, serve come riferimento")]
		public string Name { get; set; }

		[Required()]
		[Display(Name = "Descrizione breve dello schema")]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }

		[Required()]
		[Display(Name = "Valore iniziale della serie")]
		public int InitialValue { get; set; }

		[Required()]
		[Display(Name = "Incremento")]
		public int Increment { get; set; }
		[Display(Name = "Valore minimo assegnabile (può essere lasciato vuoto se non esiste il minimo)")]
		public Nullable<int> MinValue { get; set; }

		[Display(Name = "Valore massimo assegnabile (può essere lasciato vuoto se non esiste il massimo)")]
		public Nullable<int> MaxValue { get; set; }

		[Display(Name = "Schema di generazione del testo corrispondente al numero di serie")]
		public string FormatMask { get; set; }

		[Display(Name = "Data di scadenza dello schema")]
		[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public Nullable<DateTime> ExpiryDate { get; set; }

		[Display(Name = "Riparte dal valore iniziale quando si supera la data di scadenza")]
		public bool RecycleWhenExpired { get; set; }

		[Display(Name = "Periodicità")]
		public Nullable<Periodicity> Period { get; set; }

		[Display(Name = "Riparte dal valore iniziale quando raggiunge il valore massimo")]
		public bool RecycleWhenMaxIsReached { get; set; }

	}
}
namespace Heat
{

    public class IndexSerialSchemeViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(Name = "Nome")]
		public string Name { get; set; }

		[Display(Name = "Descrizione")]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }

		[Display(Name = "Incremento")]
		public int Increment { get; set; }

		[Display(Name = "Periodicità")]
		public Periodicity Period { get; set; }

	}
}
