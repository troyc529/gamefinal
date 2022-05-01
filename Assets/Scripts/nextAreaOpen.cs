using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class nextAreaOpen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyAI;

    public GameObject Door;
    private PhotonView photonView;

    private float elapsedTime;

    public bool areatrigger;


    void Start()
    {

        photonView = gameObject.GetPhotonView();
        elapsedTime = 0;
        areatrigger = false;
    }
    void Update()
    {

        if (areatrigger)
        {
            Debug.Log("WORKED");
            enableTextRPC();
            elapsedTime += Time.deltaTime;
            if (elapsedTime > 5f)
            {
                disableTextRPC();
                this.enabled = false;
            }
        }
    }

    private void enableTextRPC()
    {
        photonView.RPC(nameof(enableText), RpcTarget.All);
    }

    [PunRPC]
    private void enableText()
    {

        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Door.GetComponent<DoorControl>().OpenDoor();
    }

    private void disableTextRPC()
    {
        photonView.RPC(nameof(disableText), RpcTarget.All);
    }
    [PunRPC]
    private void disableText()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }


}
