using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using Heat.Models;
using Heat.Import;

namespace Heat
{


    public class ImportHelper
    {

        private IHeatDBContext _context;
        public ImportHelper(IHeatDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Importa la lista dei clienti.
        /// </summary>
        /// <param Name="fileContent"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool Customer(string fileContent)
        {
            string[] fileRows = null;
            string[] fileRowFields = null;
            List<Models.Customer> NewCustomersList = new List<Models.Customer>();

            try
            {
                //controlla se la prima riga è nel formato giusto
                fileRows = fileContent.Split(new char[] { '\n' });

                if (!string.IsNullOrEmpty(fileRows[0]))
                {
                    fileRowFields = fileRows[0].Split(new char[] { ';' });

                    if (fileRowFields.Count() == 16)
                    {
                        for (int i = 1; i <= fileRows.Count() - 2; i++)
                        {
                            fileRowFields = fileRows[i].Split(new char[] { ';' });

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
                foreach (Customer c in NewCustomersList)
                {

                    _context.Customers.Add(c);
                }
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Importa la lista degli impianti a partire dal testo contenuto nel file.
        /// </summary>
        /// <param name="fileContentPlants"></param>
        /// <returns></returns>
		public bool Plant(string fileContentPlants, string fileContentThermalUnits)
        {

            List<PlantImport> importPlants = new List<PlantImport>();
            List<ThermalUnitImport> importThermalUnits = new List<ThermalUnitImport>();

            List<Plant> newPlantList = new List<Plant>();

            try
            {
                if (PlantFileIsValid(fileContentPlants) && ThermalUnitFileIsValid(fileContentThermalUnits))
                {
                    importPlants = MapToPlantList(fileContentPlants);
                    importThermalUnits = MapToThermalUnitList(fileContentThermalUnits);

                    //aggiungo tutti i PlantTypes
                    List<PlantType> PlantTypes = new List<PlantType>();
                    PlantTypes = importPlants.GroupBy(x => x.TipologiaImpianto).Select(grp => new PlantType() { Name = grp.First().TipologiaImpianto }).ToList();
                    _context.PlantTypes.RemoveRange(_context.PlantTypes.ToList());
                    _context.PlantTypes.AddRange(PlantTypes);

                    //aggiungo tutti i Fuels
                    List<Fuel> Fuels = new List<Fuel>();
                    Fuels = importPlants.Where(x => x.Combustibile != String.Empty).GroupBy(x => x.Combustibile).Select(grp => new Fuel() { Name = grp.First().Combustibile }).ToList();
                    _context.Fuels.RemoveRange(_context.Fuels.ToList());
                    _context.Fuels.AddRange(Fuels);

                    //aggiungo tutti i PlantClasses
                    List<PlantClass> PlantClasses;
                    PlantClasses = importPlants.Where(x => x.ClasseImpianto != String.Empty).GroupBy(x => x.ClasseImpianto).Select(grp => new PlantClass() { Name = grp.First().ClasseImpianto }).ToList();
                    _context.PlantClasses.RemoveRange(_context.PlantClasses.ToList());
                    _context.PlantClasses.AddRange(PlantClasses);

                    //aggiungo tutti i Manifacturers
                    List<Manifacturer> Manifacturers;
                    Manifacturers = importThermalUnits.GroupBy(x => x.Marca).Select(grp => new Manifacturer { Name = grp.First().Marca }).ToList();
                    _context.Manifacturers.RemoveRange(_context.Manifacturers.ToList());
                    _context.Manifacturers.AddRange(Manifacturers);

                    //aggiungo tutti i ManifacturerModels
                    List<ManifacturerModel> ManifacturerModels;
                    //ManifacturerModels = importThermalUnits.Where(x => x.ModelloCaldaia != string.Empty).GroupBy(x => x.ModelloCaldaia).Select(grp => new ManifacturerModel { Manifacturer = null, Model = grp.First().ModelloCaldaia }).ToList();
                    ManifacturerModels = importThermalUnits.Where(x => x.ModelloCaldaia != string.Empty).GroupBy(x => x.ModelloCaldaia).Select(grp => new ManifacturerModel { Manifacturer = Manifacturers.Where(m => m.Name == grp.First().Marca).First(), Model = grp.First().ModelloCaldaia }).ToList();
                    _context.ManifacturerModels.RemoveRange(_context.ManifacturerModels.ToList());
                    _context.ManifacturerModels.AddRange(ManifacturerModels);

                    _context.SaveChanges();

                    foreach (PlantImport pi in importPlants)
                    {
                        Plant newPlant = new Plant();

                        PlantBuilding building = new PlantBuilding();
                        building.Address = pi.IndirizzoImpianto;
                        building.City = pi.Comune;
                        building.PostalCode = pi.CAP;
                        building.District = pi.Provincia;
                        building.StreetNumber = pi.NumeroCivico;
                        building.Zone = pi.Frazione;
                        newPlant.BuildingAddress = building;

                        newPlant.PlantType = PlantTypes.Where(x => x.Name == pi.TipologiaImpianto).SingleOrDefault();
                        newPlant.PlantClass = PlantClasses.Where(x => x.Name == pi.ClasseImpianto).SingleOrDefault();

                        newPlant.Code = pi.CodiceImpianto;
                        newPlant.PlantDistinctCode = pi.CodImpProvincia;

                        ThermalUnit currentThermalUnit;
                        currentThermalUnit = importThermalUnits.Where(x => x.CodiceImpianto == newPlant.Code).Select(x => new ThermalUnit
                        {
                            FirstStartUp = x.DataPrimaAccensione ,
                            Fuel = _context.Fuels.Where(f => f.Name == pi.Combustibile).FirstOrDefault(),
                            Kind = ThermalUnitKindEnum.SingleThermalUnit,
                            Manifacturer = Manifacturers.Where(m => m.Name == x.Marca).First(),
                            Model = ManifacturerModels.Where(mm => mm.Manifacturer.Name == x.Marca && mm.Model == x.ModelloCaldaia).FirstOrDefault(),
                            NominalThermalPowerMax = x.PotenzaMassimaBruciatore,
                            SerialNumber = x.MatricolaCaldaia,
                            ThermalEfficiencyPowerMax = x.Rendimento,
                            Warranty = x.DescrizioneGaranzia,
                            InstallationDate = x.DataInstallazione, 
                            HeatTransferFluidID = 1
                        }).FirstOrDefault();

                        newPlant.ThermalUnit = currentThermalUnit;
                        newPlantList.Add(newPlant);
                    }

                }

                _context.ThermalUnits.RemoveRange(_context.ThermalUnits.ToList());

                _context.Plants.RemoveRange(_context.Plants.ToList());
                _context.Plants.AddRange(newPlantList);
                
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }


        }

        private bool PlantFileIsValid(string plantFileText)
        {
            try
            {
                string[] rows;
                string[] fields;

                //scompongo il testo ricevuto in righe, splittando su '\n'
                rows = plantFileText.Split(new char[] { '\n' });

                //scompongo la prima riga in colonne, splittando su ';'
                fields = rows[0].Split(new char[] { ';' });

                if (fields.Count() == 19)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            };

        }

        private bool ThermalUnitFileIsValid(string thermalUnitFileText)
        {
            try
            {
                string[] rows;
                string[] fields;

                //scompongo in righe
                rows = thermalUnitFileText.Split(new char[] { '\n' });

                //scompongo in colonne
                fields = rows[0].Split(new char[] { ';' });

                if (fields.Count() == 27)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private List<PlantImport> MapToPlantList(string fileContent)
        {
            List<PlantImport> result = new List<PlantImport>();

            if (PlantFileIsValid(fileContent))
            {
                string[] rows = null;
                string[] fields = null;
                rows = fileContent.Split(new char[] { '\n' });

                for (int i = 1; i < rows.Count() - 1; i++)
                {
                    fields = rows[i].Split(new char[] { ';' });

                    PlantImport p = new PlantImport();
                    p.CAP = fields[13];
                    p.ClasseImpianto = fields[9];
                    p.CodiceImpianto = Convert.ToInt32(fields[2]);
                    p.CodImpProvincia = fields[11];
                    p.Combustibile = fields[17];
                    p.Comune = fields[12];
                    p.Frazione = fields[15];
                    p.GruppoImpianto = fields[0];
                    p.IndirizzoImpianto = fields[4];
                    p.Nominativo = fields[3];
                    p.NumeroCivico = fields[5];
                    p.Provincia = fields[14];
                    p.SuffissoGruppo = fields[1];
                    p.Telefono1 = fields[6];
                    p.Telefono2 = fields[7];
                    p.Telefono3 = fields[8];
                    p.TipologiaImpianto = fields[10];

                    result.Add(p);
                }
            }
            return result;

        }

        private List<ThermalUnitImport> MapToThermalUnitList(string fileContent)
        {
            List<ThermalUnitImport> result = new List<ThermalUnitImport>();
            if (ThermalUnitFileIsValid(fileContent))
            {
                string[] rows = null;
                string[] fields = null;
                rows = fileContent.Split(new char[] { '\n' });

                for (int i = 1; i < rows.Count() - 1; i++)
                {
                    fields = rows[i].Split(new char[] { ';' });

                    ThermalUnitImport tu = new ThermalUnitImport();
                    tu.AnnoCostruzione = Convert.ToInt32(fields[11]);
                    tu.AnnoCostruzioneBruciatore = Convert.ToInt32(fields[22]);
                    tu.CodiceImpianto = Convert.ToInt32(fields[0]);
                    tu.CodiceProduttoreBruciatore = fields[22];

                    DateTime PrimaAccensione ;
                    if (DateTime.TryParse(fields[10], out PrimaAccensione))
                    {
                        tu.DataPrimaAccensione = PrimaAccensione;
                    }
                    else
                    {
                        tu.DataPrimaAccensione = null;
                    }

                    DateTime Installazione;
                    if (DateTime.TryParse(fields[12], out Installazione))
                    {
                    tu.DataInstallazione = Installazione;
                    }
                    else
                    {
                        tu.DataInstallazione = null;
                    }

                    tu.Marca = fields[6];
                    tu.MarcaBruciatore = fields[18];
                    tu.MatricolaBruciatore = fields[20];
                    tu.MatricolaCaldaia = fields[8];
                    tu.ModelloBruciatore = fields[19];
                    tu.ModelloCaldaia = fields[7];
                    tu.PortataTermica = Convert.ToSingle(fields[15]);
                    tu.PotenzaMassimaBruciatore = Convert.ToSingle(fields[25]);
                    tu.PotenzaMinimaBruciatore = Convert.ToSingle(fields[24]);
                    tu.PotenzaNominaleKW = Convert.ToSingle(fields[14]);
                    tu.Rendimento = Convert.ToSingle(fields[16]);
                    tu.UbicazioneCaldaia = fields[9];

                    result.Add(tu);
                }
            }
            return result;
        }
    }
}

