using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chonk : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public GameObject lowPrefab;
    public GameObject highPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillSpawnPoints()
    {
        foreach (var point in spawnPoints)
        {
            GameObject _obstacle;

            if (Random.Range(0, 2) == 0)
                _obstacle = lowPrefab;
            else 
                _obstacle = highPrefab;


            Instantiate(_obstacle, point.transform.position + _obstacle.transform.position, _obstacle.transform.rotation, transform);
        }
    }
}
