namespace Acme.GenericBusiness.MonsterSpawner
{
    public interface IMonsterSpawner
    {
        Monster CreateMonster(int level);
    }
}