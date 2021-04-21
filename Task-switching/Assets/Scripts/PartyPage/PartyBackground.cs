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
        if (lockLevel == 17)
        {
            spriteR.sprite = Resources.Load<Sprite>("party_full");
        }else if(lockLevel > 11)
        {
            spriteR.sprite = Resources.Load<Sprite>("party_food");
        }else if(lockLevel > 5)
        {
            spriteR.sprite = Resources.Load<Sprite>("party_friends");
        }
        else
        {
            spriteR.sprite = Resources.Load<Sprite>("party_none");
        }
    }
}
