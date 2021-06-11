using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    public float Health;
    private GameObject hero;
    [SerializeField]
    private GameObject Bar;
    public float armor;
    private GameObject abilityBar;
    private GameObject statsHandler;
    private bool isKilled = false;
    [SerializeField]
    private short prize;
    private void Start()
    {
        if (Bar != null)
        {
            Bar.GetComponent<Slider>().maxValue = Health;
            Bar.GetComponent<Slider>().value = Health;
            Bar.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = gameObject.name;
        }
        statsHandler = GameObject.Find("StatsHandler");
        hero = GameObject.Find("Hero");
    }
    public void DamageHandler(float Damage)
    {
        if (Damage - armor > 1)
        {
            Health -= (Damage - armor);
            statsHandler.GetComponent<SoundMaster>().PlaySound((byte)Random.Range(0, 2), transform.position);
        }
        else
        {
            Health -= 1;
            statsHandler.GetComponent<SoundMaster>().PlaySound((byte)Random.Range(0, 2), transform.position);
        }
        ChangeBar();
        if (Health <= 0 && gameObject.GetComponent<EnemyAI>() != null && !isKilled)
        {
            gameObject.GetComponent<EnemyAI>().enabled = false;
            foreach (Transform child in transform)
            {
                child.transform.GetComponentInChildren<Spin>().ifSpin = false;
            }
            for (int i = 0; i < hero.transform.childCount; i++)
            {
            hero.transform.GetChild(i).localScale = new Vector3(2, statsHandler.GetComponent<StatsHandler>().WeaponLength, 1);
            }
            statsHandler.GetComponent<StatsHandler>().Money += prize;
            isKilled = true;
            Invoke("DestroySelf", 3);
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            statsHandler.GetComponent<SoundMaster>().PlaySound(3, transform.position);
            if (enemies.Length==1)
            {
                statsHandler.GetComponent<StatsHandler>().sceneNumber += 1;
                Invoke(nameof(GoToWorkshop), 5);
            }
        }
    }
    private void ChangeBar()
    {
        if(Bar!=null)
            Bar.GetComponent<Slider>().value = Health;
    }
    private void GoToWorkshop()
    {
        SceneManager.LoadScene(0);
    }
    private void DestroySelf()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
