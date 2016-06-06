using UnityEngine;
using UnityEngine.Networking;

public class ShootWeapon : Weapon
{
    public bool debugBreak;
    public Bullet BulletToShoot;
    public float FireRate = 5f;
    public Transform BulletSpawnTransform;
    private float ShootCooldown;

    void Update()
    {
        ShootCooldown -= Time.deltaTime;
    }

    public override void Use()
    {
        if (ShootCooldown <= 0)
        {
            CmdSpawnBullet(BulletSpawnTransform.position,BulletSpawnTransform.rotation);
            ShootCooldown = 1/FireRate;
        }
    }

    [Command]
    public void CmdSpawnBullet(Vector3 position, Quaternion rotation)
    {
        GameObject bullet = (GameObject)Instantiate(BulletToShoot.gameObject, position, rotation);
        NetworkServer.Spawn(bullet);
        if(debugBreak)
            Debug.Break();
    }
}