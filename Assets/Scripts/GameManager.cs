using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int entityCount = 1;
    [SerializeField]
    GameObject entityPrefab;

    private void Start()
    {
        GetComponent<SpawnArea>().Spawn(entityCount, entityPrefab);
    }
}
