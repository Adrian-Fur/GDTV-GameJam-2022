using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    [SerializeField]
    Transform levelStart;
    [SerializeField]
    List<Transform> levelPartsList;
    [SerializeField]
    PlayerControl player;
    Vector3 lastEndPosition;

    void Awake()
    {
        lastEndPosition = levelStart.Find("EndPosition").position;
        
        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    void Update() 
    {
        if (Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }       
    }

    void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartsList[Random.Range(0, levelPartsList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
