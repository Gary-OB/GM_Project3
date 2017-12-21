using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{

    int speed = 6;
    Animator anim;
    Rigidbody charRigibody;
    bool jumping = false;

    public int score = 0;

    public GameObject bulletPrefab;

    // Use this for initialization
    void Start () {
        anim = GameObject.FindObjectOfType<Animator>();
        charRigibody = GameObject.FindObjectOfType<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            anim.SetBool("isRunning", true);

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((Vector3.back/2) * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            jumping = true;
            anim.SetBool("isJumping", jumping);
            charRigibody.AddForce(new Vector3(0.0f, 800.0f, 0.0f));
        }

        anim.SetBool("isJumping", jumping);

        //set bool to false
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CmdFire();
            anim.SetTrigger("attack");        
        }
    }

    void OnCollisionEnter(Collision col)
    {     
        if (col.gameObject.tag == "Ground")
        {
            print(col.gameObject.tag + ", " + jumping);
            jumping = false;
        }

        if (col.gameObject.tag == "lava")
        {
            Destroy(this.gameObject);
        }
    }

    [Command]
    void CmdFire()
    {

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, this.transform.position + transform.forward * 1 + transform.up * 2, this.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20.0f;
        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2);
        
    }

    void FootR() { }
    void FootL() { }
    void Jump() { }

    //do some collision detection down here
}
