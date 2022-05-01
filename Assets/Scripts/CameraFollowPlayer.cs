using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraFollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 posNoz;
    PhotonView view;
    public float interpVelocity;

    public Vector3 offset;

    Vector3 targetPos;

    public GameObject mCamera;
    void Start()
    {
        view = GetComponent<PhotonView>();
        mCamera = GameObject.Find("Main Camera");
        var location = this.transform.position;
        mCamera.transform.position = new Vector3(location.x, location.y, -10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (view.IsMine)
        {
            var location = this.transform.position;
            Vector3 posNoZ = mCamera.transform.position;
            posNoZ.z = 10f;

            Vector3 targetDirection = (this.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = mCamera.transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            mCamera.transform.position = Vector3.Lerp(new Vector3(this.transform.position.x, this.transform.position.y, -10f), new Vector3(this.transform.position.x, this.transform.position.y, -10f) + offset, 1);

        }
            
    }
}
