using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFindeksScoreService
    {
        IResult Add(FindeksScore findeksScore);
        IResult Update(FindeksScore findeksScore);
        IResult Delete(FindeksScore findeksScore);
        IDataResult<FindeksScore> GetByCustomerId(int customerId);
    }
}
