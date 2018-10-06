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

            Vector3 spawnPosition = new Vector3(rndX, 2, rndZ);
            Quaternion spawnRotation = new Quaternion();
            spawnRotation.Set((float)0.95, 0, 0, 1);

            GameObject myEnemy = Instantiate(enemy, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(frequence);
        }
    }
}