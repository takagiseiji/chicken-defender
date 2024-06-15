using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    //動画だとprojectile
    //向こうだとProjectileになる
    public Rigidbody rb;
    public float movespeed;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * movespeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chicken"))
        {
            other.GetComponent<Chicken>().Damage();//敵のダメージ関数を実行
            Destroy(gameObject);

        }

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
