﻿using AllBeginningsMod.Content.Projectiles.Melee;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllBeginningsMod.Content.Items.Weapons.Melee
{
    public sealed class LeekSwordItem : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Leek Sword");
            Tooltip.SetDefault("I'm sure some bird would love to hold this" + "\n" + "Giving your enemies a swift death");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults() {
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.damage = 24;
            Item.DamageType = DamageClass.Melee;

            Item.knockBack = 2f;

            Item.width = 46;
            Item.height = 48;

            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.shoot = ModContent.ProjectileType<LeekSwordProjectile>();

            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(gold: 1, silver: 20);
        }
    }
}