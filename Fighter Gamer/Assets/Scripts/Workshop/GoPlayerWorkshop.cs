using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GoPlayerWorkshop : MonoBehaviour
{
    private GameObject maxHealthText;
    private GameObject maxManaText;
    private GameObject weightText;
    private GameObject armorText;
    private GameObject heroReview;
    private GameObject heroReviewBody;
    private GameObject playerUpgradesBG;
    private GameObject backButton;
    private GameObject backButtonText;
    private GameObject playerUpgradesCanvas;
    private GameObject goWeaponWorkshopButton;
    private void Start()
    {
        Transform textsButtons = GameObject.Find("TextsAndButtons").transform;
        Transform properUG = GameObject.Find("ProperUpgrades").transform;

        maxHealthText = textsButtons.GetChild(1).gameObject;
        maxManaText = textsButtons.GetChild(2).gameObject;
        weightText = textsButtons.GetChild(3).gameObject;
        armorText = textsButtons.GetChild(4).gameObject;

        heroReview = GameObject.Find("BG").transform.GetChild(1).gameObject;

        heroReviewBody = heroReview.transform.GetChild(0).gameObject;
        playerUpgradesBG = properUG.GetChild(0).gameObject;
        backButton = textsButtons.GetChild(8).gameObject;
        backButtonText = backButton.transform.GetChild(0).gameObject;
        playerUpgradesCanvas = properUG.GetChild(2).gameObject;
        goWeaponWorkshopButton = GameObject.Find("BG").transform.GetChild(3).GetChild(1).gameObject;
    }
    public void OnClick()
    {
        newSearch();
        maxHealthText.GetComponent<TextMeshProUGUI>().enabled = true;
        maxManaText.GetComponent<TextMeshProUGUI>().enabled = true;
        weightText.GetComponent<TextMeshProUGUI>().enabled = true;
        armorText.GetComponent<TextMeshProUGUI>().enabled = true;
        playerUpgradesBG.GetComponent<SpriteRenderer>().sortingOrder = 8;
        heroReview.GetComponent<SpriteRenderer>().sortingOrder = 9;
        heroReviewBody.GetComponent<SpriteRenderer>().sortingOrder = 10;
        backButton.GetComponent<Image>().enabled = true;
        backButtonText.GetComponent<TextMeshProUGUI>().enabled = true;
        playerUpgradesCanvas.GetComponent<Canvas>().sortingOrder = 11;
        foreach(Transform child in playerUpgradesCanvas.transform)
        {
            child.GetComponent<Button>().interactable = true;
            child.GetComponentInChildren<SpriteRenderer>().sortingOrder = 11;
        }
        goWeaponWorkshopButton.GetComponent<Button>().interactable = false;
    }
    public void OnUnClick()
    {
        newSearch();
        maxHealthText.GetComponent<TextMeshProUGUI>().enabled = false;
        maxManaText.GetComponent<TextMeshProUGUI>().enabled = false;
        weightText.GetComponent<TextMeshProUGUI>().enabled = false;
        armorText.GetComponent<TextMeshProUGUI>().enabled = false;
        playerUpgradesBG.GetComponent<SpriteRenderer>().sortingOrder = 0;
        heroReview.GetComponent<SpriteRenderer>().sortingOrder = 7;
        heroReviewBody.GetComponent<SpriteRenderer>().sortingOrder = 7;
        backButton.GetComponent<Image>().enabled = false;
        backButtonText.GetComponent<TextMeshProUGUI>().enabled = false;
        playerUpgradesCanvas.GetComponent<Canvas>().sortingOrder = 0;
        foreach (Transform child in playerUpgradesCanvas.transform)
        {
            child.GetComponent<Button>().interactable = false;
            child.GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
        }
        goWeaponWorkshopButton.GetComponent<Button>().interactable = true;
    }
    public void newSearch()
    {
        heroReviewBody = heroReview.transform.GetChild(0).gameObject;
    }
}
