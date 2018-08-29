using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject lightPrefab;
    public GameObject bulletOrigin;
    public float startSize;
    public float endSize;
    public float time;
    public bool shouldExpand;

    void Start()
    {
        bulletOrigin = GameObject.Find("BulletOrigin");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject clone = Instantiate(lightPrefab, bulletOrigin.transform.position, this.transform.rotation);

        Player player = GetComponentInParent<Player>();
        --player.currentHealth;

        if(shouldExpand)
            StartCoroutine(Expand(clone));

        Debug.Log(player.currentHealth);
    }

    public IEnumerator Expand(GameObject light)
    {
        float size = startSize;
        for (var t=0f; t < 1; t += Time.deltaTime/time)
        {
            size = Mathf.Lerp(startSize, endSize, t);
            light.GetComponent<Light>().range = size;
            yield return null;
        }
        Destroy(light);
    }
}
