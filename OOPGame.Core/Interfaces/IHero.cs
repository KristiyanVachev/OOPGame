namespace OOPGame.Core.Interfaces
{
    public interface IHero : ICreature
    {
        int Experience { get; set; }

        int PotionsCount { get; set; }

        int ShieldArmor { get; set; }

        int BasicArmor { get; set; }

        int SwordDamage { get; set; }

        int BasicDamage { get; set; }

        void UsePotion();
    }
}
