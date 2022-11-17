using domain;

namespace service;
public interface IPatientService
{
    IEnumerable<Patient> GetAll();
    Patient? Get(int id);
    bool Update(Patient entity);
    Patient Add(Patient entity);
    bool Delete(Patient entity);
} 