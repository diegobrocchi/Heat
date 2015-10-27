namespace Heat.Models
{

    /// <summary>
    /// Rappresenta un oggetto di tipo grafico o audio o video o whatever caricata come allegato ad un'altra entità.
    /// </summary>
    public class Medium
	{

		public int ID { get; set; }
		public string OriginalFileName { get; set; }
		public string UploadFileName { get; set; }
		public string RelativePath { get; set; }
		public string AbsolutePath { get; set; }
		public int Lenght { get; set; }
		public string Extension { get; set; }
		public string ContentType { get; set; }
		public string Description { get; set; }
		public string Tags { get; set; }

	}
}

