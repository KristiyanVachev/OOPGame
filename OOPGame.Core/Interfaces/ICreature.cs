namespace OOPGame.Core.Interfaces
{
    public interface ICreature
    {
        //properties
        string Name { get; set; }

        int MaxHP { get; set; }

        int HP { get; set; }

        int Damage { get; set; }

        int Armor { get; set; }

        int Level { get; set; }

        int[] AttackChance { get; }

        double[] AttackPower { get; }

        string[] AttackNames { get; set; }

        string WeakAttackName { get; set; }

        string StrongAttackName { get; set; }

        string UltimateAttackName { get; set; }

        //methods
        int Attack(int chance, double multiplier);

        int WeakAttack();

        int StrongAttack();

        int UltimateAttack();

        string FinalWords();
    }
}
