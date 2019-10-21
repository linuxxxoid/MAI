using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBar : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;
    public Texture2D texHealth;
    public Texture2D Health;

    private float TimeMinus;
    private float timeMinusHealth;

    void Start()
    {
        maxHealth = 100;
        curHealth = 90;
    }

    void Update()
    {
        if (curHealth > maxHealth) curHealth = maxHealth;

        //if (curHealth <= 0) DEAD TODO

    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, Screen.height - 150, 50, 50), Health);
        GUI.Box(new Rect(75, Screen.height - 127, maxHealth, 20), "");
        GUI.DrawTexture(new Rect(70, Screen.height - 127, curHealth, 20), texHealth);

    }
}
