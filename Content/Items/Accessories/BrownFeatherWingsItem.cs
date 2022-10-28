﻿using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllBeginningsMod.Content.Items.Accessories;

[AutoloadEquip(EquipType.Wings)]
public sealed class BrownFeatherWingsItem : ModItem
{
    public override void SetStaticDefaults() {
        ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(30);
    }

    public override void SetDefaults() {
        Item.accessory = true;

        Item.width = 18;
        Item.height = 24;

        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 50);
    }

    public override void VerticalWingSpeeds(
        Player player,
        ref float ascentWhenFalling,
        ref float ascentWhenRising,
        ref float maxCanAscendMultiplier,
        ref float maxAscentMultiplier,
        ref float constantAscend
    ) {
        ascentWhenFalling = 0.5f;
        ascentWhenRising = 0.05f;
        maxCanAscendMultiplier = 0.5f;
        maxAscentMultiplier = 1f;
        constantAscend = 0.05f;
    }
}