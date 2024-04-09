using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{
    public Heart plheart;
    public Image totalheart;
    public Image curheart;
    private void Start()
    {
        plheart = FindObjectOfType<Heart>();
        totalheart.fillAmount = plheart.CurHeart / 6;
    }
    private void Update()
    {
        curheart.fillAmount = plheart.CurHeart / 6;
    }
}
