using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EF6
{

    #region snippet_IDbContextFactory
    public class UniversityContextFactory : IDbContextFactory<UniversityContext>
    {
        public UniversityContext Create()
        {
            return new EF6.UniversityContext("Server=(localdb)\\mssqllocaldb;Database=EF6MVCCore;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
    #endregion
}
