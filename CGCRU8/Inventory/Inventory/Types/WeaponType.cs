namespace Types
{
    internal class WeaponType
    {
        public virtual string? Name { get; set; }
        public virtual string? Description { get; set; }
    }

    internal class Dagger : WeaponType
    {
        public override string Name => "Dagger";
        public override string Description => "Daggers are a Weapon type in Dark Souls 3. They are lightweight, small, and have fast attack speed. Their main positive is their Critical damage, which allows them to inflict incredible damage on backstabs and ripostes. Daggers also have fast attack as previously mentioned, and when buffed with a status effect like Bleed or a Pine Resin, they can get off massive damage in a short time. However, Daggers do have problems that set them back; Daggers have very short-range, often requiring the user to get up close to the opponent to inflict damage; they also lack the ability to trade with heavier weapons like Greatswords, Ultra Greathammers, and Ultra Greatswords due to their low poise damage and damage without buffs, so Dagger users will have to extremely cautious when going up against these weapons.";
    }

    internal class StraightSword : WeaponType
    {
        public override string Name => "Straight Sword";
        public override string Description => "Straight Swords are a Weapon type in Dark Souls 3. Straight Swords are the most basic type of weapon, but have solid reach and damage, fast attack speed and the Skill Stance, along with other versatile Weapon Arts. All these attributes make this weapon class a popular choice for beginners and experts and a good choice for both PvP and PvE.";
    }

    internal class Greatsword : WeaponType
    {
        public override string Name => "Greatsword";
        public override string Description => "Greatswords are a high damage, long reach weapon class. Plan to put a decent amount of points into Strength if you plan to use these weapons. They have various weapon Skills ranging from Stomp to Stance to unique Skills. In terms of damage output per stamina expended, Greatswords are easily the best value weapon category, and they are a good choice for PvE builds as a result.";
    }

    internal class UltraGreatsword : WeaponType
    {
        public override string Name => "Ultra Greatrsword";
        public override string Description => "Ultra Greatswords are a type of Weapon returning in Dark Souls 3. These Weapons usually do very high damage and have extremely slow attacks along with high Strength requirements. Ultra Greatswords benefit from 'hyper armor' during certain attack animations, allowing you to continue a combo even while being struck. Ultra Greatswords also cannot be parried when two-handed, with the exception of the rolling and running attacks. There are two types of Ultra Greatswords: Vertical and Horizontal. Horizontal Ultra Greatswords have the standard Ultra Greatsword moveset when they are 1 - handed and 2 - handed, but are good for hitting multiple opponents due to its wide range. Vertical Ultra Greatswords have the standard Ultra Greatsword moveset when they are 1 - handed, but when 2 - handed, the normal attacks turn into vertical slams and the ability to hit behind the user when the second normal attack is used.";
    }

    internal class CurvedSword : WeaponType
    {
        public override string Name => "Curved Sword";
        public override string Description => "Curved Swords are a Weapon type in Dark Souls 3. Curved Swords are a generally a Dexterity-based weapon class with fast swing speeds, decent damage and range, and a excellent roll-catching abilities. These traits allow a player to quickly and easily finish a fight, especially since most Curved Swords can be buffed with spells or Pine Resins. However, there are some negatives to Curved Swords. Players with high Poise and heavier weapons like Greatswords, Ultra Greatswords, and Great Hammers will be able to tank and out-trade hits from a Curved Sword if the user is just swinging mindlessly. Additionally, if players can easily be parried if they swing without caution. The positives of this weapon class seem to outweigh the negatives, and Curved Swords attract new players and experts alike, and are popular choices in PvE and PvP.";
    }

    internal class Katana : WeaponType
    {
        public override string Name => "Katana";
        public override string Description => "Katanas are a type of Weapon in Dark Souls 3. These Weapons usually do moderate to good damage and deal Bleed. These weapons have particularly strong running attacks. Like curved swords, they're utilized primarily for slashing attacks. While useful in many scenarios, their main downfall is their low durability (an issue that is easily solved in this game, due how durability works), and really low STR scaling (gaining almost no damage benefit from using them two handed).";
    }

    internal class CurvedGreatsword : WeaponType
    {
        public override string Name => "Curved Greatsword";
        public override string Description => "Curved Greatswords are a type of Weapon in Dark Souls 3. These Weapons usually do a good deal of damage per swing, but have slower attacks. Sometimes they also possess Auxiliary effects such as Bleed.";
    }

    internal class PiercingSword : WeaponType
    {
        public override string Name => "Piercing Sword";
        public override string Description => "Thrusting Swords are a type of Weapon in Dark Souls 3. These Weapons usually do little to moderate damage per swing, but attack rather quickly, have good reach, and are capable of punishing counter-attacks. Many can also attack from behind a raised shield. Thrusting Swords replace the kick with a quick retreating attack that does minor damage.";
    }

    internal class Axe : WeaponType
    {
        public override string Name => "Axe";
        public override string Description => "Axes are a Weapon type in Dark Souls 3. Axes usually do decent damage and are best used on Strength/Quality builds. Most of the Axes have the Skill Warcry, which provides the weapon with a damage boost for 30 seconds. Axes are generally considered to be worse than Straight Swords, due to their lower attack speed, weaker damage output, and having an arguably worse moveset and Skill spread. However, Axes do have their own positives.Axes deal higher stamina damage, and can roll catch with more or less to the same effectiveness than Straight Swords.";
    }

    internal class Greataxe : WeaponType
    {
        public override string Name => "Greataxe";
        public override string Description => "Greataxes are a type of Weapon in Dark Souls 3. Greataxes are larger versions of their Axe counterparts and are usually wielded two-handed. These Weapons usually do very high damage and have slower attacks. Great Axes tend to do more AoE attacks than Greatswords. ";
    }

    internal class Hammer : WeaponType
    {
        public override string Name => "Hammer";
        public override string Description => "Hammers is a general term for Maces and the like. Hammers generally attack the slowest of most traditional one-handed weapons, but generally deal the most damage per swing.";
    }

    internal class GreatHammer : WeaponType
    {
        public override string Name => "Great Hammer";
        public override string Description => "Great Hammers are one of the largest weapon types in the game. They have a slower movesets but feature high damage and are an intimidating choice for players. They also have the highest poise damage of any weapon class in the game, with 45 poise damage on a regular two handed light attack. Great Hammers also cannot be parried two-handed, with the exception of the rolling and running attack.";
    }

    internal class FistAndClaw : WeaponType
    {
        public override string Name => "Fist & Claw";
        public override string Description => "Fist & Claws are a type of Weapon in Dark Souls 3. These Weapons usually have similar movesets albeit with different skills and properties. Fists and Claws are often used as parrying tools, due to their fast parry frames. Fists: Fist weapons have a faster light attack than Claws and a different rolling R1, but have shorter range and lack the innate Bleed Auxiliary effect that Claws have.Fist weapons are mostly used for Quality / Strength builds and due to their higher damage and considerably better Weapon Arts, they are usually favored over Claws. Claws: Claws have a slightly slower light attack than Fist weapons but have considerably different movesets when two handed(the Crow Talons especially).Claws have greater range than the Fists and have innate Bleed.Claws are usually used on Dexterity / Luck builds.";
    }

    internal class SpearAndSpike : WeaponType
    {
        public override string Name => "Spear & Spike";
        public override string Description => "Spears & Pikes have long reach and are excellent for dealing damage while remaining defensive. Spears & Pikes function well when paired with a shield, particularly greatshields, as they have relatively moderate stamina consumption and can be quickly thrusted without lowering your guard. These weapons require patience and careful spacing to make proper use of, but are capable of punishing counterattacks. Their most common Skill is Charge.";
    }

    internal class Halberd : WeaponType
    {
        public override string Name => "Halberd";
        public override string Description => "Halberds are a type of Weapon in Dark Souls 3. These Weapons usually do moderate damage and have long reach. Halberds are generally either a fusion between a spear and another weapon, thus combining straight thrusting attacks and wide swinging strikes, or are simply a cutting or chopping weapon on a long shaft, which is swung across and overhead at a distance. These weapons often have trouble performing in close range or tight quarters. Just like Reapers, they have a 'sweet spot' mechanic that awards players extra damage. Even though the sour spots return as well, the damage difference between the sweet spot hit and the sour spot hit isn't as harsh.";
    }

    internal class Reaper : WeaponType
    {
        public override string Name => "Reaper";
        public override string Description => "Reapers have long reach and a unique sweeping moveset, and most are Bleed weapons. These weapons are particularly useful for sneaking damage behind shields, when swung with proper spacing. Reapers have a 'sweet spot' in which they will do bonus damage when swung at the precise range that their blade reaches the target, and will perform less powerfully when struck with the shaft of the weapon if you are too close to the target. Reapers will also deal chip damage through shields if the 'sweet spot' lands, even if the shield has a 100 % physical block.";
    }

    internal class Whip : WeaponType
    {
        public override string Name => "Whip";
        public override string Description => "Whips are a type of Weapon in Dark Souls 3. These Weapons usually do little to moderate damage, and perform poorly against well-armored foes, but have long reach and can have Auxiliary effects such as Bleeding or Poison. Unlike other melee weapons, whips cannot be parried but cannot backstab or riposte.";
    }

    internal class Bow : WeaponType
    {
        public override string Name => "Bow";
        public override string Description => "Bows have changed a bit in Dark Souls 3. Different Bow types have different attack speeds, ranges and damage. They require arrows and usually a decent amount of Dexterity. It will be possible to use a Short Bow in melee range. Bows can not be infused.";
    }

    internal class Greatbow : WeaponType
    {
        public override string Name => "Greatbow";
        public override string Description => "Greatbows are extremely powerful version of Bows that can knock enemies off their feet in a single shot, in exchange for how demanding they are to use. Operating these weapons demand the operator stop moving entirely, and drawing a greatbow is a time consuming process that leaves the user vulnerable.";
    }

    internal class Crossbow : WeaponType
    {
        public override string Name => "Crossbow";
        public override string Description => "Crossbows are a type of Weapon in Dark Souls 3. These Weapons usually do moderate damage and have less range than Bows. They are generally more close ranged weapons, allowing players to 'shoot from the hip' and reload on the move without entering a two-handed stance. These weapons do not scale with stats, and as a result are less useful on consecutive NG+ runs. Crossbows use Bolts.";
    }

    internal class Stave : WeaponType
    {
        public override string Name => "Stave";
        public override string Description => "Staves are wielded in order to cast Sorceries. Casting Sorceries consumes Focus Points. Their Skill buffs the power of cast spells for a short duration.";
    }

    internal class Flame : WeaponType
    {
        public override string Name => "Flame";
        public override string Description => "Flames are a type of Weapon in Dark Souls 3. These Weapons allow the player to cast Pyromancies. The base game has only one Flame, with the Ashes of Ariandel DLC adding a second one and The Ringed City DLC adding a Curved Sword that doubles as a Flame.";
    }

    internal class Talisman : WeaponType
    {
        public override string Name => "Talisman";
        public override string Description => "Talismans are wielded in order to cast Miracles. These items were not present in Dark Souls 2, but make a return here.  The most commonly found Skill among them, Unfaltering Prayer, differentiates them from Chimes and turns them towards PvP use. Not meeting the Faith requirement for the Talisman will drop the spell buff to a flat 60.";
    }

    internal class SacredChime : WeaponType
    {
        public override string Name => "Sacred Chime";
        public override string Description => "Sacred Chimes are a type of Weapon that replaced Talismans in Dark Souls 2, but now both have returned in Dark Souls 3. These Weapons are used to cast Miracles and sometimes Sorceries. The most common Skill they have is Gentle Prayer, differentiating them for the Talismans.";
    }
}
