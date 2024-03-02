using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player2 : MonoBehaviour
{

    private Rigidbody rb;
    private float moveSpeed = 10;
    private float jumpPower = 800;
    private bool grounded;
    public GameObject bullet;
    private Vector3 force;
    public float bulletSpeed = 5000;


    private int HP;
    public TextMeshProUGUI P2;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();

         HP = 50;
        
    }

    // Update is called once per frame
    void Update()
    {
        P2.text = "HP:" + HP.ToString();
        
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(new Vector3(0, -2, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.position += transform.TransformDirection(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(new Vector3(0, 2, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded == true)
            {
                rb.AddForce(Vector3.up * jumpPower);
            }
        }

        if (Input.GetKey(KeyCode.O))
        {
            GameObject bullets = Instantiate(bullet) as GameObject;
            bullets.transform.position = this.transform.position;
            force = this.gameObject.transform.forward * bulletSpeed;
            bullets.GetComponent<Rigidbody>().AddForce(force);
            Destroy(bullets.gameObject, 4);
        }
    }
    
     private void OnCollisionEnter(Collision collision)
    {

    
        if (collision.gameObject.tag == "P1Bullet")
        {
            HP -= 1;
        
        }
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
