using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseManager.Data.Db
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Repository
    {
        public IQueryable<Repository> Repositories
        {
            get
            {
                return new List<Repository>().AsQueryable();
            }
        }
    }
}
