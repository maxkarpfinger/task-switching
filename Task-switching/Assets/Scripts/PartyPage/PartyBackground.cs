using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int lockLevel = GameManager.get().getLevel();
        SpriteRenderer spriteR = GameObject.Find("background").GetComponent<SpriteRenderer>();

        for (int i = 0; i < 15; i++)
        {
            GameObject.Find("sticker"+(i+1)).GetComponent<SpriteRenderer>().color = UnityEngine.Color.black;
        }
        GameObject.Find("hat1_sticker").GetComponent<SpriteRenderer>().enabled = false; 
        GameObject.Find("hat2_sticker").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("hat3_sticker").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("hat4_sticker").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("hat5_sticker").GetComponent<SpriteRenderer>().enabled = false;


        for (int i=1; i <= lockLevel; i++)
        {
            if (i <= 15)
            {
                GameObject.Find("sticker" + (i)).GetComponent<SpriteRenderer>().color = UnityEngine.Color.white;
            }
            if (i == 18)
            {
                GameObject.Find("hat1_sticker").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("hat2_sticker").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("hat3_sticker").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("hat4_sticker").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("hat5_sticker").GetComponent<SpriteRenderer>().enabled = true;
            }
            if (i == 17)
            {
                GameObject.Find("hat1_sticker").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("hat2_sticker").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("hat3_sticker").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("hat4_sticker").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("hat5_sticker").GetComponent<SpriteRenderer>().enabled = false;
            }
            if (i == 16)
            {
                GameObject.Find("hat1_sticker").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("hat2_sticker").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("hat3_sticker").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("hat4_sticker").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("hat5_sticker").GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
