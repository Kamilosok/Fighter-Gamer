using UnityEngine;

public class WeaponAmountUpgrade : MonoBehaviour
{
    private GameObject hero;
    private GameObject statsHandler;
    private short cost;
    private void Start()
    {
        cost = 250;
        hero = GameObject.Find("Hero");
        statsHandler = GameObject.Find("StatsHandler");
    }
    public void makeNextWeapon()
    {
        if (transform.GetComponentInParent<Canvas>().sortingOrder == 11)
        {
            if (hero.transform.childCount == 6)
            {
                return;
            }
            if (statsHandler.GetComponent<StatsHandler>().Money >= cost)
            {
                Instantiate(hero.transform.GetChild(0), hero.transform);
                for (int i = 0; i < hero.transform.childCount; i++)
                {
                    hero.transform.GetChild(i).eulerAngles = new Vector3(0, 0, (360 / hero.transform.childCount) * (i));
                }
                statsHandler.GetComponent<StatsHandler>().ChangeWeaponStat(0, 0);
                statsHandler.GetComponent<StatsHandler>().Money -= cost;
                statsHandler.GetComponent<SoundMaster>().PlaySound(6, new Vector3(0, 0, 0));
            }
            else
                statsHandler.GetComponent<SoundMaster>().PlaySound(7, new Vector3(0, 0, 0));
            statsHandler.GetComponent<StatsHandler>().moneyText.GetComponent<ChangeMoneyText>().ChangeText();
        }
    }
}
