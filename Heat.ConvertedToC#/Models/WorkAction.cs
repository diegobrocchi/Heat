using System;

namespace Heat.Models
{

    /// <summary>
    /// Rappresenta un intervento di lavoro.
    /// </summary>
    /// <remarks></remarks>
    public class WorkAction
	{

		public int ID { get; set; }

		public DateTime ActionDate { get; set; }
		public int OperationID { get; set; }
		public Operation Operation { get; set; }
		public int AssignedOperatorID { get; set; }
		public WorkOperator AssignedOperator { get; set; }
		public int TypeID { get; set; }
		public ActionType Type { get; set; }
		public int PlantID { get; set; }
		public Plant Plant { get; set; }

	}

}

