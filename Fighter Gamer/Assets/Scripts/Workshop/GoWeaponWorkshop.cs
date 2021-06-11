using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GoWeaponWorkshop : MonoBehaviour
{
    private GameObject speedOfSpinText;
    private GameObject weaponLengthText;
    private GameObject weaponDamageText;
    private GameObject weaponTypeText;
    private GameObject weaponReview;
    private GameObject[] weaponReviewWeapons;
    private GameObject weaponUpgradesBG;
    private GameObject backButton;
    private GameObject backButtonText;
    private GameObject weaponUpgradesCanvas;
    private GameObject goPlayerWorkshopButton;
    private void Start()
    {
        Transform textsButtons = GameObject.Find("TextsAndButtons").transform;
        Transform properUG = GameObject.Find("ProperUpgrades").transform;

        speedOfSpinText = textsButtons.GetChild(10).gameObject;
        weaponLengthText = textsButtons.GetChild(11).gameObject;
        weaponDamageText = textsButtons.GetChild(12).gameObject;
        weaponTypeText = textsButtons.GetChild(13).gameObject;

        weaponReview = GameObject.Find("BG").transform.GetChild(2).gameObject;

        weaponReviewWeapons = new GameObject[6];
        for (int i = 0; i < weaponReview.transform.GetChild(0).childCount; i++)
        {
            weaponReviewWeapons[i] = weaponReview.transform.GetChild(0).GetChild(i).gameObject;
        }

        weaponUpgradesBG = properUG.GetChild(1).gameObject;
        backButton = backButton = textsButtons.GetChild(9).gameObject;
        backButtonText = backButton.transform.GetChild(0).gameObject;
        weaponUpgradesCanvas = properUG.GetChild(3).gameObject;
        goPlayerWorkshopButton = GameObject.Find("BG").transform.GetChild(3).GetChild(0).gameObject;
    }
    public void OnClick()
    {
        newSearch();
        speedOfSpinText.GetComponent<TextMeshProUGUI>().enabled = true;
        weaponLengthText.GetComponent<TextMeshProUGUI>().enabled = true;
        weaponDamageText.GetComponent<TextMeshProUGUI>().enabled = true;
        weaponTypeText.GetComponent<TextMeshProUGUI>().enabled = true;
        weaponLengthText.GetComponent<TextMeshProUGUI>().enabled = true;
        weaponDamageText.GetComponent<TextMeshProUGUI>().enabled = true;
        weaponTypeText.GetComponent<TextMeshProUGUI>().enabled = true;
        weaponUpgradesBG.GetComponent<SpriteRenderer>().sortingOrder = 8;
        weaponReview.GetComponent<SpriteRenderer>().sortingOrder = 9;
        for (int i = 0; i < weaponReviewWeapons.Length; i++)
        {
            if(weaponReviewWeapons[i]!=null)
                weaponReviewWeapons[i].GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
        backButton.GetComponent<Image>().enabled = true;
        backButtonText.GetComponent<TextMeshProUGUI>().enabled = true;
        weaponUpgradesCanvas.GetComponent<Canvas>().sortingOrder = 11;
        foreach (Transform child in weaponUpgradesCanvas.transform)
        {
            child.GetComponent<Button>().interactable = true;
            child.GetComponentInChildren<SpriteRenderer>().sortingOrder = 11;
        }
        goPlayerWorkshopButton.GetComponent<Button>().interactable = false;
    }
    public void OnUnClick()
    {
        newSearch();
        speedOfSpinText.GetComponent<TextMeshProUGUI>().enabled = false;
        weaponLengthText.GetComponent<TextMeshProUGUI>().enabled = false;
        weaponDamageText.GetComponent<TextMeshProUGUI>().enabled = false;
        weaponTypeText.GetComponent<TextMeshProUGUI>().enabled = false;
        weaponUpgradesBG.GetComponent<SpriteRenderer>().sortingOrder = 0;
        weaponReview.GetComponent<SpriteRenderer>().sortingOrder = 7;
        for (int i = 0; i < weaponReview.transform.GetChild(0).childCount; i++)
        {
            if (weaponReviewWeapons[i] != null)
                weaponReviewWeapons[i].GetComponent<SpriteRenderer>().sortingOrder = 7;
        }
        backButton.GetComponent<Image>().enabled = false;
        backButtonText.GetComponent<TextMeshProUGUI>().enabled = false;
        weaponUpgradesCanvas.GetComponent<Canvas>().sortingOrder = 0;
        foreach (Transform child in weaponUpgradesCanvas.transform)
        {
            child.GetComponent<Button>().interactable = false;
            child.GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
        }
        goPlayerWorkshopButton.GetComponent<Button>().interactable = true;
    }
    public void newSearch()
    {
        for (int i = 0; i < weaponReview.transform.GetChild(0).childCount; i++)
        {
            weaponReviewWeapons[i] = weaponReview.transform.GetChild(0).GetChild(i).gameObject;
        }
    }
}
