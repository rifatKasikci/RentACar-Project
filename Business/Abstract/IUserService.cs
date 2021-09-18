using Core.Utilities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        IResult Update(UserUpdateDto userUpdateDto);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int id);
        IDataResult<UserDetailDto> GetUserDetailsByEmail(string email);
        User GetByEmail(string email);
        List<OperationClaim> GetClaims(User user);
        
    }
}
