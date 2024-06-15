using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //���悾��projectile
    //����������Projectile�ɂȂ�
    public Rigidbody rb;
    public float movespeed;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * movespeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<EnemyController>().Damage();//�G�̃_���[�W�֐������s
            Destroy(gameObject);
            
        }
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
