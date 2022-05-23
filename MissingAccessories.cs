using MissingAccessories.Projectiles;
using Terraria.ModLoader;

namespace MissingAccessories
{
	class MissingAccessories : Mod
	{
		public MissingAccessories()
		{
		}

        public override void Load()
        {
            base.Load();
            //AddProjectile("FanThrowingKnife0", new FanThrowingKnife());
        }
    }
}
