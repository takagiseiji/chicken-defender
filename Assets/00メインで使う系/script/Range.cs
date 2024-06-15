using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{//���悾��Tower
    //�U�������n�̕����������Ă��Ȃ����炱�̖��O�����Ǎ��㑝����ꍇ�ʂ̖��O�ɂȂ�(���Ԃ�Arrow���t���������Ǝv��)
    //�U��������Ƃ���́@�͈͂͑S��0�ŕ��킲�Ƃɋ����𑫂����@���ꂼ��Unity��Œl�ς���
    public float range = 1f;
    public float length = 1f;
    public float height = 3f;
    public float width = 1f;
    public Vector3 size;

    public LayerMask whatIsEnemy;
    public Collider[] colliderInRange;
    //EnemyController�͓G�̃X�N���v�g���ɒu��������炵�������̂܂܎g��������
    public List<EnemyController> enemiesInRange = new List<EnemyController>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //���ꓙ�̓^�[��������Ă����瓮���֐��Ɉړ������ �G�l�~�[�g���K�[�ɂ������班���ύX���Ȃ��Ƃ����Ȃ�����
        Quaternion q = transform.rotation;
        //colliderInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);
        colliderInRange = Physics.OverlapBox(transform.position, new Vector3(length, height, width), q, whatIsEnemy);
        enemiesInRange.Clear();//�ǉ�����O�ɂ��łɓ����Ă�����̂𖳂���
        //�������牺����������͊o���Ă��Ȃ��������Ȃ�̉��߂������@���x���K
        foreach (Collider col in colliderInRange)//colliderInRange�̒��g����ɂȂ�܂Ł@��collider�ɓ���邱�ƂŊm�F�@����Ȃ���ΏI��
        {
            enemiesInRange.Add(col.GetComponent<EnemyController>());//enemiesInRange�Ɏ擾��������ǉ�
                                                                    //Update�ł���Ă��邩����s���ɂ��ׂăN���A���Ă�����x�m�F���Ă���
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size*2);
    }
}
