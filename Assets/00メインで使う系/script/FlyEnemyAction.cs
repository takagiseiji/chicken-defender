using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyAction : MonoBehaviour
{
    //���ł���n�̓G�̃R�[�h
    //��{�n��̂������Ă��ď�������������Ί��������U����ray�ł͂Ȃ���enemyrange�̃R�[�h���ێ��Ďg���΂���

    //�U���Ɏg����Ǝv��
    /*else if (attackcount == 0)�@//�����͔͈͓��ɂ����z�����ǐ��ʂ����s���ɂ��邩��v��Ȃ�����
       {
           //target�Ƀ��X�g�̈�ԏ�̌{�̏�������
           if (enemyRange.enemiesInRange.Count > 0)
           {
               target = enemyRange.enemiesInRange[0].gameObject;
               yield return new WaitForSeconds(1.0f);//�����o���邾��������Ȃ����炢�̎��Ԃɂ������@���ō��͂P�b�ɂ��Ă���
               Attack();
               attackcount++;
           }*/
    /*else
    {
        yield return new WaitForSeconds(1.0f);//�����o���邾��������Ȃ����炢�̎��Ԃɂ������@���ō��͂P�b�ɂ��Ă��� �v��Ȃ�����
        enemyController.Move();
        attackcount = 0;
    }

}*/
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
