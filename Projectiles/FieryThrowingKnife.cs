using MissingAccessories.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MissingAccessories.Projectiles
{
    public class FieryThrowingKnife : ThrowingKnife
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

        public override void AI()
        {
            base.AI();
            CreateDust();
        }

        public virtual void CreateDust()
        {
            if (Main.rand.Next(0, 10) == 0)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100);
                Main.dust[dust].velocity += projectile.velocity;
                Main.dust[dust].velocity *= 0.1f;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(target, damage, knockback, crit);
            if (Main.rand.Next(0, 2) == 0)
            {
                target.AddBuff(24, 10 * 60);
            }
        }

        // Additional hooks/methods here.
    }
}