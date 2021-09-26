using Core.Entities.Concrete;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IClaimService
    {
        IResult AddUserClaim(User user);
    }
}
