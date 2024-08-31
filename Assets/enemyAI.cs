using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{

    [SerializeField] NavMeshAgent creature;
    [SerializeField] Transform player;
    [SerializeField] GameObject tree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        creature.SetDestination(player.position);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "destructable")
        {
            Destroy(tree);
        }
    }
}
