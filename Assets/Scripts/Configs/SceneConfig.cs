using UnityEngine;

[CreateAssetMenu(fileName = "SceneConfig", menuName = "Configs/SceneConfig")]
public class SceneConfig : ScriptableObject
{
    public int countEnemies;
    public int radiusSpawnEnemy;
    public CharacterConfig enemyConfig;
}
