using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {
    public GameObject BulletPrefab;
    public Transform spawnLocation;
    public bool canShoot;
    public float coolDownDelay = 1f, burstDelay = 0.3f;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            canShoot = true;
            StartCoroutine(CoolDown());
            Debug.Log("gigigigigi, BANG BANG, BLLLEEGHU, BOO BOO BOO, GE GE!");
        } else if (Input.GetMouseButtonUp(0))
        {
            canShoot = false;
            StopCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown() {
        while (canShoot) {
            yield return new WaitForSeconds(coolDownDelay);

            //Instantiate the bullet on the bulletTransform (seen in inspector).
            Instantiate(BulletPrefab, spawnLocation.position, Quaternion.identity);
        }
    }
}
