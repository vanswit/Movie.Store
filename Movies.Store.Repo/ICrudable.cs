using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Repo
{
    public interface ICrudable<T>
    {
        IEnumerable<T> GetAllEntries();
        int SaveOrUpdate(T item);
        T GetByID(int ID);
    }
}
