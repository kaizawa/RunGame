using System.Collections;
using System.Collections.Generic;
using UnityChan;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// referenced https://xr-hub.com/archives/13135

public class GameController : MonoBehaviour
{
    private bool isGameOver = false;

    public GameObject player;
    public GameObject enemy;
    public GameObject text;
    public Text timeText;
    public float limit = 30.0f;    

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "残り時間: " + limit + "秒";
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && Input.GetMouseButton(0))
        {
            Restart();
        }

        if (limit < 0)
        {
            GameOver();
            return;
        }

        if(player.transform.position.y < -1)
        {
            GameOver();
            return;
        }

        limit -= Time.deltaTime;
        timeText.text = "残り時間: " + limit.ToString("f1") + "秒";
    }

    public void Goal()
    {
        StopObjects();
        SetText("Goal!!!!\n 画面クリックで再スタート");
        isGameOver = true;
    }

    private void SetText(string message)
    {
        text.GetComponent<Text>().text = message;
        text.SetActive(true);
    }

    public void GameOver()
    {
        StopObjects();
        SetText("Game Over...");
        isGameOver = true;
    }

    public void Restart()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
        Debug.Log("Reset is called");
    }

    private void StopObjects()
    {
        enemy.GetComponent<EnemyController>().agent.enabled = false;
        player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        timeText.enabled = false;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
