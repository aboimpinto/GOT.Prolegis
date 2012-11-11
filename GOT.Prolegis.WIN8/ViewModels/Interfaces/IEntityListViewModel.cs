using GalaSoft.MvvmLight.Command;
using GOT.Prolegis.Portable.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT.Prolegis.WIN8.ViewModels.Interfaces
{
    public interface IEntityListViewModel
    {
        IEnumerable<tblEntity> Entities { get; set; }
        tblEntity EntitySelected { get; set; }

        RelayCommand NewEntityCommand { get; }
    }
}
