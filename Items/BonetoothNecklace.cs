using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace missingaccessories.Items
{
    public class BonetoothNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gain increased armor penetration and damage with"
                + "\neach unique boss/invasion you defeat"
                + "\nCan be transformed once it is at 20 stacks"
                + "\n'The Hunt is On!'");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 28;
            item.rare = 8;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.accessory = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            const string bonusTooltip = "necklacebonus";
            TooltipLine tip = tooltips.Find(t => t.Name == bonusTooltip);
            if (tip != null)
            {
                tooltips.Remove(tip);
            }
            if (CanRightClick())
            {
                tooltips.Add(new TooltipLine(this.mod, bonusTooltip,
                "Rightclick to transform"));
            }
            else
            {
                tooltips.Add(new TooltipLine(this.mod, bonusTooltip,
                string.Format("Increases armor penetration by {0}"
                    + "\nIncreases damage by {1}%",
                GetPenetrationBonus(), GetDamageBonus())));
            }

            if (GetBossesDowned() > 0)
            {
                const string nameTooltip = "ItemName";
                tip = tooltips.Find(t => t.Name == nameTooltip);
                if (tip != null)
                {
                    tooltips.Remove(tip);
                }
                if (CanRightClick())
                {
                    tooltips.Insert(0, new TooltipLine(this.mod, nameTooltip,
                    "Bonetooth Necklace (Full)"));
                }
                else
                {
                    tooltips.Insert(0, new TooltipLine(this.mod, nameTooltip,
                    string.Format("Bonetooth Necklace ({0})",
                    GetBossesDowned())));
                }
                
            }

            //tooltips.ForEach(t => t.text = t.Name);
        }

        private int GetDamageBonus()
        {
            return GetBossesDowned() / 2;
        }

        private int GetPenetrationBonus()
        {
            return (1 + GetBossesDowned()) / 2;
        }

        public static int GetBossesDowned()
        {
            int bossCount = 0;
            if (NPC.downedAncientCultist)
            {
                bossCount++;
            }
            if (NPC.downedBoss1)
            {
                bossCount++;
            }
            if (NPC.downedBoss2)
            {
                bossCount++;
            }
            if (NPC.downedBoss3)
            {
                bossCount++;
            }
            if (NPC.downedChristmasIceQueen)
            {
                bossCount++;
            }
            if (NPC.downedChristmasSantank)
            {
                bossCount++;
            }
            if (NPC.downedChristmasTree)
            {
                bossCount++;
            }
            if (NPC.downedFishron)
            {
                bossCount++;
            }
            if (NPC.downedFrost)
            {
                bossCount++;
            }
            if (NPC.downedGoblins)
            {
                bossCount++;
            }
            if (NPC.downedGolemBoss)
            {
                bossCount++;
            }
            if (NPC.downedHalloweenKing)
            {
                bossCount++;
            }
            if (NPC.downedHalloweenTree)
            {
                bossCount++;
            }
            if (NPC.downedMartians)
            {
                bossCount++;
            }
            if (NPC.downedMechBoss1)
            {
                bossCount++;
            }
            if (NPC.downedMechBoss2)
            {
                bossCount++;
            }
            if (NPC.downedMechBoss3)
            {
                bossCount++;
            }
            if (NPC.downedMoonlord)
            {
                bossCount++;
            }
            if (NPC.downedPirates)
            {
                bossCount++;
            }
            if (NPC.downedPlantBoss)
            {
                bossCount++;
            }
            if (NPC.downedQueenBee)
            {
                bossCount++;
            }
            if (NPC.downedSlimeKing)
            {
                bossCount++;
            }
            if (NPC.downedTowers)
            {
                bossCount++;
            }
            if (Main.hardMode)
            {
                bossCount++;
            }
            // 24x

            return bossCount;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += GetPenetrationBonus();
            float damageBonus = GetDamageBonus() * 0.01f;
            player.meleeDamage += damageBonus;
            player.rangedDamage += damageBonus;
            player.magicDamage += damageBonus;
            player.minionDamage += damageBonus;
            player.thrownDamage += damageBonus;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.Chain);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        

        public override bool CanRightClick()
        {
            return GetDamageBonus() >= 20;
        }

        public override void RightClick(Player player)
        {
            Item item = this.item;
            bool favorited = item.favorited;
            int stack = item.stack;
            Item obj1 = new Item();
            obj1.netDefaults(mod.GetItem("StackedBonetoothNecklace").item.type);
            Item obj2 = obj1.CloneWithModdedDataFrom(item);
            obj2.Prefix(this.item.prefix);
            int index = Utils.GetIndexInArray(player.inventory, item);
            item = obj2.Clone();
            item.position.X = player.position.X + (float)(player.width / 2) - (float)(item.width / 2);
            item.position.Y = player.position.Y + (float)(player.height / 2) - (float)(item.height / 2);
            item.favorited = favorited;
            player.inventory[index] = item;
            ItemText.NewText(item, item.stack, true, false);
            Main.PlaySound(SoundID.Item37, -1, -1);
        }
    }
}
