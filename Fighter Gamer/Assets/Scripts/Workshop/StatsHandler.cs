using UnityEngine;

public class StatsHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject heroPrefab;
    public int Money;
    public float Mana, Health, Weight, Armor;
    public float SpeedOfSpin, WeaponLength, WeaponDamage, WeaponType;
    private GameObject healthText, manaText, weightText, armorText, speedOfSpinText, weaponLengthText, weaponDamageText, weaponTypeText;
    public GameObject moneyText;
    public SpawnHero spawn;
    private GameObject weaponReview, heroReview;
    private GameObject playerButton, weaponButton;
    public byte sceneNumber;
    void Start()
    {
        spawn = gameObject.GetComponent<SpawnHero>();
        Transform textsButtons = GameObject.Find("TextsAndButtons").transform;
        Transform BG = GameObject.Find("BG").transform;

        moneyText = textsButtons.GetChild(0).gameObject;
        healthText = textsButtons.GetChild(1).gameObject;
        manaText = textsButtons.GetChild(2).gameObject;
        weightText = textsButtons.GetChild(3).gameObject;
        armorText = textsButtons.GetChild(4).gameObject;
        speedOfSpinText = textsButtons.GetChild(10).gameObject;
        weaponLengthText = textsButtons.GetChild(11).gameObject;
        weaponDamageText = textsButtons.GetChild(12).gameObject;
        weaponTypeText = textsButtons.GetChild(13).gameObject;

        heroReview = BG.GetChild(1).gameObject;
        weaponReview = BG.GetChild(2).gameObject;
        playerButton = BG.GetChild(3).GetChild(0).gameObject;
        weaponButton = BG.GetChild(3).GetChild(1).gameObject;


        if (GameObject.Find("StatsHandler") == gameObject)
        {
            Money = 450;
            Health = 10;
            Mana = 4;
            Weight = 300;
            Armor = 0;
            SpeedOfSpin = 500;
            WeaponLength = 2;
            WeaponDamage = 1;
            WeaponType = 1;
            sceneNumber = 1;
            GameObject newHero = Instantiate(heroPrefab, new Vector3(20, 20, -1), Quaternion.identity);
            newHero.name = "Hero";
            newHero.transform.SetPositionAndRotation(new Vector3(20, 20, -1), Quaternion.identity);
            spawn.heron = newHero;
        }
        else
        {
            Destroy(gameObject);
        }
        moneyText.GetComponent<ChangeMoneyText>().ChangeText();
        healthText.GetComponent<ChangeMaxHealthText>().ChangeText();
        manaText.GetComponent<ChangeMaxManaText>().ChangeText();
        weightText.GetComponent<ChangeWeightText>().ChangeText();
        armorText.GetComponent<ChangeArmorText>().ChangeText();
        speedOfSpinText.GetComponent<ChangeSpinningSpeedText>().ChangeText();
        weaponLengthText.GetComponent<ChangeWeaponLengthText>().ChangeText();
        weaponDamageText.GetComponent<ChangeWeaponDamageText>().ChangeText();
        weaponTypeText.GetComponent<ChangeWeaponTypeText>().ChangeText();
        DontDestroyOnLoad(gameObject);
    }
    public bool ChangePlayerStat(byte statNumber,sbyte statChange)
    {
        if (statNumber == 1)
        {
            Health += statChange;
            healthText.GetComponent<ChangeMaxHealthText>().ChangeText();
        }
        else
        if (statNumber == 2)
        {
            Mana += statChange;
            manaText.GetComponent<ChangeMaxManaText>().ChangeText();
        }
        else
        if (statNumber == 3)
        {
            if (Weight > 30)
            {
                Weight += statChange;
                weightText.GetComponent<ChangeWeightText>().ChangeText();
            }
            else
            {
                weightText.GetComponent<ChangeWeightText>().MaxText();
                return false;
            }
        }
        else
        if (statNumber == 4)
        {
            {
                Armor += statChange;
                armorText.GetComponent<ChangeArmorText>().ChangeText();
            }
        }
        spawn.ApplyStatsToHero();
        Health=Mathf.Round(Health);
        Mana=Mathf.Round(Mana);
        Weight=Mathf.Round(Weight);
        Armor=Mathf.Round(Armor);
        Destroy(heroReview.transform.GetChild(0).gameObject);
        heroReview.GetComponent<ReviewHeroSpawn>().Cloner(true);
        playerButton.GetComponent<GoPlayerWorkshop>().newSearch();
        return true;
    }
    public bool ChangeWeaponStat(byte statNumber, float statChange)
    {
        if (statNumber == 1)
        {
            SpeedOfSpin += statChange;
            speedOfSpinText.GetComponent<ChangeSpinningSpeedText>().ChangeText();
        }
        else
        if (statNumber == 2)
        {
            if (WeaponLength <= 3.6f)
            {
                WeaponLength += statChange;
                weaponLengthText.GetComponent<ChangeWeaponLengthText>().ChangeText();
            }
            else
            {
                weaponLengthText.GetComponent<ChangeWeaponLengthText>().MaxText();
                return false;
            }
        }
        else
        if (statNumber == 3)
        {
            WeaponDamage += statChange;
            weaponDamageText.GetComponent<ChangeWeaponDamageText>().ChangeText();
        }
        else
        {
        if (statNumber == 4)
        {
                if (WeaponType < 3)
                {
                    WeaponType += statChange;
                    weaponTypeText.GetComponent<ChangeWeaponTypeText>().ChangeText();
                }
                else
                {
                    weaponTypeText.GetComponent<ChangeWeaponTypeText>().MaxText();
                    return false;
                }
        }
        }
        SpeedOfSpin=Mathf.Round(SpeedOfSpin);
        WeaponLength=Mathf.Round(WeaponLength*100f)/100f;
        WeaponDamage=Mathf.Round(WeaponDamage);
        for (int i= 0; i<weaponReview.transform.GetChild(0).childCount; i++)
        {
            weaponReview.transform.GetChild(0).GetChild(i).localScale = new Vector3(2, WeaponLength, 1);
        }
        Destroy(weaponReview.transform.GetChild(0).gameObject);
        spawn.ApplyStatsToHero();
        weaponReview.GetComponent<ReviewHeroSpawn>().Cloner(true);
        weaponButton.GetComponent<GoWeaponWorkshop>().newSearch();
        return true;
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            GameObject newHero = GameObject.Find("Hero");
            Transform textsButtons = GameObject.Find("TextsAndButtons").transform;
            Transform BG = GameObject.Find("BG").transform;

            moneyText = textsButtons.GetChild(0).gameObject;
            healthText = textsButtons.GetChild(1).gameObject;
            manaText = textsButtons.GetChild(2).gameObject;
            weightText = textsButtons.GetChild(3).gameObject;
            armorText = textsButtons.GetChild(4).gameObject;
            speedOfSpinText = textsButtons.GetChild(10).gameObject;
            weaponLengthText = textsButtons.GetChild(11).gameObject;
            weaponDamageText = textsButtons.GetChild(12).gameObject;
            weaponTypeText = textsButtons.GetChild(13).gameObject;

            heroReview = BG.GetChild(1).gameObject;
            weaponReview = BG.GetChild(2).gameObject;

            playerButton = BG.GetChild(3).GetChild(0).gameObject;
            weaponButton = BG.GetChild(3).GetChild(1).gameObject;

            for (int i = 0; i < newHero.transform.childCount; i++)
            {
                newHero.transform.GetChild(i).localScale = new Vector3(2, GetComponent<StatsHandler>().WeaponLength, 1);
            }
        }
        else
            if (level == 10)
                GetComponent<SoundMaster>().PlaySound(3, new Vector3(0, 0, 0));
    }
}
