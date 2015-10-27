using System.ComponentModel.DataAnnotations;
namespace Heat
{

    public enum ThermalUnitKindEnum
	{
		[Display(Name = "Gruppo termico singolo")]
		SingleThermalUnit = 1,

		[Display(Name = "Tubo/nastro radiante")]
		TubeOrRadiantStrip = 2,

		[Display(Name = "Gruppo termico modulare")]
		ModularThermalUnit = 3,

		[Display(Name = "Generatore di aria calda")]
		HotAirGenerator = 4

	}
}
