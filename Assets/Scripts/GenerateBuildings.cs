using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GenerateBuildings : MonoBehaviour
{
    public GameObject buildingPrefab;
    public Transform playerPosition;
    public UnityEngine.Vector2 startingPosition;
    public float generateOffset;
    public UnityEngine.Vector2 buildingOffset;
    public UnityEngine.Vector2 previousBuildingPosition;
    public int maxBuildings = 5;
    private UnityEngine.Vector2 newPosition;
    private Queue<GameObject> buildings = new Queue<GameObject>();
    void Start() {
        newPosition = startingPosition;
        previousBuildingPosition = startingPosition;
        GenerateBuilding();
    }
    void Update()
    {
        if(playerPosition.position.x > (previousBuildingPosition.x - generateOffset)) {
            GenerateBuilding();
        }
    }
    void GenerateBuilding() {
        if(buildings.Count >= maxBuildings) {
            GameObject oldestBuilding = buildings.Dequeue();
            Destroy(oldestBuilding); 
        }
        GameObject building = Instantiate(buildingPrefab, newPosition, UnityEngine.Quaternion.identity, transform);
        buildings.Enqueue(building);
        previousBuildingPosition = newPosition;
        newPosition += buildingOffset;
    }
}
