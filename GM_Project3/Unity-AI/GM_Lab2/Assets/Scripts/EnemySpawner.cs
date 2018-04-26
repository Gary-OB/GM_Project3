using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    
    public GameObject enemy;
    public GameObject goal;

    // Use this for initialization
    void Start () {
        Invoke("spawnEnemy", 3f);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void spawnEnemy()
    {
        GameObject en = (GameObject)Instantiate(enemy, this.transform.position, Quaternion.identity);
        en.GetComponent<walkTo>().goal = goal.transform;
        Invoke("spawnEnemy", Random.Range(2, 5));

    }
}
