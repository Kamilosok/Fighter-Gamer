using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroDamageHandler : MonoBehaviour
{
    public float Health;
    [System.NonSerialized]
    public GameObject Bar;
    [System.NonSerialized]
    public GameObject Enemy;
    [System.NonSerialized]
    public float Armor;
    private GameObject statsHandler;
    private GameObject abilityBar;
    private bool isKilled = false;
    private void Start()
    {
        abilityBar = GameObject.Find("Ability_Bar");
        statsHandler = GameObject.Find("StatsHandler");
    }
    public void DamageHandler(float damage)
    {
        if (damage - Armor > 1)
        {
            Health -= (damage - Armor);
            statsHandler.GetComponent<SoundMaster>().PlaySound((byte)Random.Range(0, 2), transform.position);
        }
        else
        {
            Health -= 1;
            statsHandler.GetComponent<SoundMaster>().PlaySound((byte)Random.Range(0, 2), transform.position);
        }
        ChangeBar();
        if (Health <= 0 && Enemy.GetComponent<EnemyAI>() != null && !isKilled)
        {
            Enemy.GetComponent<EnemyAI>().enabled = false;
            foreach(Transform child in transform)
            {
                child.transform.GetComponentInChildren<Spin>().ifSpin = false;
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).localScale = new Vector3(2, statsHandler.GetComponent<StatsHandler>().WeaponLength, 1);
            }
            isKilled = true;
            statsHandler.GetComponent<SoundMaster>().PlaySound(4, transform.position);
            statsHandler.GetComponent<StatsHandler>().Money += 10;
            Invoke(nameof(GoToWorkshop), 5);
        }
    }
    private void ChangeBar()
    {
        Bar.transform.GetChild(0).GetComponent<Slider>().value = Health;
    }
    private void SetBar()
    {
        if (Bar != null)
        {
            Bar.transform.GetChild(0).GetComponent<Slider>().maxValue = Health;
            Bar.transform.GetChild(0).GetComponent<Slider>().value = Health;
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        Invoke(nameof(SetBar), 0.1f);
    }
    private void GoToWorkshop()
    {
        isKilled = false;
        SceneManager.LoadScene(0);
    }
}
