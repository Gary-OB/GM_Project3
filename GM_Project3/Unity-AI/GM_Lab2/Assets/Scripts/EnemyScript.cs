using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    int health = 2;
    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GameObject.FindObjectOfType<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet")
        {
            anim.SetBool("isStunned", true);
            health -= 1;

            if (health == 0)
            {

                Destroy(this.gameObject);
            }
        }
    }
}
