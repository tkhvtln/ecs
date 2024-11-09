using Leopotam.Ecs;
using UnityEngine;

public class EnemyMoveSystem : IEcsRunSystem
{
    private EcsFilter<CharacterComponent, EnemyTag> _enemyFilter;
    private EcsFilter<CharacterComponent, PlayerTag> _playerFilter;

    public void Run()
    {
        ref var playerCharacter = ref _playerFilter.Get1(0);

        foreach (var i in _enemyFilter)
        {
            ref var enemyCharacter = ref _enemyFilter.Get1(i);
            
            Vector3 direction = (playerCharacter.transform.position - enemyCharacter.transform.position).normalized;
            enemyCharacter.rigidbody.velocity += direction * enemyCharacter.speed * Time.fixedDeltaTime;
        }
    }
}
