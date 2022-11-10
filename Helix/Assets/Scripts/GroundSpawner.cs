using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject GroundGroup;
    public GameObject Group;
    public GameObject[] groundTile;
    public Vector3 nextSpawnerPoint;
    public int value;

    public List<int> LgroundTiles;

    // Start is called before the first frame update
    void Start()
    {
        LgroundTiles.Add(1);
        for (int i = 0; i != (GameManager.instance.mapLength + (int)(GameManager.instance.level / 2) - 1); i++)
        {
            LgroundTiles.Add(Random.Range(2, groundTile.Length));
        }
        LgroundTiles.Add(0);
        for (int i = 0; i != LgroundTiles.Count; i++)
        {
            SpawnTile(groundTile[LgroundTiles[i]]);
        }
    }

    void Update()
    {
    }

    // Generate GroundTile
    public void SpawnTile(GameObject obj)
    {
        GameObject tmp = Instantiate(obj, nextSpawnerPoint, Quaternion.identity);
        tmp.transform.SetParent(GroundGroup.transform);
        nextSpawnerPoint = tmp.transform.GetChild(1).transform.position;
    }

    // Generate GroundTile with Units
    public void SpawnTileUnits(GameObject obj)
    {
        GameObject tmp = Instantiate(obj, nextSpawnerPoint, Quaternion.identity);
        tmp.GetComponent<Add_Variables>().ParentSpawnUnit = Group;
        tmp.transform.SetParent(GroundGroup.transform);
        nextSpawnerPoint = tmp.transform.GetChild(1).transform.position;
    }
}
