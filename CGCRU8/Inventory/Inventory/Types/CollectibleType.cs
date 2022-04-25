namespace Types
{
    internal class CollectibleType : ItemType {}

    internal class KeyItem : CollectibleType
    {
        public override string Name => "Key Item";
        public override string Description => "Key Items in Dark Souls 3 allow players to advance certain questlines, allow access to undiscoverd areas, and diversify the inventories of merchants.";
    }

    internal class MultiplayerItem : CollectibleType
    {
        public override string Name => "Multiplayer Item";
        public override string Description => "Multiplayer Items in Dark Souls 3 will be used to interact with other players. Either by writing them messages or by summoning and being summoned.";
    }

    internal class Consumable : CollectibleType
    {
        public override string Name => "Consumable";
        public override string Description => "Consumables in Dark Souls 3 are used to gain temporary benefits or deal damage.";
    }

    internal class Tool : CollectibleType
    {
        public override string Name => "Tool";
        public override string Description => "Tools in Dark Souls 3 are helpful items that can be used indefinitely.";
    }

    internal class Projectile : CollectibleType
    {
        public override string Name => "Projectile";
        public override string Description => "Projectiles in Dark Souls 3 are offensive items that can be thrown at enemies.";
    }

    internal class Ammunition : CollectibleType
    {
        public override string Name => "Ammunition";
        public override string Description => "Ammunition in Dark Souls 3 are items that can be used with Bows, Greatbows and Crossbows, a player can equip two types of bolts and arrows at the same time.";
    }

    internal class Soul : CollectibleType
    {
        public override string Name => "Soul";
        public override string Description => "Souls in Dark Souls 3 are used to gain expendable souls to make purchases, level up, or repair your equipment.";
    }

    internal class BossSoul : CollectibleType
    {
        public override string Name => "Boss Soul";
        public override string Description => "Boss Souls and other special souls in Dark Souls 3 are powerful items that can be converted into new Weapons, Magic, or Items via Soul Transposition from Ludleth of Courland. They may also be consumed to gain a large amount of souls.";
    }

    internal class Ore : CollectibleType
    {
        public override string Name => "Ore";
        public override string Description => "Ore in Dark Souls 3 are items that can be used to improve Weapons and Shields via Upgrades. These are done at the Shrine via the Blacksmith. In contrast to previous Dark Souls games, now Armor isn't upgradable at all.";
    }

    internal class Ash : CollectibleType
    {
        public override string Name => "Umbral Ash";
        public override string Description => "Umbral Ashes in Dark Souls 3 are used to unlock more items from Merchants. By giving Merchants different Ashes, they will sell new and different Weapons, Armor and Items. Below is a list of Ashes that can be found in Dark Souls 3.";
    }
}
