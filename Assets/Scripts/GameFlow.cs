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
        PlayerPrefs.DeleteAll();
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
        int lose = PlayerPrefs.GetInt("lose", 0); 
        PlayerPrefs.SetInt("lose", lose +1 );
        
        var txt = GameObject.Find("txt_gameOver").GetComponent<Text>();
        txt.enabled = true;

        Restart();
    }

    public void Victory()
    {
        PlayWin();
        int wins = PlayerPrefs.GetInt("win", 0); 
        PlayerPrefs.SetInt("win", wins +1 );
        
        var txt = GameObject.Find("txt_gameOver").GetComponent<Text>();
        txt.text = "YOU WIN!";
        txt.enabled = true;

        Restart();
        
    }

    private void Restart()
    {
        var btn = GameObject.Find("Fire").GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        
        btn.onClick.AddListener(RestartGame);
    }

    public void PlayHit()
    {
        var audioSource = GetComponent<AudioSource>();
        if (audioSource.isPlaying) return;
        var clip = Resources.Load<AudioClip>("Sounds/hit");
        audioSource.clip = clip;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }
    public void PlayMiss()
    {
        var audioSource = GetComponent<AudioSource>();
        var clip = Resources.Load<AudioClip>("Sounds/miss");
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayFire()
    {
        var audioSource = GetComponent<AudioSource>();
        var clip = Resources.Load<AudioClip>("Sounds/fire");
        audioSource.clip = clip;
        audioSource.Play();
    }
    
    public void PlayWin()
    {
        var audioSource = GetComponent<AudioSource>();
        var clip = Resources.Load<AudioClip>("Sounds/win");
        audioSource.clip = clip;
        audioSource.Play(1);
    }
}
