using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{


    public InputField createInput;
    public InputField joinInput;

    public GameObject Lobby;

    public GameObject ChooseClass;

    public Text playertwoJoinedText;

    private PhotonView photonView;


    void Start(){
      //  photonView = GetComponent<PhotonView>();
    }


    public void CreateRoom()
    {
        if(createInput.text ==""){

        }
        else{
        PhotonNetwork.CreateRoom(createInput.text);
        }
    }

    public void JoinRoom()
    {
        if(joinInput.text == ""){

        }
        else{
        PhotonNetwork.JoinRoom(joinInput.text);
        }

    }

    public override void OnJoinedRoom()
    {

        
        Lobby.SetActive(false);

        ChooseClass.SetActive(true);

        
    // if(!PhotonNetwork.IsMasterClient){

    //     playerTwoJoinedRPC();
    // }


    }

    public void backButton(){

         PhotonNetwork.Disconnect();
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void playerTwoJoinedRPC(){

        photonView.RPC(nameof(playerTwoJoined), RpcTarget.MasterClient);

    }

    [PunRPC]
    private void playerTwoJoined(){

        playertwoJoinedText.text = "PLAYER 2 HAS JOINED";

    }

}
