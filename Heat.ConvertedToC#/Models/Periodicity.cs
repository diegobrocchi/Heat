using System.ComponentModel.DataAnnotations;
namespace Heat
{

    public enum Periodicity
	{
		[Display(Name = "Nessuna")]
		None = 0,
		[Display(Name = "Giornaliera")]
		Daily = 1,
		[Display(Name = "Settimanale")]
		Weekly = 2,
		[Display(Name = "Mensile")]
		Monthly = 3,
		[Display(Name = "Trimestrale")]
		Quarterly = 4,
		[Display(Name = "Annuale")]
		Yearly = 5,
		[Display(Name = "Biennale")]
		Biennial = 6,
		[Display(Name = "Triennale")]
		Three_year = 7,
		[Display(Name = "Quadriennale")]
		Four_year = 8,
		[Display(Name = "Quinquennale")]
		quinquennial = 9

	}
}
