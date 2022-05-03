using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ChooseClass : MonoBehaviour
{
    public GameObject Ranger;
    public GameObject Warrior;

    public GameObject prefabWar;

    public GameObject prefabRange;

    private Button warButton;
    private Button rangeButton;

    public GameObject EnemyAI;

    public GameObject abilityRanger;

    public GameObject abilityWarrior;

    public GameObject ButtonBrain;

    public GameObject startGameButton;

    private bool warriorSelected;

    private bool rangerSelected;

    private bool UIAbilityRanger;

    private bool UIAbilityWarrior;

    private PhotonView photonView;

    private List<GameObject> players;

    public Text warText;

    public Text rangeText;

    private List<GameObject> classes;

    private int classIndex;

    public Image titleUI;

    public Image DescriptionUI;
    public Sprite warriorTitleUI;

    public Sprite rangerTitleUI;

    public Sprite WarriorDescriptionUI;

    public Sprite RangerDescriptionUI;

    public GameObject warriorSprite;

    public GameObject rangerSprite;

    private float elapsedTime;


    void Start()
    {
        photonView = GetComponent<PhotonView>();
        warButton = Warrior.GetComponent<Button>();
        rangeButton = Ranger.GetComponent<Button>();
        players = new List<GameObject>(2);
        classes = new List<GameObject>(2);
        classes.Add(GameObject.Find("Ranger"));
        classes.Add(GameObject.Find("Warrior"));
        classIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
      

        if (warriorSelected == true)
        {
            warButton.interactable = false;
            //  prevButton.interactable= false;
            //  nextButton.interactable= false;

        }
        if (rangerSelected == true)
        {
            rangeButton.interactable = false;
            // prevButton.interactable= false;
            //  nextButton.interactable= false;

        }
        if (PhotonNetwork.IsMasterClient)
        {
            startGameButton.SetActive(true);
        }
    }

    public void WarriorButton()
    {
        UIAbilityWarrior = true;
        rangeButton.interactable = false;
       // warText.text = "Warrior Selected";
        shutoffButtonwarRPC();
        // if(!PhotonNetwork.IsMasterClient){
        //     playerTwoReadyRPC();
        // }

    }

    public void RangerButton()
    {
        UIAbilityRanger = true;
        warButton.interactable = false;
       // rangeText.text = "Ranger Selected";
        shutoffButtonrangeRPC();
        // if(!PhotonNetwork.IsMasterClient){
        //     playerTwoReadyRPC();
        // }


    }

    public void startGame()
    {
        var playerlist = PhotonNetwork.PlayerList;
        if (warriorSelected == true)
        {

            var player = PhotonNetwork.Instantiate(prefabWar.name, new Vector3(0f, 0f, 0f), Quaternion.identity);
            if (UIAbilityWarrior == false)
            {
                player.GetPhotonView().TransferOwnership(playerlist[1]);
            }

        }
        if (rangerSelected == true)
        {

            var player = PhotonNetwork.Instantiate(prefabRange.name, new Vector3(0f, 0f, 0f), Quaternion.identity);
            if (UIAbilityRanger == false)
            {
                player.GetPhotonView().TransferOwnership(playerlist[1]);
            }

        }
        EnemyAI.GetComponent<SpawnEnemies>().enabled = true;
    
        


        startGameLoopRPC();


    }

    public void backButton(){

         PhotonNetwork.Disconnect();
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void shutoffButtonwarRPC()
    {
        photonView.RPC(nameof(shutoffwarButton), RpcTarget.AllBuffered, new object[]{PhotonNetwork.LocalPlayer.ActorNumber});
    }

    [PunRPC]
    private void shutoffwarButton(int playerNum)
    {
        warriorSelected = true;
       // warText.text = "Player "+ playerNum;
    }

    private void shutoffButtonrangeRPC()
    {
        photonView.RPC(nameof(shutoffrangeBUtton), RpcTarget.AllBuffered, new object[]{PhotonNetwork.LocalPlayer.ActorNumber});
    }

    [PunRPC]
    private void shutoffrangeBUtton(int playerNum)
    {

        rangerSelected = true;
       // rangeText.text = "Player "+ playerNum;
    }

    private void startGameLoopRPC()
    {
        photonView.RPC(nameof(startGameLoop), RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void startGameLoop()
    {
        gameObject.SetActive(false);
        ButtonBrain.SetActive(true);
        if (UIAbilityRanger == true)
        {
            abilityRanger.SetActive(true);
        }
        if (UIAbilityWarrior == true)
        {
            abilityWarrior.SetActive(true);
        }

    }

    public void nextClass(){
     
        if(classIndex == 0){
            titleUI.overrideSprite = warriorTitleUI;
            DescriptionUI.overrideSprite = WarriorDescriptionUI;
            warriorSprite.SetActive(true);
            rangerSprite.SetActive(false);
            warButton.gameObject.SetActive(true);
            rangeButton.gameObject.SetActive(false);
            classIndex = 1;
        }
        else{
            titleUI.overrideSprite = rangerTitleUI;
            DescriptionUI.overrideSprite = RangerDescriptionUI;
             warriorSprite.SetActive(false);
            rangerSprite.SetActive(true);
            warButton.gameObject.SetActive(false);
            rangeButton.gameObject.SetActive(true);
            classIndex = 0;
        }
        
    }

  

}
