using GOT.Prolegis.Portable.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GOT.Prolegis.WIN8.Model.Intefaces
{
    public interface IEntityModel
    {
        Task<IEnumerable<tblEntity>> ListEntities();
        void SaveEntity(tblEntity entity);
    }
}
