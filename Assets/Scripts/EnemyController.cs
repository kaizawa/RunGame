using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject controllerObject;

    private GameController controller;
    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        controller = controllerObject.GetComponent<GameController>();
        target = controller.getPlayer().transform;
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
