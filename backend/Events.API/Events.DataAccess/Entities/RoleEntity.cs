namespace Events.DataAccess.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IList<PermissionEntity> Permissions { get; set; } = [];

        public IList<UserEntity> Users { get; set; } = [];
    }
}