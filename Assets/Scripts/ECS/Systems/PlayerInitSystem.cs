using Leopotam.Ecs;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld _world;
    private GlobalConfig _globalConfig;

    public void Init()
    {
        EcsEntity playerEntity = _world.NewEntity();

        ref var character = ref playerEntity.Get<CharacterComponent>();
        playerEntity.Get<InputComponent>();
        playerEntity.Get<PlayerTag>();

        GameObject playerObject = Object.Instantiate(_globalConfig.playerConfig.prefab);

        character.rigidbody = playerObject.GetComponent<Rigidbody>();
        character.transform = playerObject.transform;
        character.speed = _globalConfig.playerConfig.speed;
    }
}
