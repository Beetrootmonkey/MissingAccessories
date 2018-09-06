using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace missingaccessories.Items
{
    public class Chain2 : Chain
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Double Shackle");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = 1;
            item.defense = 2;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shackle);
            recipe.AddIngredient(ItemID.Shackle);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
