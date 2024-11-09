using Leopotam.Ecs;
using UnityEngine;

public class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<CharacterComponent, InputComponent, PlayerTag> _playerFilters;

    public void Run()
    {
        foreach (var i in _playerFilters)
        {
            ref var character = ref _playerFilters.Get1(i);
            ref var input = ref _playerFilters.Get2(i);
                        
            character.rigidbody.velocity += input.direction * character.speed * Time.fixedDeltaTime;
        }
    }
}
