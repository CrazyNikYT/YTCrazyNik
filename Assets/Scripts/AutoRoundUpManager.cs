using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoRoundUpManager : MonoBehaviour
{
    public List<float> autoRoundUp = new List<float>();
    public int autoRoundUpPrice = 50;
    public TextMeshProUGUI quantityText;
    public int cauntARUP = 0;
    public TextMeshProUGUI AutoRoundUpPriceText;

    void Update()
    {
        AutoRoundUpPriceText.text = "$" + autoRoundUpPrice.ToString();

        //loop through each auto clicker
        for (int i = 0; i < autoRoundUp.Count; i++)
        {
            //is it time to click?
            if(Time.time - autoRoundUp[i] >= 1.0f)
            {
                autoRoundUp[i] = Time.time;
                AnimalManager.instance.curAnimal.Damage();
            }
        }  
    }

    public void OnBuyAutoRoundUp()
    {
        if(GameManager.instance.money >= autoRoundUpPrice)
        {
            GameManager.instance.TakeMoney(autoRoundUpPrice);
            autoRoundUp.Add(Time.time);

            quantityText.text = "x" + autoRoundUp.Count.ToString();

            cauntARUP += 1;

            autoRoundUpPrice += 5 * cauntARUP;

            AutoRoundUpPriceText.text = "$" + autoRoundUpPrice.ToString();
        }
    }
}
