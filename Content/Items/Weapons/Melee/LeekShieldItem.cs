﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace AllBeginningsMod.Content.Items.Weapons.Melee
{
    public class LeekShieldItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leek Shield");
            Tooltip.SetDefault("I'm sure some bird would love to hold this" +
                "\nCan either be used as a weapon or an accessory");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = Item.height = 32;
            Item.damage = 18;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 3f;
            Item.useAnimation = 15;
            Item.useTime = 50;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(gold: 1, silver: 80);
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.LeekShieldProjectile>();
            Item.shootSpeed = 10f;
            Item.noMelee = Item.noUseGraphic = true;

            Item.defense = 5;
            Item.accessory = true;
        }
    }
}
