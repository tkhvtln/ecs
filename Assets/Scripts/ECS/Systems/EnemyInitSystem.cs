using Leopotam.Ecs;
using UnityEngine;

public class EnemyInitSystem : IEcsInitSystem
{
    private EcsWorld _world;
    private SceneConfig _sceneConfig;

    public void Init()
    {
        for (int i = 0; i < _sceneConfig.countEnemies; i++)
        {
            EcsEntity enemyEntity = _world.NewEntity();

            ref var character = ref enemyEntity.Get<CharacterComponent>();
            enemyEntity.Get<EnemyTag>();

            GameObject enemyObject = Object.Instantiate(_sceneConfig.enemyConfig.prefab, SetPosition(i, _sceneConfig.countEnemies), Quaternion.identity);

            character.rigidbody = enemyObject.GetComponent<Rigidbody>();
            character.transform = enemyObject.transform;
            character.speed = _sceneConfig.enemyConfig.speed;
        }
    }

    private Vector3 SetPosition(int index, int count) => Quaternion.Euler(0, 360 / count * index, 0) * Vector3.right * _sceneConfig.radiusSpawnEnemy + Vector3.zero;
}
