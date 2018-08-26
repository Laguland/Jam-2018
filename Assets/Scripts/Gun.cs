using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject lightPrefab;
    public float startSize;
    public float endSize;
    public float time;
    public bool shouldExpand;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject o = GameObject.Find("BulletOrigin");
        GameObject clone = Instantiate(lightPrefab, o.transform.position, this.transform.rotation);

        if(shouldExpand)
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
