public class EnemyState<T> : State
{
    protected T enemy;
    protected EnemyState(T enemy) => this.enemy = enemy;
}