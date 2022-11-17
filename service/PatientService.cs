using domain;
using infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class PatientService : IPatientService
    {
        ILocalRepository<Patient> _localRepository;
        public PatientService(ILocalRepository<Patient> localRepository)
        {
            _localRepository = localRepository;
        }
        public Patient Add(Patient entity)
        {
            return _localRepository.Add(entity);
        }

        public bool Delete(Patient entity)
        {
            return _localRepository.Delete(entity);
        }

        public Patient? Get(int id)
        {
            return _localRepository.Get(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _localRepository.GetAll();
        }

        public bool Update(Patient entity)
        {
            return _localRepository.Update(entity);
        }
    }
}
