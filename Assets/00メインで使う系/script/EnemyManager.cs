using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public TrunSystem trunSystem;
    ESpawn eSpawn;
    //�N���������܂��Ă��邩��|��邽�тɐ��𑝂₵�A�ő�Ɠ����ɂȂ�����I���ɂ���@������ʂ͂ǂ��ŏo����������
    //���̊Ǘ��͓����Ƃ���ł�肽�����炱���ł�낤���� �ЂƂ܂��n�߂̃X�e�[�W�Ƃ������ƂŗN���ʂ͏��Ȃ�
    public int maxenemys = 10;
    public int enemyscount=0;
    public int nowenemys = 0;
    public  Wave[] waves;
    private int wave;
    public float time;
    public GroundEnemyAction groundaction;
    public List<GroundEnemyAction> groundEnemyActions;
    public List<FlyEnemyAction> flyEnemyActions;
    public List<GameObject> enemynumber;
    public int groundenemys = 0;
    int flyenemys = 0;
    
    private int nowtrun = 0;
    
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
    // Start is called before the first frame update
    void Start()
    {
        trunSystem = GetComponent<TrunSystem>();
        eSpawn = GetComponent<ESpawn>();
    }
    /*void Update()
    {
        wave = 0;
        time += Time.deltaTime;//�����悭�킩���Ă��Ȃ��@�����g��Ȃ�
        CreateEnemy();
    }*/
    public void TrunStart()
    {
        Debug.Log("e�^�[���X�^�[�g");
        Debug.Log(trunSystem.truncount);
        Debug.Log(nowtrun);
        //��������Ƃ��납��Ǝv�������ǂ�������Ǝn�߂̃^�[�����s������\�������邻�ꂪ�N����ꍇ�͍Ō�ɂ킩�����ق�������
        //��L�̂��Ƃ����܂��Ďn�߂Ɉړ������ďI�������N���悤�ɂ���
        //CreateEnemy();
        groundenemys = 0;
        Enemysmove();

    }
    public void TrunEnd()
    {
        nowtrun++;
        Debug.Log(nowtrun);
        Debug.Log("e�G���h");
        trunSystem.Etrunend();
    }
    public void EnemyDead()
    {
        enemyscount++;
        if (enemyscount >= maxenemys)
        {
            Debug.Log("�N���A1");
            //trunSystem.GameClear();
        }
    }


    //void CreateEnemy()
    //{
    //    eSpawn.CreateEnemy();
    //}

    public void CreateEnemy()
    {
        Debug.Log(nowtrun);//�Ȃ��������ɂ����0�ɂȂ��Ă���
        //�����w�肵�Ēl������Ύ��s�Ƃ��ɂ���̂����������@��������Ȃ���foreach�̎��ɃG���[�ł邩������
        //�Q�^�[�����ɗN���悤�ɂ��Ă��̃^�[���ŗN���v�f�����߂ēI�Ȃ̂�������̂����������炠����x�͌`�ɂȂ�
        if (nowtrun % 2 == 0)//�Ȃ��������ł���trunSystem.truncount
        {
            Debug.Log("�N���G�C�g�G�l�~�[");
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
                    groundEnemyActions.Add(enemy.GetComponent<GroundEnemyAction>());
                }
                enemynumber.Add(enemy.gameObject);//�G�����X�g�̒��ɒǉ�������́@�ǉ��o�������]�ݓ���gameObject��������������Ă�������
                                                  //���ׂĂ̓G���Ǘ����邽�߂ɍ�������ǎ��񂾂�^�[���V�X�e���ɒ��ڃA�N�Z�X���Đ�������΂����C������
                                                  //enemyscount++;//�G�̐��̃J�E���g�𑝂₷
                                                  //�l���Ƃ��Ă�gameObject�̕ϐ�������ăG�l�~�[�𐶐��������ɂ����ɓ���Ă��̕ϐ������X�g�ɒǉ�
                                                  //���̍ۗv�f���Œǉ�����Ƃ��̗v�f�����邩��v�f�̒��g������ǉ�����悤�ɂ���@�ϐ���.gameObject�ōs����Ǝv�������̂܂܂ł����v����
                                                  //enemyscount++;//�G����鎞��enemyscount�̐��l�𑝂₷

                /*if (pattern.time <= time)//time�̎��Ԃ��g�����Ǎ���͎g��Ȃ�����^�[�����ɂȂ邩��
                {

                }*/
            }
            //waves[wave].patterns.RemoveAll(pattern => pattern.time <= time);//�Ăяo�������̂��N���X�⃊�X�g�������
            waves[wave].patterns = waves[wave].patterns;
            wave++;
            TrunEnd();

        }
        else
        {
            TrunEnd();
        }

    }


    public void Enemysmove()//�G�̍s���n�߂ɂ��ā@���X�g���̃I�u�W�F�N�g�̍s�����J�n
    {
        //�ЂƂ܂��n��Ƌ󒆂ŗN����\�肾���ǈꏏ�ł���������
        if (enemynumber.Count > nowenemys)
        {
            groundaction = enemynumber[nowenemys].GetComponent<GroundEnemyAction>();
            if (groundaction != null)
            {
                //groundaction.raytrue = true;
                groundaction.Action();
                Debug.Log("g�G�l�~�[�A�N�V����");
            }
            //var enemy = enemynumber[nowenemys].GetComponent<EnemyController>();
        }
        else
        {
            //eSpawn.CreateEnemy();
            CreateEnemy();
        }
        
        
    }
    public void Nextenemys()//�G�̍s���I���ɌĂяo��
    {
        Enemysmove();
    }
}
