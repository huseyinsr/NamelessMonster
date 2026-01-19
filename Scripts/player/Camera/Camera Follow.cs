using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // the object camera follows
    public float smoothSpeed = 0.125f;
    public Vector3 offset;      // the distance between camera and player

    void Start()
    {
        if (target == null)// if target isn't chosed find the object named Player
        {
            GameObject player = GameObject.Find("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
    }
    void LateUpdate()
    {
        if (target != null)//if target is exist make a distance between Player and camera also make Player the center of camera
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}


















































//made by ata sekercioglu