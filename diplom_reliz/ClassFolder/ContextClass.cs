using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using diplom_reliz.ClassFolder;
using diplom_reliz.DataFolder;

namespace diplom_reliz.DataFolder
{
    public partial class DBEntities : DbContext
    {
        private static DBEntities context;

        public static DBEntities GetContext()
        {
            if (context == null)
            {
                context = new DBEntities();
            }
            return context;
        }
    }
}
