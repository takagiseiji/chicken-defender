using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESpawn : MonoBehaviour
{
    //�G���v���n�u�ł��ꂼ��ۑ�
    //�^�[�����i�ނ��ƂɃJ�E���g������̂�p�ӂ��Ă��̐��l�����܂������Ŋ���؂ꂽ�畦����
    //�������A�w�萔�����������畦�����Ȃ��悤�ɃJ�E���g����int��p�ӂ���
    //�����Đ����c���Ă�����̂�ۑ����郊�X�g���ق���
    //�s�����ԓ��Ŏg���\��������
    public Wave[] waves;
    [Serializable]
    public class Wave
    {
        public List<EnemyPattern> patterns;
    }
    [Serializable]
    public class EnemyPattern
    {
        public float time;
        public EnemyController enemy;
        public Route route;
    }
    public GameObject Enemy;
    TrunSystem trunSystem;
    EnemyManager enemyManager;

    int nowtrun = 0;
    int wave = 0;
    int time;


    // Start is called before the first frame update
    void Start()
    {
        trunSystem = GetComponent<TrunSystem>();
        enemyManager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       public void CreateEnemy()
        {
            int trun = nowtrun;
            Debug.Log(trun);//�Ȃ��������ɂ����0�ɂȂ��Ă���
                            //�����w�肵�Ēl������Ύ��s�Ƃ��ɂ���̂����������@��������Ȃ���foreach�̎��ɃG���[�ł邩������
                            //�Q�^�[�����ɗN���悤�ɂ��Ă��̃^�[���ŗN���v�f�����߂ēI�Ȃ̂�������̂����������炠����x�͌`�ɂȂ�
            if (nowtrun % 2 == 0)//�Ȃ��������ł���trunSystem.truncount
            {
                Debug.Log("�N���G�C�g�G�l�~�[");
                //Debug.Log(trunSystem);
                //wave���Ή����Ă���l�Ǝ������l���Ă���l���Ⴄ�\��
                Debug.Log(wave);
                foreach (var pattern in waves[wave].patterns)//Waves��wave�Ԃ�patterns�̐��������s ���� �����͑������̂܂܎g����
                {

                    //var enemy = pattern.enemy;//���񓮂����G��enemycontroller���擾
                    //enemy.GetComponent<EnemyController>().route = pattern.route;
                    var enemy = Instantiate(pattern.enemy, pattern.route.points[0].transform.position, Quaternion.identity);
                    enemy.route = pattern.route;//enemycontroller��route��pattern��route����
                                                //Instantiate(pattern.enemy, enemy.route.points[0].transform.position, Quaternion.identity);//�G�l�~�[����
                                                //��̖ڈȍ~�N���Ȃ�

                    if (enemy.GetComponent<GroundEnemyAction>())
                    {
                        enemy.GetComponent<GroundEnemyAction>().route = pattern.route;
                        Debug.Log("���X�g�ɒǉ�");
                       enemyManager.groundEnemyActions.Add(enemy.GetComponent<GroundEnemyAction>());
                    }
                   enemyManager.enemynumber.Add(enemy.gameObject);//�G�����X�g�̒��ɒǉ�������́@�ǉ��o�������]�ݓ���gameObject��������������Ă�������
                                                      //���ׂĂ̓G���Ǘ����邽�߂ɍ�������ǎ��񂾂�^�[���V�X�e���ɒ��ڃA�N�Z�X���Đ�������΂����C������
                                                      //enemyscount++;//�G�̐��̃J�E���g�𑝂₷
                                                      //�l���Ƃ��Ă�gameObject�̕ϐ�������ăG�l�~�[�𐶐��������ɂ����ɓ���Ă��̕ϐ������X�g�ɒǉ�
                                                      //���̍ۗv�f���Œǉ�����Ƃ��̗v�f�����邩��v�f�̒��g������ǉ�����悤�ɂ���@�ϐ���.gameObject�ōs����Ǝv�������̂܂܂ł����v����
                                                      //enemyscount++;//�G����鎞��enemyscount�̐��l�𑝂₷


                }
            waves[wave].patterns.RemoveAll(pattern => pattern.time <= time);//�Ăяo�������̂��N���X�⃊�X�g�������
                wave++;
                enemyManager.TrunEnd();

            }
            else
            {
                enemyManager.TrunEnd();
            }
        }
    }
