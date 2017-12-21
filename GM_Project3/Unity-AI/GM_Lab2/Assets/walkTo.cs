using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class walkTo : MonoBehaviour {

    public Transform goal;
    public GameObject player;

    NavMeshAgent agent;   
    Camera overviewCamera;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.ResetPath();
    }
	
	// Update is called once per frame
	void Update () {
            
        

        agent.destination = goal.position;


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "endpoint")
        {
            Destroy(player);
        }
    }

    void FootR() { }
    void FootL() { }
}
