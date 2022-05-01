using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public int test1;

    private PhotonView photonView;
    void Start()
    {
        test1 =0;   
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    public void updateTestRPC(){

        photonView.RPC(nameof(updateTest), RpcTarget.All);
    }

    [PunRPC]
    private void updateTest(){
        test1 = 1;
    }
}
