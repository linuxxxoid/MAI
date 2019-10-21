using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public string ItemName;
    //GameObject
    public string Description;
    public int Money;
    public int Bullets;
    public Texture2D ItemTexture;

    void Start()
    {
        Money = Random.Range(2, 10);
        Bullets = Random.Range(1, 5);   
    }

}
