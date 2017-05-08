using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BusinessLayer.ViewModels
{
    public class BorrowedBookViewModel
    {
        [Required]
        [DisplayName("Book")]
        public int BookId { get; set; }
        [Required]
        [DisplayName("Client")]
        public int ClientId { get; set; }
        public int Id { get; set; }
        public bool Returned { get; set; }
        [Required]
        public IEnumerable<SelectListItem> Books { get; set; }
        public IEnumerable<SelectListItem> Clients { get; set; }
        public string ClientName { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
    }
}
