using System.Collections.Generic;
using System.Linq;
namespace Heat
{
    public class ValidationRules : List<IValidator>
	{

		public bool IsValid {
			get { return (this != null) && this.All(x => x.IsValid); }
		}

		public List<IValidator> Errors {
			get { return this.Where(x => !x.IsValid).ToList(); }
		}

	}
}
