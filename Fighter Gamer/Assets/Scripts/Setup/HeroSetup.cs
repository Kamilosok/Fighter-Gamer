using UnityEngine;

public class HeroSetup : MonoBehaviour
{
    private GameObject statsHandler;
    void Start()
    {
        statsHandler = GameObject.Find("StatsHandler");
        DontDestroyOnLoad(gameObject);
    }
    private void OnLevelWasLoaded(int level)
    {
        transform.SetPositionAndRotation(new Vector3(20, 20, -1), Quaternion.identity);
        if (GameObject.Find("Health_Bar") != null)
        {
            gameObject.GetComponent<HeroDamageHandler>().Bar = GameObject.Find("Health_Bar");
            gameObject.GetComponent<HeroManaHandler>().Bar = GameObject.Find("Mana_Bar");
            gameObject.GetComponent<HeroDamageHandler>().Enemy = GameObject.FindGameObjectWithTag("Enemy");
            gameObject.GetComponent<HeroDamageHandler>().Health = statsHandler.GetComponent<StatsHandler>().Health;
            gameObject.GetComponent<HeroManaHandler>().Mana = statsHandler.GetComponent<StatsHandler>().Mana;
            gameObject.GetComponent<Braking>().speedOfBraking = statsHandler.GetComponent<StatsHandler>().Weight;
        }
        if (level == 1)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<HeroSetup>().enabled = true;
            gameObject.GetComponent<BounceOffEnemy>().enabled = true;
            gameObject.GetComponent<Braking>().enabled = true;
            foreach(Transform child in transform)
            {
                child.GetComponent<MoveAfterSth>().enabled = transform;
            }
        }
    }
}
