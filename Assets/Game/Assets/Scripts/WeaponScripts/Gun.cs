using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunData gunData;
    [SerializeField] private Transform muzzle;
    float timeSinceLastShot;
    public GameObject bullet;
    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
    }
    public void StartReload()
    {
        if (!gunData.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);
        gunData.currentAmmo = gunData.magSize;
        gunData.reloading = false;
    }
    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);
    public void Shoot() //might not want it to be ienumerator
    {   

        int currentIndex = 0;
        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                GameObject firedBullet = Instantiate<GameObject>(bullet, muzzle.position, muzzle.rotation);

                Vector3 initPos = muzzle.position;
                Vector3 currPos = initPos;
                Vector3 endPos;

                float timeIncrement = 0.06f;
                float time = timeIncrement;

                Ray r = new Ray(muzzle.position, transform.forward);

                float xVel = (r.GetPoint(gunData.bulletSpeed) - currPos).x;
                float yVel = (r.GetPoint(gunData.bulletSpeed) - currPos).y;
                float zVel = (r.GetPoint(gunData.bulletSpeed) - currPos).z;

                float newX = currPos.x;
                float newY = currPos.y;
                float newZ = currPos.z;

                
                while (currentIndex < 100) //for arcing raycast
                {
                    newX += xVel * timeIncrement;
                    newY = GetHeight(initPos.y, yVel, time);
                    newZ += zVel * timeIncrement;

                    endPos = new Vector3(newX, newY, newZ);

                    Ray currRay = new Ray(currPos, endPos - currPos);
                    Debug.DrawRay(currPos, endPos - currPos, Color.red, 10);

                    currPos = endPos;
                    time += timeIncrement;
                    currentIndex++;
                }

                
                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
            }
        }
    }


    private float GetDistanceOfRay(Vector3 start, Vector3 end)
    {
        return (float)Mathf.Sqrt(Mathf.Pow(end.x - start.x, 2) + Mathf.Pow(end.y - start.y, 2) + Mathf.Pow(end.y - start.y, 2));
    }
    private float GetHeight(float currY, float velY, float time)
    {
        return (float)(currY + velY * time - 4.9 * time * time);
    }
    private void OnGunShot()
    {
        
    }
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

    }
}
