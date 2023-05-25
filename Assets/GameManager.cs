using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject chonkPrefab;
    float chonkCount = 3;
    public GameObject chonkDaddy;
    public float chonkMoveSpeed = 10f;

    List<Chonk> chonkList = new List<Chonk>();
    Vector3 currentChonkSpawnPoint = new Vector3(-50, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        CreateFirstChonks();
    }

    // Update is called once per frame
    void Update()
    {
        moveTheDaddy();
    }

    void moveTheDaddy()
    {
        chonkDaddy.transform.position += Vector3.left * Time.deltaTime * chonkMoveSpeed;

        // if chonkdaddy has moved 50 units since last creation
        if (chonkDaddy.transform.position.x + currentChonkSpawnPoint.x - 50 < 0)
        {
            Chonk chonk = Instantiate(chonkPrefab, chonkDaddy.transform.position + currentChonkSpawnPoint, Quaternion.identity, chonkDaddy.transform).GetComponent<Chonk>();
            chonk.FillSpawnPoints();
            chonkList.Add(chonk);

            Destroy(chonkList[0].gameObject);
            chonkList.RemoveAt(0);

			currentChonkSpawnPoint += new Vector3(50, 0, 0);
		}
    }

    void CreateFirstChonks()
    {
		Chonk chonk;

		for (int i = 0; i < chonkCount; i++)
        {
            chonk = Instantiate(chonkPrefab, chonkDaddy.transform.position + currentChonkSpawnPoint, Quaternion.identity, chonkDaddy.transform).GetComponent<Chonk>();
            chonkList.Add(chonk);

            currentChonkSpawnPoint += new Vector3(50, 0, 0);

            // Fill the last one
            if (i == chonkCount - 1)
                chonk.FillSpawnPoints();
        }
    }

}
