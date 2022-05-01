using UnityEngine;
using Photon.Pun;

/// <summary>
/// Simple movable camera1 implementation.
/// </summary>
public class CameraController : MonoBehaviour
{
	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	GameObject target;
	public Vector3 offset;
	
	Vector3 targetPos;

	private GameObject camera1;
	// Use this for initialization
	void Start()
	{
		target = this.gameObject;
		camera1 = GameObject.FindWithTag("MainCamera");
		targetPos = camera1.transform.position;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		// target = GameObject.Find("Player(Clone)");
		// PhotonView view;
		// view = target.GetComponent<PhotonView>();

		if (target)
		{
			Vector3 posNoZ = camera1.transform.position;
			posNoZ.z = -10f;

			Vector3 targetDirection = (this.transform.position + posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = camera1.transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

			camera1.transform.position = Vector3.Lerp(transform.position, targetPos + offset, -10f);

		}
	}

}
