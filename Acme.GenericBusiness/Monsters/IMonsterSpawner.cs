namespace Monsters
{
    public interface IMonsterSpawner
    {
        Monster CreateMonster(int level);
    }
}