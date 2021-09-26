using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ClaimManager : IClaimService
    {
        IClaimDal _claimDal;

        public ClaimManager(IClaimDal claimDal)
        {
            _claimDal = claimDal;
        }

        public IResult AddUserClaim(User user)
        {
            UserOperationClaim userOperationClaim = new UserOperationClaim() { OperationClaimId = 1002 , UserId = user.Id};
            _claimDal.Add(userOperationClaim);
            return new SuccessResult();
        }
    }
}
