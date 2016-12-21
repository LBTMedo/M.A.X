using UnityEngine;
using System.Collections;

public class ThrowPleagueBall : MonoBehaviour {

    public GameObject prefab;
    public Transform location;
    float randomTimeSpawn = 0;
    bool cooldown = false;
    public float minTimeSpawn;
    public float maxTimeSpawn;
    public int force;
    bool rainIsActive = false;

    public void SetRainIsActive(bool val)
    {
        rainIsActive = val;
    }

    void Update()
    {
        if(cooldown == false)
        {
            if (rainIsActive == false)
            {
                StartCoroutine(SpawnOnDelay());
            }
        }
    }

    public void ThrowBall()
    {
        Vector3 smer = location.position;
        GameObject objekt = (GameObject)Instantiate(prefab, smer, Quaternion.identity);
        objekt.GetComponent<Rigidbody2D>().AddForce(location.up * force);
    }

    IEnumerator SpawnOnDelay()
    {
        randomTimeSpawn = Random.Range(minTimeSpawn, maxTimeSpawn);
        cooldown = true;
        yield return new WaitForSeconds(randomTimeSpawn);
        ThrowBall();
        cooldown = false;
    }

}
