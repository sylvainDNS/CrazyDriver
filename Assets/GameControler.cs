using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public GameObject enemy;
    public float frequence;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(spawn());
    }


    IEnumerator spawn()
    {
        while (true)
        {
            float rndX = Random.Range(-200, 200);
            float rndZ = Random.Range(-200, 200);

            Vector3 spawnPosition = new Vector3(rndX, 0, rndZ);

            GameObject myEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(frequence);
        }
    }
}