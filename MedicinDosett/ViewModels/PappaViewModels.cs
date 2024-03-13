using MedicinDosett.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicinDosett.ViewModels
{
    public class PappaViewModels

    {
        private static readonly PappaViewModels instansAvDenHärKlassen = new PappaViewModels();
        public static PappaViewModels Inst()
        {
            return instansAvDenHärKlassen;
        }
        public List<PappaMedicin> pappaMedicins { get; set; }
        public List<PappaMedicin> morningMedicins { get; set; }
        public List<PappaMedicin> dayMedicins { get; set; }
        public List<PappaMedicin> eveningMedicins { get; set; }
        public List<PappaMedicin> ifNecessaryMedicins { get; set; }

        private PappaViewModels()
        {

            pappaMedicins = new List<PappaMedicin>();

            morningMedicins = new List<PappaMedicin>();
            dayMedicins = new List<PappaMedicin>();
            eveningMedicins = new List<PappaMedicin>();
            ifNecessaryMedicins = new List<PappaMedicin>();


            pappaMedicins.Add(new PappaMedicin
            {
                Name = "Alvedon",
                Dose = "1 filmdragerad tablett 500mg, Paracetamol",
                Info = "Vid värk och smärta",
                Time = "Vid behov"
            });
            pappaMedicins.Add(new PappaMedicin
            {
                Name = "Atorvastatin",
                Dose = "1 filmdragerad tablett 40mg, Atorvastatin",
                Info = "Blodfettsänkande och hjärtskyddande",
                Time = "Kväll"
            });
            pappaMedicins.Add(new PappaMedicin
            {
                Name = "Betolvidon",
                Dose = "1 tablett 1mg, Cyanokobalamin",
                Info = "Mot vitaminbrist",
                Time = "Dag"
            });
            pappaMedicins.Add(new PappaMedicin
            {
                Name = "Divisun",
                Dose = "1 tablett 800 IE Viatris AB, Kolekalciferol",
                Info = "D-vitamin",
                Time = "Dag"
            });
            pappaMedicins.Add(new PappaMedicin
            {
                Name = "Ezetimib Sandoz",
                Dose = "1 tablett 10mg, Ezetimib",
                Info = "För blodfetter",
                Time = "Dag"
            });
            pappaMedicins.Add(new PappaMedicin
            {
                Name = "Furix",
                Dose = "1 tablett 40mg, Furosemid",
                Info = "1-2 tabletter,Vätskedrivande",
                Time = "Morgon"
            });
            pappaMedicins.Add(new PappaMedicin
            {
                Name = "Glytrin",
                Dose = "sublingualspray 0,4mg/dos Orifarm AB, Glyceryltrinitrat",
                Info = "Mot bröstsmärta",
                Time = "Vid behov"
            });
            pappaMedicins.Add(new PappaMedicin
            {
                Name = "Hermolepsin Retard",
                Dose = "1 Depotablett 100mg, karbamazepin",
                Info = "Antileptika",
                Time = "kväll"
            });
            pappaMedicins.Add(new PappaMedicin
            {
                Name = "Imdur",
                Dose = "1 Depotablett 30mg,isosorbidmononitrat",
                Info = "Kärlvidgande",
                Time = "Morgon"
            });
            pappaMedicins.Add(new PappaMedicin
            {
                Name = "Tegretol Retard",
                Dose = "1 Depotablett 200mg, karbamazepin",
                Info = "Antiepileptikum",
                Time = "Morgon"
            });
            pappaMedicins.Add(new PappaMedicin
            {
                Name = "Xarelto",
                Dose = "1 filmdragerad tablett 20mg, Rivaroxaban",
                Info = "Blodförtunnande",
                Time = "Morgon"
            });

            morningMedicins = pappaMedicins.Where(m => m.Time.ToLower() == "morgon").ToList();
            dayMedicins = pappaMedicins.Where(m => m.Time.ToLower() == "dag").ToList();
            eveningMedicins = pappaMedicins.Where(m => m.Time.ToLower() == "kväll").ToList();
            ifNecessaryMedicins = pappaMedicins.Where(m => m.Time.ToLower() == "vid behov").ToList();



        }
      

    }
}
