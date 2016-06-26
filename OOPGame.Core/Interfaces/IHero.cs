namespace OOPGame.Core.Interfaces
{
    using OOPGame.Core.Models;

    public interface IHero : ICreature
    {
        int Experience { get; set; }

        int PotionsCount { get; set; }

        Shield Shield { get; set; }

        int BasicArmor { get; set; }

        Sword Sword { get; set; }

        int BasicDamage { get; set; }

        void UsePotion();

        void LevelUp();
    }
}
