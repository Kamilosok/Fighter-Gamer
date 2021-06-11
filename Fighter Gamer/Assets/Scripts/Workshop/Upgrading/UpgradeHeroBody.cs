using UnityEngine;

public class UpgradeHeroBody : MonoBehaviour
{
    private GameObject hero;
    [SerializeField]
    private Sprite[] heroSprites = new Sprite[3];
    private GameObject statsHandler;
    private short cost;
    private byte counter=1;
    private void Start()
    {
        cost = 10;
        hero = GameObject.Find("Hero");
        statsHandler = GameObject.Find("StatsHandler");
    }
    public void changeHeroSprite()
    {
        if (transform.GetComponentInParent<Canvas>().sortingOrder==11)
        {
            if (counter > 2)
            {
                return;
            }
            if (statsHandler.GetComponent<StatsHandler>().Money >= cost)
            {
                hero.GetComponent<SpriteRenderer>().sprite = heroSprites[counter];
                counter += 1;
                statsHandler.GetComponent<StatsHandler>().ChangePlayerStat(0, 0);
                statsHandler.GetComponent<StatsHandler>().Money -= cost;
                statsHandler.GetComponent<SoundMaster>().PlaySound(6, new Vector3(0, 0, 0));
            }
            else
                statsHandler.GetComponent<SoundMaster>().PlaySound(7, new Vector3(0, 0, 0));
            statsHandler.GetComponent<StatsHandler>().moneyText.GetComponent<ChangeMoneyText>().ChangeText();
        }
    }    
}
