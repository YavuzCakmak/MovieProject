using MicroGroup.Model.Model.Authorize;
using MicroGroup.Model.Utilities.Authentication;
using MicroGroup.Model.Utilities;

namespace MicroGroup.Business.Services.Abstraction
{
    public interface IAuthorizeService
    {
        LoginResponseModel Login(LoginModel loginModel);
        DataResult Register(PersonnelModel personnelModel);
    }
}
