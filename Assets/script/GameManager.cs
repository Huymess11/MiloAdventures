using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    private UI ui;
    private player pl;
    private int totalCoin;
    public GameObject startTransiton;
    public GameObject endTransition;
    public GameObject[] character;
    private int characterIndex;
    public Transform startPonint;
    public CinemachineVirtualCamera followcam;
    // Update is called once per frame
    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("selectorPlayer", 0);
        GameObject hello = Instantiate(character[characterIndex], startPonint.position, Quaternion.identity);
        followcam.m_Follow = hello.transform;
        ui = FindObjectOfType<UI>();
        startTransiton.SetActive(true);
        
    }
    private void Start()
    {
        pl = FindObjectOfType<player>();
    }
    void Update()
    {
        ui.Score(" " + pl.CurScore());
        
    }
    public void StartPlayer()
    {
        pl.CanMove();
    }
    public void StopPlayer()
    {
        pl.CanNotMove();
    }
   public virtual void Replay()
    {
        StartCoroutine(ReplayGame());
    }
    public virtual void nextLevel()
    {
        Time.timeScale = 1f;
        StartCoroutine(Transition());
    }
    public virtual void Menu()
    {
        Time.timeScale = 1f;
        StartCoroutine(goMenuEarly());
    }
    public virtual void Level1()
    {
        SceneManager.LoadScene(2);
    }
    public virtual void Level2()
    {
        SceneManager.LoadScene(3);
    }
    public virtual void Level3()
    {
        SceneManager.LoadScene(4);
    }
    public virtual void Home()
    {
        Time.timeScale = 1f;
        StartCoroutine(goHomeEarly());
    }
    IEnumerator Transition()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    IEnumerator goMenuEarly()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(1);
    }
    IEnumerator goHomeEarly()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(0);
    }
    IEnumerator ReplayGame()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
