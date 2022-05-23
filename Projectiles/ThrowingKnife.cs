using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MissingAccessories.Projectiles
{
    public class ThrowingKnife : ModProjectile
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

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //Main.PlaySound(SoundID.Dig, projectile.position);
            int amount = Main.rand.Next(4, 8);
            for (int i = 0; i < amount; i++)
            {
                int dust = Dust.NewDust(projectile.position, 5, 5, DustID.Stone, 0f, 0f, 50);
                Main.dust[dust].velocity *= 0.2f;
                Main.dust[dust].velocity += projectile.velocity * 0.2f + new Vector2((float)Main.rand.Next(-2, 2), (float)Main.rand.Next(-2, 2));
            }
            return base.OnTileCollide(oldVelocity);
        }

        // Additional hooks/methods here.
    }
}