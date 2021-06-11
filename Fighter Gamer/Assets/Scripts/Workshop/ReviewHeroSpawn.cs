using UnityEngine;

public class ReviewHeroSpawn : MonoBehaviour
{
    private GameObject hero;
    [SerializeField]
    private bool isWeapon;
    private void Start()
    {
        Cloner(false);
    }
    public void Cloner(bool isTop)
    {
        hero = GameObject.Find("Hero");
        GameObject heroReview = Instantiate(hero, transform.position + new Vector3(0, 0, -1), new Quaternion(), transform);
        heroReview.GetComponent<BounceOffEnemy>().enabled = false;
        heroReview.GetComponent<Braking>().enabled = false;
        heroReview.GetComponent<HeroDamageHandler>().enabled = false;
        heroReview.GetComponent<HeroManaHandler>().enabled = false;
        heroReview.GetComponent<HeroSetup>().enabled = false;
        heroReview.GetComponent<Rigidbody2D>().mass = 1;
        if (isWeapon)
        {
            heroReview.GetComponent<CircleCollider2D>().enabled = false;
            heroReview.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            heroReview.GetComponent<SpriteRenderer>().enabled = true;
            if(!isTop)
                heroReview.GetComponent<SpriteRenderer>().sortingOrder = 7;
            else
                heroReview.GetComponent<SpriteRenderer>().sortingOrder = 10;
            heroReview.GetComponent<Rigidbody2D>().AddForce(new Vector2(80, 0));
            for (int i = 0; i < heroReview.transform.childCount; i++)
            {
                heroReview.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        for(int i=0;i<heroReview.transform.childCount;i++)
        {
            if (heroReview.transform.GetChild(i).gameObject.GetComponent<Spin>() != null)
            {
                heroReview.transform.GetChild(i).gameObject.GetComponent<Spin>().enabled = true;
                heroReview.transform.GetChild(i).localScale = new Vector3(2, GameObject.Find("StatsHandler").GetComponent<StatsHandler>().WeaponLength);
                heroReview.transform.GetChild(i).gameObject.GetComponent<Spin>().speedOfSpin = GameObject.Find("StatsHandler").GetComponent<StatsHandler>().SpeedOfSpin;
            }

            if (!isTop)
                heroReview.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = 7;
            else
                heroReview.transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
    }
}
