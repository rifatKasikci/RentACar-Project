using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindeksScoreManager : IFindeksScoreService
    {

        IFindeksScoreDal _findeksScoreDal;

        public FindeksScoreManager(IFindeksScoreDal findeksScoreDal)
        {
            _findeksScoreDal = findeksScoreDal;
        }

        public IResult Add(FindeksScore findeksScore)
        {
            _findeksScoreDal.Add(findeksScore);
            return new SuccessResult(Messages.FindeksScoreAdded);
        }

        public IResult Delete(FindeksScore findeksScore)
        {
            _findeksScoreDal.Delete(findeksScore);
            return new SuccessResult(Messages.FindeksScoreDeleted);
        }

        public IDataResult<FindeksScore> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<FindeksScore>(_findeksScoreDal.Get(fc=>fc.CustomerId==customerId));
        }

        public IResult Update(FindeksScore findeksScore)
        {
            _findeksScoreDal.Update(findeksScore);
            return new SuccessResult(Messages.FindeksScoreUpdated);
        }
    }
}
