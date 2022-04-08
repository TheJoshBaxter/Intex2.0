using System;
using System.Collections.Generic;
using System.Linq;

namespace UtahTraffix.Models
{
    public interface ICrashRepository
    {
        IQueryable<Crash> Crashes { get; }

        public void SaveCrash(Crash crash);
        public void CreateCrash(Crash crash);
        public void DeleteCrash(Crash crash);

        public Crash getCrash(int id);
        public List<Crash> GetCrashesFiltered(int page, int crashesPerPage, string searchString, string filterColumn); //This needs to be edited... I deleted a lot of stuff out of this function
        public List<Crash> GetCrashesSimple(int page, int crashesPerPage);
    }
}
