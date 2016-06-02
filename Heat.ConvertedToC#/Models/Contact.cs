namespace Heat.Models
{
    public class Contact
	{
        public Contact()
        {
            //this.Address = new Address();
        }

		public int ID { get; set; }

		public string Name { get; set; }
		public Address Address { get; set; }
		public string Phone { get; set; }
		public string CellPhone { get; set; }
		public string Fax { get; set; }
		public string Email { get; set; }
		public string URL { get; set; }

        public int? RoleID { get; set; }
        /// <summary>
        /// Il ruolo che il contatto ha rispetto all'impianto.
        /// </summary>
        public virtual PlantRole Role { get; set; }

	}
}

