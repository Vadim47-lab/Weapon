using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Weapon Weapon;

    private void Update()
    {
        //if ()
        //{

        //}
    }

    public void OnSeePlayer(Player player)
    {
        Weapon.GenerateBullet();
    }
}