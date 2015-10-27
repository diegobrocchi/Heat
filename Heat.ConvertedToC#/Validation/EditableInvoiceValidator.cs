using Heat.Models;
namespace Heat
{

    /// <summary>
    /// Regola di validazione per una fattura editabile.
    /// Solo le fatture con State=DocumentState.Inserted sono modificabili.
    /// </summary>
    /// <remarks></remarks>
    public class EditableInvoiceValidator : IValidator
	{

		IHeatDBContext _db;

		int _invoiceID;
		public EditableInvoiceValidator(IHeatDBContext repository, int invoiceID)
		{
			_db = repository;
			_invoiceID = invoiceID;
		}

		public string ErrorMessage {
			get { return "Il documento non è modificabile"; }
		}

		public bool IsValid {
			get { return _db.Invoices.Find(_invoiceID).State == DocumentState.Inserted; }
		}
	}
}
