using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MissingAccessories.Items.Accessories
{
    public class Chain3 : Chain
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Triple Shackle");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = 1;
            item.defense = 3;
            item.value = Item.sellPrice(0, 0, 45, 0);
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this.mod, "Chain2");
            recipe.AddIngredient(ItemID.Shackle);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
