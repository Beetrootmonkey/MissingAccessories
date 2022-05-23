using MissingAccessories.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MissingAccessories.Projectiles
{
    public class PoisonedThrowingKnife : ThrowingKnife
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.thrown = true;
            aiType = ProjectileID.VampireKnife;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(target, damage, knockback, crit);
            if (Main.rand.Next(0, 2) == 0)
            {
                target.AddBuff(20, 10 * 60);
            }
        }

        // Additional hooks/methods here.
    }
}