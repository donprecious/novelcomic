using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using Webnovel.Models;

namespace Webnovel.Services
{
    [Headers("Content-Type: application/json")]

     public  interface IRavePayment
     {

         [Post("/verify")]
         Task<RaveVerificationResponseModel> Verify([Body] RaveVerificationData data);
     }
}
