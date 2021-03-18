using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class SpawnSingleCUbe : MonoBehaviour
{
    //For spawn Grid and random delete
    public GameObject gridSpace;
    [ShowInInspector]public GameObject[,] boardArray = new GameObject[5, 20];
    public int gridX;
    public int gridZ;
    public float spawnSpacingOffest;
    public float randomValue;
    public GameObject parent;

    //Parameters for Instantiate with Ray
    public GameObject prefab;
    public Vector3 position;
    public RaycastHit hit;
    public float raycasthit = 100f;
    public float hitY = 0.4f;
    

    private void Start()
    {
        Spawn();
        DeleteObjects();
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, raycasthit) && Input.GetMouseButton(0) && hit.collider.tag == "Ground1")
        {
            Debug.Log(hit.collider.name);
            position.Set(Mathf.Round(hit.point.x), hit.point.y + hitY, Mathf.Round(hit.point.z));
            prefab.transform.position = position;
            Instantiate(prefab, position, Quaternion.identity);
        }
    }

    public void Spawn()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPosition = new Vector3(x * spawnSpacingOffest, 0, z * spawnSpacingOffest) + parent.transform.position;
                boardArray[x,z] = Instantiate(gridSpace, spawnPosition, Quaternion.identity);
            }
        }
    }

    //random delete from grid
    public void DeleteObjects()
    {
        for (int z = 0; z < gridZ; z++)
        {
            Destroy(boardArray[Random.Range(0, 5), z]);
            for(int i = 0;i < 3; i++)
            {
                if (Random.value > randomValue)
                {
                    Destroy(boardArray[Random.Range(0, 5), z]);
                }
            }
        }
        
    }


}