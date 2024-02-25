using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraduateScript : MonoBehaviour
{
    public GameObject hukidasi;
    // Start is called before the first frame update
    void Start()
    {
        hukidasi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("message");
            hukidasi.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hukidasi.SetActive(false);
        }
    }
}
