using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityChan;
using UnityEngine.UI;

public class WallControll : MonoBehaviour
{
    public GameObject controllerObject = null;
    public float speed = 0.05f;
    public float max_x = 10.0f;

    private bool isDeadWall = false;   
    private GameController controller = null;

    // Start is called before the first frame update
    void Start()
    {

        if (this.name == "DeadWall")
        {
            controller = controllerObject.GetComponent<GameController>();
            isDeadWall = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(speed, 0, 0);
        if(this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < (-max_x))
        {
            speed *= -1;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isDeadWall && other.gameObject.name == controller.player.name)
        {
            controller.GameOver();
            Debug.Log("Touched to DeadWall");
        }
    }
}
