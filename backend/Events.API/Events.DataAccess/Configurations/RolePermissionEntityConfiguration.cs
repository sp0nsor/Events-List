using Events.Core.Enums;
using Events.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Events.DataAccess.Configurations
{
    public class RolePermissionEntityConfiguration
        : IEntityTypeConfiguration<RolePermissionEntity>
    {
        private readonly AuthorizationOptions authorization;

        public RolePermissionEntityConfiguration(
            AuthorizationOptions authorization)
        {
            this.authorization = authorization;
        }

        public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
        {
            builder.HasKey(r => new { r.RoleId, r.PermissionId });

            builder.HasData(ParseRolePermisions());
        }

        private RolePermissionEntity[] ParseRolePermisions()
        {
            return authorization.RolePermissions
                .SelectMany(rp => rp.Permissions
                    .Select(p => new RolePermissionEntity()
                    {
                        RoleId = (int)Enum.Parse<Role>(rp.Role),
                        PermissionId = (int)Enum.Parse<Permission>(p)
                    }))
                .ToArray();
        }
    }
}
