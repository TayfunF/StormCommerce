using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StormCommerce.Models.Enums
{
    public enum OrderState
    {
        Bekliyor,

        [Display(Name = "Tamamlandı")]
        Tamamlandi
    }
}