using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public float StartingHeart;
    public float CurHeart { get; private set; }
    private Animator ani;
    public player pl;
    public UI ui;
    AudioManager audio;
    void Awake()
    {
        audio = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        ani = GetComponent<Animator>();
        ui  = FindObjectOfType<UI>();
        pl = FindObjectOfType<player>();
        CurHeart = StartingHeart;
    }

    public void TakdDame(float Dame)
    {
        CurHeart = Mathf.Clamp(CurHeart - Dame, 0, StartingHeart);
        if (CurHeart <= 0)
        {
            audio.PlaySFX(audio.GameOver);
            ani.SetTrigger("death");
            pl.SetCurState(true);
            ui.ShowGameOver(true);
            pl.stopPlayer();
        }
    }
}
