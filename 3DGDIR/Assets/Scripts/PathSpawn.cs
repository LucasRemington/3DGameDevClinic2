using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawn : MonoBehaviour {

    public GameObject[] Paths;

    private Transform playerT;
    private float spawnZ = -5.0f;
    public float pathLength ; //Change to the length of path prefabs, all lengts on z have to be the same.
    private float safe = 35.0f;
    private int pathsAlive = 5;
    private List<GameObject> activePaths;

	void Start () {
        activePaths = new List<GameObject>();
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < pathsAlive; i++)
        {
            SpawnPath();
        }
	}
	

	void Update () {
		if(playerT.position.z - safe > (spawnZ - pathsAlive * pathLength))
        {
            SpawnPath();
            DeletePath();
        }
	}

    void SpawnPath()
    {
        int randomIndex = Random.Range(0, Paths.Length);
        GameObject go;
        go = Instantiate (Paths[randomIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += pathLength;
        activePaths.Add(go);
    }
    void DeletePath()
    {
        Destroy(activePaths[0]);
        activePaths.RemoveAt(0);
    }
}
