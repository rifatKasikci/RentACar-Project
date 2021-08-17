using Core.Utilities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int id);
        User GetByEmail(string email);
        List<OperationClaim> GetClaims(User user);
        
    }
}
