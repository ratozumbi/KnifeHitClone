using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewKnife();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewKnife()
    {
        var go = Instantiate(
            Resources.Load<GameObject>("Prefabs/knife"),
            transform.parent);
        go.transform.localPosition = new Vector3(0, -4.5f, 0);

        var btn = GameObject.Find("Fire").GetComponent<Button>();
        btn.onClick.AddListener(go.GetComponent<Knife>().StartMoving);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void GameOver()
    {
        var txt = GameObject.Find("txt_gameOver").GetComponent<Text>();
        txt.enabled = true;

        var btn = GameObject.Find("Fire").GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        
        btn.onClick.AddListener(RestartGame);
    }
}
