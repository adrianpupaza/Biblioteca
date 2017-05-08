using System.Collections.Generic;

namespace BusinessLayer.ViewModels
{
    public class ListBookViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
