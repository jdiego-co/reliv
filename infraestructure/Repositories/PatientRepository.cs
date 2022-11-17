using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraestructure.Repositories
{
    public class PatientRepository : GenericRepository<Patient>
    {
        public PatientRepository(LocalDbContext db) : base(db)
        {

        }
    }
}
