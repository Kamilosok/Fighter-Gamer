using UnityEngine;

public class PlayerUpgrading : MonoBehaviour
{
    [SerializeField]
    private byte numberOfUpgrade;
    private GameObject statsHandler;
    private readonly sbyte healthU = 2, manaU = 1, weightU = -30, armorU = 1;
    private readonly int healthC = 80, manaC = 50, weightC = 40, armorC = 120;
    private void Start()
    {
        statsHandler = GameObject.Find("StatsHandler");
    }
    public void OnClick()
    {

        switch (numberOfUpgrade)
        {
            case 1:
                if (statsHandler.GetComponent<StatsHandler>().Money >= healthC)
                {
                    if (statsHandler.GetComponent<StatsHandler>().ChangePlayerStat(numberOfUpgrade, healthU))
                    {
                        statsHandler.GetComponent<StatsHandler>().Money -= healthC;
                        statsHandler.GetComponent<SoundMaster>().PlaySound(5, new Vector3(0, 0, 0));
                    }
                }
                else
                    statsHandler.GetComponent<SoundMaster>().PlaySound(7, new Vector3(0, 0, 0));
                break;
            case 2:
                if (statsHandler.GetComponent<StatsHandler>().Money >= manaC)
                {
                    if (statsHandler.GetComponent<StatsHandler>().ChangePlayerStat(numberOfUpgrade, manaU))
                    {
                        statsHandler.GetComponent<StatsHandler>().Money -= manaC;
                        statsHandler.GetComponent<SoundMaster>().PlaySound(5, new Vector3(0, 0, 0));
                    }
                }
                else
                    statsHandler.GetComponent<SoundMaster>().PlaySound(7, new Vector3(0, 0, 0));
                break;
            case 3:
                if (statsHandler.GetComponent<StatsHandler>().Money >= weightC)
                {
                    if (statsHandler.GetComponent<StatsHandler>().ChangePlayerStat(numberOfUpgrade, weightU))
                    {
                        statsHandler.GetComponent<StatsHandler>().Money -= weightC;
                        statsHandler.GetComponent<SoundMaster>().PlaySound(5, new Vector3(0, 0, 0));
                    }
                }
                else
                    statsHandler.GetComponent<SoundMaster>().PlaySound(7, new Vector3(0, 0, 0));
                break;        
            case 4:
                if (statsHandler.GetComponent<StatsHandler>().Money >= armorC)
                {
                    if (statsHandler.GetComponent<StatsHandler>().ChangePlayerStat(numberOfUpgrade, armorU))
                    {
                        statsHandler.GetComponent<StatsHandler>().Money -= armorC;
                        statsHandler.GetComponent<SoundMaster>().PlaySound(5, new Vector3(0, 0, 0));
                    }
                }
                else
                    statsHandler.GetComponent<SoundMaster>().PlaySound(7, new Vector3(0, 0, 0));
                break;
        }
        statsHandler.GetComponent<StatsHandler>().moneyText.GetComponent<ChangeMoneyText>().ChangeText();
    }
}
