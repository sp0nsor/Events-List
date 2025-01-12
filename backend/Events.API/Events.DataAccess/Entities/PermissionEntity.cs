namespace Events.DataAccess.Entities
{
    public class PermissionEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IList<RoleEntity> Roles { get; set; } = [];
    }
}