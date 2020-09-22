using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public GameObject controllerObject;
    private GameController controller;

    private bool isGoal = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = controllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    [Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == controller.player.name)
        {
            controller.Goal();
        }
    }
}
