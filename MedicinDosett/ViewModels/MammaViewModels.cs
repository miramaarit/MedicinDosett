using MedicinDosett.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinDosett.ViewModels
{
    internal class MammaViewModels
    {
        private static readonly MammaViewModels instansAvDenHärKlassen = new MammaViewModels();//singelton
        public static MammaViewModels Inst()
        {
            return instansAvDenHärKlassen;
        }
        public List<MammaMedicin> MammaMedicins{ get; set; }
        public List<MammaMedicin> morningMedicins { get; set; }
        public List<MammaMedicin> dayMedicins { get; set; }
        public List<MammaMedicin> eveningMedicins{ get; set; }
        public List<MammaMedicin> ifNecessaryMedicins{ get; set; }

        private MammaViewModels() 
        { 
         MammaMedicins = new List<MammaMedicin>();

            var task = Task.Run(() => GetmammaMedicinsFromDb());
            task.Wait();
            MammaMedicins.AddRange(task.Result);

            morningMedicins =MammaMedicins.Where(m => m.Time.ToLower().Contains ("morgon")).ToList();
            dayMedicins = MammaMedicins.Where(m => m.Time.ToLower().Contains("dag")).ToList();
            eveningMedicins = MammaMedicins.Where(m => m.Time.ToLower().Contains("kväll")).ToList();
            ifNecessaryMedicins = MammaMedicins.Where(m => m.Time.ToLower().Contains("vid behov")).ToList();
        }

        private async Task<List<MammaMedicin>> GetmammaMedicinsFromDb()
        {
            List<Models.MammaMedicin> mammamedicinsFromDb = await Data.DB.MedicinCollection().AsQueryable().ToListAsync();
            return mammamedicinsFromDb;
        }
        public async Task UpdateMammaMedicinsFromDb()
        {
            MammaMedicins.Clear();
            morningMedicins.Clear();
            dayMedicins.Clear();
            eveningMedicins.Clear();
            ifNecessaryMedicins.Clear();

            var task = Task.Run(() => GetmammaMedicinsFromDb());
                task.Wait();
                MammaMedicins.AddRange(task.Result);
            
        }
    }
}
