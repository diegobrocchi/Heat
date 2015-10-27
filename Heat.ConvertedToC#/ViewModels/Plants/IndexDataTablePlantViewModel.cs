namespace Heat.ViewModels.Plants
{
    /// <summary>
    /// Modello che viene mostrato nel datatable jQuery.
    /// E' un subset di Plant e contiene solo le proprietà da mostrare.
    /// </summary>
    public class IndexDataTablePlantViewModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		//Property PlantClass As String
		//Property PlantType As String
		public string PlantDistinctCode { get; set; }
	}
}

