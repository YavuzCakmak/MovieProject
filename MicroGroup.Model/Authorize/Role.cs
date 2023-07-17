using MicroGroup.Model.Model.Authorize;

namespace MicroGroup.Model.Authorize
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PrivilegeModel> Privileges { get; set; }
    }

}
