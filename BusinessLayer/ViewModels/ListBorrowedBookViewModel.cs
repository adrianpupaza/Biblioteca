using System.Collections.Generic;

namespace BusinessLayer.ViewModels
{
    public class ListBorrowedBookViewModel
    {
        public IEnumerable<BorrowedBookViewModel> BorrowedBooks { get; set; }
    }
}
