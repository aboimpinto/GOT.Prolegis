using GOT.Prolegis.WIN8.Libs;
using GOT.Prolegis.WIN8.Model.Intefaces;
using System.Composition;

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
        //public async Task<IEnumerable<tblEntity>> ListEntities()
        //{
        //    return await App.MobileService.GetTable<tblEntity>().ToEnumerableAsync();
        //}
        //public async void SaveEntity(tblEntity entity)
        //{
        //    if (entity.id == 0) await App.MobileService.GetTable<tblEntity>().InsertAsync(entity);
        //    else await App.MobileService.GetTable<tblEntity>().UpdateAsync(entity);
        //}
        #endregion
    }
}
