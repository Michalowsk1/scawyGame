using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpscare : MonoBehaviour
{
    public AudioSource scream;
    [SerializeField] GameObject scaryImage;
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        scream.Play();
        scaryImage.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + 1;
        if (timer >= 300)
        {  
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}

