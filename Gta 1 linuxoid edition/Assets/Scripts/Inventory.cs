using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject ItemGun = new GameObject();
    public int money = 0;
    public int bullets = 0;
    public int gun = 0;
    public int weapon = 0;
    public bool HavingGun = false;
    public Texture2D gunTex;
    public Texture2D moneyTex;
    public Texture2D bulletsTex;


    void Update()
    {
        FPress();
    }

    void FPress()
    {
        //if (Input.GetKeyUp(KeyCode.F) && HavingGun && ItemGun.name == "Hand_Weapon")
        //{
        //    weapon = 1;
        //}
        if (Input.GetKeyDown(KeyCode.F) && HavingGun && ItemGun.name == "pistol")
        {
            weapon = 2;
        }
   
    }

  
    void OnTriggerStay2D(Collider2D gameObj)
    {
    
        if (Input.GetKeyDown (KeyCode.E))
        {
            if (gameObj.tag == "Money")
            {
                money += gameObj.GetComponent<Items>().Money;
                Destroy(gameObj.gameObject);
            }
            if (gameObj.tag == "Bullets")
            {
                bullets += gameObj.GetComponent<Items>().Bullets;
                Destroy(gameObj.gameObject);
            }
            if (gameObj.tag == "Gun")
            {
                HavingGun = true;
                ++gun;
                ItemGun = (GameObject)Resources.Load(gameObj.name);
                //ItemGun = gameObj.GetComponent<Items>().ItemName;
                Destroy(gameObj.gameObject);
            }
        }

        if (weapon == 1)
        {
            GameObject gamer = GameObject.FindWithTag("Player");

            gamer.transform.GetChild(0).GetComponent<CircleCollider2D>().enabled = false;
            gamer.transform.GetChild(1).GetComponent<CircleCollider2D>().enabled = true;
            gamer.transform.GetChild(2).GetComponent<CircleCollider2D>().enabled = false;

            if (gameObj.tag == "Citizen")
            {
                gameObj.GetComponent<CitizenHealth>().curHealth -= 25;
                weapon = 0;
            }
            //if (gamrObj.tag == "Enemy") TODO
        }
        if (weapon == 2)
        {
            GameObject gamer = GameObject.FindWithTag("Player");

            gamer.transform.GetChild(0).GetComponent<CircleCollider2D>().enabled = false;
            gamer.transform.GetChild(1).GetComponent<CircleCollider2D>().enabled = false;
            gamer.transform.GetChild(2).GetComponent<CircleCollider2D>().enabled = true;

            if (gameObj.tag == "Citizen")
            {
                if (bullets > 0)
                {
                    gameObj.GetComponent<CitizenHealth>().curHealth -= 50;
                    bullets -= 1;
                    weapon = 0;
                }
            }
            //if (gamrObj.tag == "Enemy") TODO
        }
        if (weapon == 0)
        {
            GameObject gamer = GameObject.FindWithTag("Player");

            gamer.transform.GetChild(0).GetComponent<CircleCollider2D>().enabled = true;
            gamer.transform.GetChild(1).GetComponent<CircleCollider2D>().enabled = false;
            gamer.transform.GetChild(2).GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    void OnGUI()
    {
     
        GUI.DrawTexture(new Rect(Screen.width - 100, 10, 30, 30), moneyTex);
        GUI.Label(new Rect(Screen.width - 60, 10, 100, 50), " " + money);
        GUI.DrawTexture(new Rect(Screen.width - 100, 50, 30, 30), bulletsTex);
        GUI.Label(new Rect(Screen.width - 60, 50, 100, 50), " " + bullets);
        GUI.DrawTexture(new Rect(Screen.width - 100, 90, 30, 30), gunTex);
        GUI.Label(new Rect(Screen.width - 60, 90, 100, 50), " " + gun);

    }
}
