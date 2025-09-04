using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character
{
    public string name;  //attribute
    public int hp;
    public Character(string n, int h)  //constructor
    {
        name = n;
        hp = h;
    }
}

public class Gameplay : MonoBehaviour
{
    TextMeshProUGUI playerName;
    Image hpBar;
    Character player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = new Character("PicoChan", 100);
        playerName = GameObject.Find("PlayerName").GetComponent<TextMeshProUGUI>();
        hpBar = GameObject.Find("HP").GetComponent<Image>();
        playerName.text = player.name;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = (float)player.hp / 100f;
    }
}