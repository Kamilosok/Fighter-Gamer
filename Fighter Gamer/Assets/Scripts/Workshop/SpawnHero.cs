using UnityEngine;

public class SpawnHero : MonoBehaviour
{
    public GameObject heron;
    private void OnLevelWasLoaded(int level)
    {
        if (level > 0)
        {
            ApplyStatsToHero();
        }
    }
    public void ApplyStatsToHero()
    {
        StatsHandler stats = gameObject.GetComponent<StatsHandler>();
        heron.GetComponent<HeroDamageHandler>().Health = stats.Health;
        heron.GetComponent<HeroManaHandler>().Mana = stats.Mana;
        heron.GetComponent<Braking>().speedOfBraking = stats.Weight;
        heron.GetComponent<HeroDamageHandler>().Armor = stats.Armor;
        
        for (int i = 0; i < heron.transform.childCount; i++)
        {
            heron.transform.GetChild(i).GetComponent<Spin>().speedOfSpin = stats.SpeedOfSpin;
            heron.transform.GetChild(i).localScale = new Vector3(2, stats.WeaponLength, 1);
            heron.transform.GetChild(i).GetComponent<WeaponAttack>().damage = stats.WeaponDamage;
            heron.transform.GetChild(i).GetComponent<WeaponAttack>().weaponType = stats.WeaponType;
        }
    }
}
