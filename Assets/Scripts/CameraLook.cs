using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

    public float smooth;
    public Transform player;
    public Transform graphics;
    public float lookAhead = 2;
    public Camera cam;
    public CameraController cc;

    float x = 0;
    float y = 0;

    public float camOffset;
    float offsetX;
    float offsetY;

    Vector3 target;
    
    
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            x = (player.position.x - hit.point.x) / lookAhead;
            y = (player.position.z - hit.point.z) / lookAhead;

            float rot = Mathf.Atan2(graphics.position.x - hit.point.x, graphics.position.z - hit.point.z) * Mathf.Rad2Deg;
            graphics.rotation = Quaternion.Euler(new Vector3(-90f, 0f, rot+90f));
        }

        switch (cc.currentRot)
        {
            case 0:
                offsetX = camOffset;
                offsetY = camOffset;
                break;

            case 1:
                offsetX = -camOffset;
                offsetY = camOffset;
                break;

            case 2:
                offsetX = -camOffset;
                offsetY = -camOffset;
                break;

            case 3:
                offsetX = camOffset;
                offsetY = -camOffset;
                break;

            default:
                break;
        }

        target = new Vector3(player.position.x - x - offsetX, transform.position.y, player.position.z - y - offsetY);
    }

    private void LateUpdate()
    {
        if (!cc.isRotating)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * smooth);
        }
    }
}
