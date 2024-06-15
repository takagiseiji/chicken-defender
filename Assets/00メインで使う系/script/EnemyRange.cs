using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    //�n��͐��ʂ����̗\��Ői�߂邱�Ƃɂ����@���̂��߂����͗v��Ȃ��ăR�[�h������s�n�̂Ƃ���ɉf�������ŏo����悤�ɂȂ邩������Ȃ�
    //���悾��Tower
    //�U�������n�̕����������Ă��Ȃ����炱�̖��O�����Ǎ��㑝����ꍇ�ʂ̖��O�ɂȂ�(���Ԃ�Arrow���t���������Ǝv��)
    //�U��������Ƃ���́@�͈͂͑S��0�ŕ��킲�Ƃɋ����𑫂����@���ꂼ��Unity��Œl�ς���
    //�{�̍U���̎��������̂܂܎����Ă��ď����ς��������ɂȂ�
    //�U���͈͎͂�O�ɋ�I�u�W�F�N�g�����Ă��ꂼ��͈̔͂��w�肷��������͌{�Ɠ����ɂ��邩������
    //�{�Ɠ������ƌ��ɂ��U�����邱�ƂɂȂ邻�̂��ߐi�s���x�͒x���Ȃ�
    //�����ĂƂ��đO�������ɂ��邩�����_���ɂ��Ċm���ōU�����錟���������_���ɂ����ꍇ���ʂ̓G���U�����Ȃ��\��������
    //�V�����đS�̂����邯�ǐi�s�����ɕʃI�u�W�F�N�g�������ēG�����邩�ǂ����m�F����@����΍U�����Ȃ���Έ�O�ɍU�����Ă�����i��
    //�ꏊ�̖�肾����R�[�h�͊֌W�Ȃ��͂�
    //�U���̃R�[�h�͌{�Ɠ���
    public float range = 1f;
    public float length = 1f;
    public float height = 3f;
    public float width = 1f;
    public Vector3 size;

    public LayerMask whatIsEnemy;
    public Collider[] colliderInRange;
    public List<Chicken> enemiesInRange = new List<Chicken>();
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
            enemiesInRange.Add(col.GetComponent<Chicken>());//enemiesInRange�Ɏ擾��������ǉ�
                                                                    //Update�ł���Ă��邩����s���ɂ��ׂăN���A���Ă�����x�m�F���Ă���
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,size);
    }
}
