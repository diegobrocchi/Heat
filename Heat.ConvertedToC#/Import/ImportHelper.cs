using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Heat.Repositories;
using Heat.Models;
namespace Heat
{


	public class ImportHelper
	{

		private HeatDBContext _context;
		public ImportHelper(HeatDBContext context)
		{
			_context = context;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fileContent"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public bool Customer(string fileContent)
		{
			string[] fileRows = null;
			string[] fileRowFields = null;
			List<Models.Customer> NewCustomersList = new List<Models.Customer>();

			try {
				//controlla se la prima riga è nel formato giusto
				fileRows = fileContent.Split(Constants.vbCrLf);

				if (!string.IsNullOrEmpty(fileRows[0])) {
					fileRowFields = fileRows[0].Split(";");

					if (fileRowFields.Count() == 16) {
						for (i = 1; i <= fileRows.Count() - 2; i++) {
							fileRowFields = fileRows[i].Split(";");

							Models.Customer newCustomer = new Models.Customer();
							newCustomer.Address = fileRowFields[4];
							newCustomer.City = fileRowFields[5];
							newCustomer.District = fileRowFields[7];
							newCustomer.IBAN = fileRowFields[13];
							newCustomer.Name = fileRowFields[3];
							newCustomer.PostalCode = fileRowFields[6];
							newCustomer.Taxcode = fileRowFields[11];
							newCustomer.Telephone1 = fileRowFields[8];
							newCustomer.Telephone2 = fileRowFields[9];
							newCustomer.Telephone3 = fileRowFields[10];
							newCustomer.VAT_Number = fileRowFields[12];

							newCustomer.IsEnabled = true;
							newCustomer.CreationDate = DateAndTime.Now;
							newCustomer.EnableDate = DateAndTime.Now;

							NewCustomersList.Add(newCustomer);
						}
					}
				}
				_context.Customers.RemoveRange(_context.Customers.ToList());
				foreach (Customer c_loopVariable in NewCustomersList) {
					c = c_loopVariable;
					_context.Customers.Add(c);
				}
				_context.SaveChanges();

				return true;
			} catch (Exception ex) {
				return false;
			}

		}


		public bool Plant(string fileContent)
		{
			string[] fileRows = null;
			string[] fileRowFields = null;
			List<Plant> newPlantList = new List<Plant>();

			try {
				fileRows = fileContent.Split(Constants.vbCrLf);
				if (!string.IsNullOrEmpty(fileRows[0])) {
					fileRowFields = fileRows[0].Split(";");
					if (fileRowFields.Count() == 19) {
						for (i = 1; i <= fileRows.Count() - 2; i++) {
							fileRowFields = fileRows[i].Split(";");

							Plant newPlant = new Plant();
							//TODO: cambia l'associazione dell'indirizzo: non proprietà, ma complexType BuildingAddress
							//newPlant.Address = fileRowFields(4)
							//newPlant.Area = fileRowFields(16)
							//newPlant.City = fileRowFields(12)
							//newPlant.PostalCode = fileRowFields(13)
							//newPlant.StreetNumber = fileRowFields(5)
							//newPlant.Zone = fileRowFields(16)
							newPlant.Code = fileRowFields[2];
							//TODO: Fuel è un oggetto a se': aggiusta l'import!!!!
							//newPlant.Fuel = fileRowFields(17)
							//
							newPlant.Name = fileRowFields[3];
							string sPlantClass = fileRowFields[9];
							newPlant.PlantClass = _context.PlantClasses.Where(pc => pc.Name == sPlantClass).FirstOrDefault();
							newPlant.PlantDistinctCode = fileRowFields[11];
							//newPlant.PlantTelephone1 = fileRowFields(6)
							//newPlant.PlantTelephone2 = fileRowFields(7)
							//newPlant.PlantTelephone3 = fileRowFields(8)
							string sPlantType = fileRowFields[10];
							newPlant.PlantType = _context.PlantTypes.Where(pt => pt.Name == sPlantType).FirstOrDefault();

							newPlantList.Add(newPlant);
						}

					}
				}
				_context.Plants.RemoveRange(_context.Plants.ToList());
				_context.Plants.AddRange(newPlantList);
				_context.SaveChanges();
				return true;
			} catch (Exception ex) {
				return false;

			}


		}
	}
}
