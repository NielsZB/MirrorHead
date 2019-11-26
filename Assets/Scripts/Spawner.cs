using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab = null;

    public void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
    public void Spawn(GameObject spawnObject)
    {
        Instantiate(spawnObject, transform.position, Quaternion.identity);
    }


}
