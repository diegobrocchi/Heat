namespace Heat.ViewModels.Plants
{

    /// <summary>
    /// Modello per la vista Details per un impianto. I dati da presentare sono molti quindi vengono suddivisi in tab.
    /// Il modello è strutturato con un sub-modello per ogni tab.
    /// </summary>
    /// <remarks></remarks>
    public class DetailsPlantViewModel
	{

		public DetailsIdentifyPlantViewModel IdentifyViewModel { get; set; }
		public DetailsThermalPlantViewModel ThermalViewModel { get; set; }
		public DetailsContactPlantViewModel ContactViewModel { get; set; }
		public DetailsMediaPlantViewModel MediaViewModel { get; set; }
		public DetailsServicePlantViewModel ServiceViewModel { get; set; }
	}

}
