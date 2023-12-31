using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    public int curHP;

    public int maxHP;

    public int moneyToGive;

    public Image healthBarFill;

    public void Damage()
    {
        curHP --;
        healthBarFill.fillAmount = (float)curHP / (float)maxHP;

        if(curHP <= 0)
        {
            Caught();
        }
    }

    public void Caught()
        {
            GameManager.instance.AddMoney(moneyToGive);
            AnimalManager.instance.ReplaceAnimal(gameObject);
        }
}

    
