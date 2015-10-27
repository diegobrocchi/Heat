using System.ComponentModel.DataAnnotations;
namespace Heat
{

    /// <summary>
    /// Inmpone che la proprietà sia valorizzata se un'altra è nulla.
    /// </summary>
    /// <remarks></remarks>
    public class RequiredIfEmpty : ValidationAttribute
	{

		private string _other;
		/// <summary>
		/// La proprietà di cui deve essere controllata la presenza per validare la corrente.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public string Other {
			get { return _other; }
			private set { _other = value; }
		}



		public RequiredIfEmpty(string other)
		{
			_other = other;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{

			//se il valore della proprietà non è nullo allora è valido.
			if ((value != null)) {
				return ValidationResult.Success;
			} else {
				//se il valore è nullo allora non deve essere nullo quello dell'altra proprietà.
				var pi = validationContext.ObjectType.GetProperty(Other);
				if ((pi != null)) {
					if (string.IsNullOrEmpty(pi.GetValue(validationContext.ObjectInstance).ToString())) {
						return new ValidationResult(string.Format("Questo valore è richiesto se {0} è nullo", Other));
					} else {
						return ValidationResult.Success;
					}
				} else {
					return new ValidationResult(string.Format("Non esiste la proprietà {0}", Other));
				}

			}
		}

	}
}
