using Leopotam.Ecs;
using UnityEngine;

public class EcsStartup : MonoBehaviour
{
    public GlobalConfig globalConfig;
    public SceneConfig sceneConfig;

    private EcsWorld _world;
    private EcsSystems _updateSystems;
    private EcsSystems _fiexdUpdateSystems;

    private void Start()
    {
        _world = new EcsWorld();
        _updateSystems = new EcsSystems(_world);
        _fiexdUpdateSystems = new EcsSystems(_world);

        _updateSystems
            .Add(new PlayerInitSystem())
            .Add(new PlayerInputSystem())
            .Add(new EnemyInitSystem())           
            .Inject(globalConfig)
            .Inject(sceneConfig)
            .Init();

        _fiexdUpdateSystems
            .Add(new PlayerMoveSystem())
            .Add(new EnemyMoveSystem())
            .Init();
    }

    private void Update()
    {
        _updateSystems?.Run();
    }

    private void FixedUpdate()
    {
        _fiexdUpdateSystems?.Run();
    }

    private void OnDestroy()
    {
        _updateSystems?.Destroy();
        _updateSystems = null;

        _fiexdUpdateSystems?.Destroy();
        _fiexdUpdateSystems = null;

        _world?.Destroy();
        _world = null;
    }
}
