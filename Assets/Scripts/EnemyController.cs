using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Transform target;
    public NavMeshAgent agent;
    public GameObject controllerObject;
    private GameController controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = controllerObject.GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.destination = target.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == controller.player.name)
        {
            controller.GameOver();
        }
    }
}
