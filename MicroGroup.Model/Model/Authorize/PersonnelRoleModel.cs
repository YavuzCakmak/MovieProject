using MicroGroup.Model.Model.Base;

namespace MicroGroup.Model.Model.Authorize
{
    public class PersonnelRoleModel : BaseModel
    {
        public PersonnelModel Personnel { get; set; }
        public RoleModel Role { get; set; }
    }
}
