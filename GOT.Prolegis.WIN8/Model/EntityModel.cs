using GOT.Prolegis.Portable.Authentication;
using GOT.Prolegis.Portable.Entities;
using GOT.Prolegis.WIN8.Model.Intefaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT.Prolegis.WIN8.Model
{
    [Export(typeof(IEntityModel))]
    public class EntityModel : IEntityModel
    {
        #region Constructor 
        public EntityModel()
        {

        }
        #endregion

        #region IEntityModel Implementation 
        public async Task<IEnumerable<tblEntity>> ListEntities()
        {
            return await App.MobileService.GetTable<tblEntity>().ToEnumerableAsync();
        }
        public async void SaveEntity(tblEntity entity)
        {
            if (entity.id == 0) await App.MobileService.GetTable<tblEntity>().InsertAsync(entity);
            else await App.MobileService.GetTable<tblEntity>().UpdateAsync(entity);
        }
        #endregion
    }
}
