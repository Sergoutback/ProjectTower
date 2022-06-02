namespace CodeMVC.Enemy
{
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(EnemyType type);
    }
}
