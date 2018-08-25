using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject lightPrefab;
    public Camera cam;
    public float startSize;
    public float endSize;
    public float time;

    private void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot(hit.point);
            }
        }
    }

    void Shoot(Vector3 pos)
    {
        GameObject clone = Instantiate(lightPrefab, pos, Quaternion.identity);
        StartCoroutine(Expand(clone));
    }

    public IEnumerator Expand(GameObject light)
    {
        float size = startSize;
        for(var t=0f; t < 1; t += Time.deltaTime/time)
        {
            size = Mathf.Lerp(startSize, endSize, t);
            //This is temporary:
            light.transform.localScale = new Vector3(size, size, size);
            //
            yield return null;
        }
    }
}
