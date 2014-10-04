using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {
	
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;
	
	void Update ()
	{
		float dx = Input.GetAxis("Mouse X");
		dx = dx * Mathf.Abs(dx); // squares mouse x while keeping the polarity
		float dy = Input.GetAxis("Mouse Y");
		dy = dy * Mathf.Abs(dy); // squares mouse y while keeping the polarity
		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + dx * sensitivityX;
			rotationY += dy * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, dx * sensitivityX, 0);
		}
		else
		{
			rotationY += dy * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
	}
	
	void Start ()
	{
		if (rigidbody) rigidbody.freezeRotation = true;
	}
}