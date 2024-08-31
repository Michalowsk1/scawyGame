using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paper : MonoBehaviour
{
    [SerializeField]GameObject paperNote;
    [SerializeField] GameObject pickupText;
    [SerializeField] GameObject message;
    // Start is called before the first frame update
    void Start()
    {
        //paperNote = GetComponent<GameObject>();
        paperNote.SetActive(true);
        pickupText.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
