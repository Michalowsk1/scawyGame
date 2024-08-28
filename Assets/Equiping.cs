using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equiping : MonoBehaviour
{
    GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision Bag)
    {
        if (Bag.gameObject.tag == ("Player"))
        {

         
            Destroy(gameObject);
        }
    }
}
