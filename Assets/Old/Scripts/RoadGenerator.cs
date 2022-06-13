using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject roadPartPrefab;
    public Transform firstRoadPart;
    public Transform roadParent;
    public int numOfRoadParts;

    private void Start()
    {
        GenerateRoad();
    }

    void GenerateRoad()
    {
        for (int i = 0; i < numOfRoadParts; i++)
        {
            Instantiate(roadPartPrefab, firstRoadPart.position + new Vector3(10 * (i + 1), 0, 0), Quaternion.identity, roadParent);
        }
    }
}
