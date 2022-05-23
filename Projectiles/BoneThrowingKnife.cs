using Microsoft.Xna.Framework;
using MissingAccessories.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MissingAccessories.Projectiles
{
    public class BoneThrowingKnife : ThrowingKnife
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.penetrate = 6;
            projectile.thrown = true;
            aiType = ProjectileID.VampireKnife;
        }
    }
}