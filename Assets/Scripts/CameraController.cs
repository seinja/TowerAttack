using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float penSpeed = 30f;
    public float penBorder = 10f;

    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward*penSpeed*Time.deltaTime,Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * penSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.left * penSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.right * penSpeed * Time.deltaTime, Space.World);
        }
    }
}
