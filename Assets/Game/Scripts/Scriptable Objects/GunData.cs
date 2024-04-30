namespace Visions.Weapon {

    using UnityEngine;

    [CreateAssetMenu( fileName = "Gun", menuName = "Weapon/Gun" )]
    public class GunData : ScriptableObject {
        public new string name;

        [Header( "Shooting" )]
        public float damage;
        public float distanceIncrement;
        public float bulletSpeed;

        [Header( "Reloading" )]
        public int currentAmmo;
        public int magSize;
        public float fireRate;
        public float reloadTime;
        public bool reloading;
    }

}