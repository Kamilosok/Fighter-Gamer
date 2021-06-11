using UnityEngine;

public class WeaponUpgrading : MonoBehaviour
{
    [SerializeField]
    private byte numberOfUpgrade;
    private GameObject statsHandler;
    private readonly float speedOfSpinU = 100, weaponLengthU = 0.1f, weaponDamageU = 1, weaponTypeU = 1;
    private readonly int speedOfSpinC = 50, weaponLengthC = 65, weaponDamageC = 100, weaponTypeC = 130;
    private void Start()
    {
        statsHandler = GameObject.Find("StatsHandler");
    }
    public void OnClick()
    {
        switch (numberOfUpgrade)
        {
            case 1:
                if (statsHandler.GetComponent<StatsHandler>().Money >= speedOfSpinC)
                {
                    if (statsHandler.GetComponent<StatsHandler>().ChangeWeaponStat(numberOfUpgrade, speedOfSpinU))
                    {
                        statsHandler.GetComponent<StatsHandler>().Money -= speedOfSpinC;
                        statsHandler.GetComponent<SoundMaster>().PlaySound(5, new Vector3(0, 0, 0));
                    }
                }
                else
                    statsHandler.GetComponent<SoundMaster>().PlaySound(7, new Vector3(0, 0, 0));
                break;
            case 2:
                if (statsHandler.GetComponent<StatsHandler>().Money >= weaponLengthC)
                {
                    if (statsHandler.GetComponent<StatsHandler>().ChangeWeaponStat(numberOfUpgrade, weaponLengthU))
                    {
                        statsHandler.GetComponent<StatsHandler>().Money -= weaponLengthC;
                        statsHandler.GetComponent<SoundMaster>().PlaySound(5, new Vector3(0, 0, 0));
                    }
                }
                else
                    statsHandler.GetComponent<SoundMaster>().PlaySound(7, new Vector3(0, 0, 0));
                break;
            case 3:
                if (statsHandler.GetComponent<StatsHandler>().Money >= weaponDamageC)
                {
                    if (statsHandler.GetComponent<StatsHandler>().ChangeWeaponStat(numberOfUpgrade, weaponDamageU))
                    {
                        statsHandler.GetComponent<StatsHandler>().Money -= weaponDamageC;
                        statsHandler.GetComponent<SoundMaster>().PlaySound(5, new Vector3(0, 0, 0));
                    }
                }
                else
                    statsHandler.GetComponent<SoundMaster>().PlaySound(7, new Vector3(0, 0, 0));
                break;
            case 4:
                if (statsHandler.GetComponent<StatsHandler>().Money >= weaponTypeC)
                {
                    if (statsHandler.GetComponent<StatsHandler>().ChangeWeaponStat(numberOfUpgrade, weaponTypeU))
                    {
                        statsHandler.GetComponent<StatsHandler>().Money -= weaponTypeC;
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
