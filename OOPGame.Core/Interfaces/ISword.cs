namespace OOPGame.Core.Interfaces
{
    public interface ISword : IWeapon
    {
        int Damage { get; set; }

        string AttackName { get; set; }
    }
}
