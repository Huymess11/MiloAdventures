using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gamemanager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startTransiton;
    public GameObject endTransition;
    public GameObject MenuPanel;
    public GameObject ShopPanel;
    public Text coinTxt;
    private void Start()
    {
        startTransiton.SetActive(true);
        coinTxt.text = "Coin: " + PlayerPrefs.GetInt("totalCoin", 0);

    }
    private void Update()
    {
        coinTxt.text = "Coin: " + PlayerPrefs.GetInt("totalCoin", 0);
    }

    public virtual void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public virtual void nextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public virtual void Menu()
    {
        Time.timeScale = 1f;
        StartCoroutine(Transition(1));
    }
    public virtual void Level1()
    {
        StartCoroutine(Transition(2));
    }
    public virtual void Level2()
    {

        StartCoroutine(Transition(3));
    }
    public virtual void Level3()
    {

        StartCoroutine(Transition(4));
    }
    public virtual void Home()
    {

        Time.timeScale = 1f;
        StartCoroutine(Transition(0));
    }
    public virtual void ReplayEveryThing()
    {
        StartCoroutine(ResetTransition());
    }
    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
        ShopPanel.SetActive(false);
    }
    public void ShowShopPanel()
    {
        ShopPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }
    IEnumerator Transition( int numScene)
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(numScene);
    }
    IEnumerator ResetTransition()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(0);
        PlayerPrefs.DeleteAll();
    }
}
