using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 150;
    public Text moneyText;
    public Text liveText;
    public static int Rounds;
    public static int Lives;
    public int startLives = 20;


    private void Start()
    {
        Rounds = 0;
        money = startMoney;
        Lives = startLives;

        InvokeRepeating("UpdateText", 0f, 0.5f);
    }

    public static void AddMoney() 
    {
        money += 100;
    }

    void UpdateText() 
    {
        moneyText.text = "";
        moneyText.text = money.ToString();
        moneyText.text += " $";

        liveText.text = "Lives : ";
        liveText.text += Lives.ToString();


    }

     
}
