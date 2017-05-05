using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataAccess.EntityFramework;

namespace BusinessLayer.ViewModels
{
    public class ListClientViewModel
    {
        public IList<ClientViewModel> Clients { get; set; }
    }
}
