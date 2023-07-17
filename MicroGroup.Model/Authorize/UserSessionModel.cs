namespace MicroGroup.Model.Authorize
{
    public class UserSessionModel
    {
        public long PersonnelId { get; set; }
        public string Username { get; set; }
        public List<Role> Roles { get; set; }
    }
}
