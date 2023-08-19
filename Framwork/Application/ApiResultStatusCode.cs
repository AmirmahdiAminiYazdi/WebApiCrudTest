using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Framwork.Application
{
    public enum ApiResultStatusCode
    {
        
        [Display(Name = "Your operation successfully done")]
        Success = 0,

      
        [Display(Name = "Internal server error")]
        ServerError = 1,

      
        [Display(Name = "Error in parameters")]
        BadRequest = 2,

       
        [Display(Name = "Not found")]
        NotFound = 3,

        [Display(Name = "Empty list")]
        ListEmpty = 4,

       
        [Display(Name = "Logical error")]
        LogicError = 5,

        
        [Display(Name = "UnAuthorized")]
        UnAuthorized = 6,

       
        MaxAttemptsFaild = 7,
    }
}
