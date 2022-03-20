using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberPaintSite.Models.DTO.Auth
{
    public class LoginDto
    {
        //[Required(ErrorMessage = "Kullanıcı Adı boş geçilemez")]
        //[Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }
        //[DataType(DataType.Password)]
        //[Display(Name = "Parola :")]
        //[Required(ErrorMessage = "Parola alanı boş geçilemez")]
        public string Password { get; set; }

        //[Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
