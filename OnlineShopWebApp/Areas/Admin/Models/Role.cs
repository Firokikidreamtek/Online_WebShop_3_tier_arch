using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Название не заполнено")]
        public string Name { get; set; }
    }
}