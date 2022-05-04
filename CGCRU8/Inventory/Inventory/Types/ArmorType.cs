﻿namespace Types
{
    internal class ArmorType : ItemType {}

    internal class Helmet : ArmorType
    {
        public override string Name => "Helmet";
        public override string Description => "Helms are Armor in Dark Souls 3 that protects the player's head. It is speculated that they will work the same way as previous Souls games, by simply adding their defense values to a total that is then used to calculate how much damage is taken. Click the header to sort";
    }

    internal class Chest : ArmorType
    {
        public override string Name => "Chest";
        public override string Description => "Chest Armors are Armor in Dark Souls 3 that protects the player's torso. Click the table header to sort";
    }

    internal class Gauntlet : ArmorType
    {
        public override string Name => "Gauntlet";
        public override string Description => "Gauntlets are Armor in Dark Souls 3 that protects the player's arms. It is speculated that they will work the same way as previous Souls games, by simply adding their defense values to a total that is then used to calculate how much damage is taken. Click the table header to sort.";
    }

    internal class Leggings : ArmorType
    {
        public override string Name => "Leggings";
        public override string Description => "Leggings or Leg Armor is Armor in Dark Souls 3 that protects the player's legs. They will work the same way as previous Souls games, by simply adding their defense values to a total that is then used to calculate how much damage is taken. Click the table header to sort.";
    }
}
