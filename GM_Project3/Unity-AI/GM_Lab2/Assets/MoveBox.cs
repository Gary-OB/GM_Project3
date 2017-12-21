using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour {

    bool open = false;

	// Use this for initialization
	void Start () {
        Invoke("moveObstacle", 2f);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void moveObstacle()
    {
        print("Envoking");
        if (open)
            this.transform.Translate(0, -5, 0);
        else
            this.transform.Translate(0, 5, 0);

        open = !open;
        Invoke("moveObstacle", 3f);
    }
}
