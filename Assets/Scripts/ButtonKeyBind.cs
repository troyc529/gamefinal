 using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ButtonKeyBind : MonoBehaviour
{

    public Transform players;

    public Button aoeHeal;

    public Button buffArmor;

    public Button BigSwing;

    public Button BigShot;

    public GameObject MenuMusic;

    public GameObject firstAreaMusic;
    private float AbilityOneElapsedTime;
    private float AbilityTwoElapsedTime;

    private float secondsBetween;
    private float secondsBetween2;

    private PhotonView[] photonViews;

    public Text buffArmorText;

    public Text bigSwingText;

    public Text aoeHealText;

    public Text bigShotText;
    void Start()
    {
        secondsBetween = 10f;
        secondsBetween2 = 10f;

        AbilityOneElapsedTime = 10f;
        AbilityTwoElapsedTime = 10f;

        MenuMusic.gameObject.SetActive(false);
        firstAreaMusic.SetActive(true);

    }

    void Update()
    {
        AbilityOneElapsedTime += Time.deltaTime;
      
        AbilityTwoElapsedTime += Time.deltaTime;
     

        if (buffArmor.interactable == false)
        {
            buffArmorText.enabled = true;
            var text = 10 - ((int)(AbilityOneElapsedTime.ToString()[0]) - 48);
            buffArmorText.text = text.ToString();
        }
        if (BigSwing.interactable == false)
        {
            bigSwingText.enabled = true;
            var text = 10 - ((int)(AbilityTwoElapsedTime.ToString()[0]) - 48);
            bigSwingText.text = text.ToString();

        }

        if (aoeHeal.interactable == false)
        {
            aoeHealText.enabled = true;
            var text1 = 10 - ((int)(AbilityOneElapsedTime.ToString()[0]) - 48);
            aoeHealText.text = text1.ToString();
        }

        if (BigShot.interactable == false)
        {
            bigShotText.enabled = true;
            var text = 10 - ((int)(AbilityTwoElapsedTime.ToString()[0]) - 48);
            bigShotText.text = text.ToString();

        }

        if (AbilityOneElapsedTime > secondsBetween2)
        {
            aoeHeal.interactable = true;
            aoeHealText.enabled = false;
        }
        if (AbilityOneElapsedTime > secondsBetween2)
        {
            buffArmor.interactable = true;
            buffArmorText.enabled = false;
        }
        if (AbilityTwoElapsedTime > secondsBetween)
        {
            BigShot.interactable = true;
            bigShotText.enabled = false;
        }
        if (AbilityTwoElapsedTime > secondsBetween)
        {
            BigSwing.interactable = true;
            bigSwingText.enabled = false;
        }


        if (Input.GetKeyDown(KeyCode.Q) && AbilityOneElapsedTime > secondsBetween2)
        {
            if (aoeHeal.gameObject.activeSelf == true)
            {
                aoeHeal.onClick.Invoke();
                aoeHeal.interactable = false;
                AbilityOneElapsedTime = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && AbilityOneElapsedTime > secondsBetween2)
        {
            if (buffArmor.gameObject.activeSelf == true)
            {
                buffArmor.onClick.Invoke();
                buffArmor.interactable = false;
                AbilityOneElapsedTime = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && AbilityTwoElapsedTime > secondsBetween)
        {
            if (BigShot.gameObject.activeSelf == true)
            {
                BigShot.onClick.Invoke();
                BigShot.interactable = false;
                AbilityTwoElapsedTime = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && AbilityTwoElapsedTime > secondsBetween)
        {
            if (BigSwing.gameObject.activeSelf == true)
            {
                BigSwing.onClick.Invoke();
                BigSwing.interactable = false;
                AbilityTwoElapsedTime = 0f;
            }
        }
    }
}