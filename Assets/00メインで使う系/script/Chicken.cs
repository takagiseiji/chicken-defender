using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    //�U���̌Ăяo�����ǂ����邩�������@�����֐��Ŗ��ߏo����Ƃ������ǋ|�ƌ��ōU���n�ς�邩�炻��͖����@�����ɏ����Ă����ŕ�����
    //����o�����o���Ȃ��������邩�瓯���͖������Ǝv���@���Ƌ|�Ń��X�g�����Č����|�̏��ԂōU������̂���
    //�̒l
    public int hp=5;//�ꔭ���񔭂œ|����邮�炢��HP�@�h��͖h��͂Ƃ��Čv�Z����\�肾����HP�����̕����₷�ł�����


    //����n���l
    public int level = 0;//���x�����m�F�������
    int[] power = new int[3]{1,2,3};//�U���͂̔z��
    int attack;
    //�A�Z�b�g����������悤�Ƃ��ăf�[�^�̑����������邩���I�Ȋ����ŃG���[�o�邩��
    //���X�g����߂Ă��ꂼ��ʂ̊֐��ŗp�ӂ���@�w�Z�n�܂����畷���Ă݂�
    //���Ȃ݂ɂ�������ł��_���Ȃ�v���n�u��蒼�����蓙�ׂ̍����Ƃ������Ă݂ďo���Ȃ���Εʂ���s��
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    //public GameObject[] weapons = new GameObject[3];//��������Ă����z��
    //public GameObject[] armors = new GameObject[3];//�h��Ƃ������̂����ꍇ�Ȃ�g��
    //int[] guard = { 1, 2, 3 };
    GameObject nowWeapon;//�O�̂��ߗp�ӂ����������Ă镐����m�F������́@������Destroy����Ƃ��ꎩ�̂������Ȃ����S�z �����ł͑��v������
    public Transform weaponpoint;//���킪�N���ʒu
    //��_���[�W
    public int takendamage;
    Vector3 weponrotation;//����̕���������ϐ�
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(weapons[0], weaponpoint);//�����̕���̌����͑��v�ɂȂ���
        nowWeapon = weapon2;
        Instantiate(nowWeapon,weaponpoint);
        attack = power[level];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void Weaponup()
    {//�v�������@�����������ǃ��X�g���̂��̂�����ł��Ȃ��炵���@�N���[�����������@������̂Ȃ炻������肾����
     //���x���_�E�������������Ȃ�����v�f�������ł���������
        //Destroy(weapons[level - 1].gameObject);
        //Instantiate(weapons[level].gameObject, weaponpoint);
        Destroy(nowWeapon);
        //nowWeapon.GetComponent<Weapons>().Change();
        nowWeapon = weapons[level].gameObject; Debug.Log("�`�F���W");
        Instantiate(nowWeapon,weaponpoint);Debug.Log("����");
        attack = power[level];
    }*/
    public void Weapon2()
    {
        DestroyImmediate(nowWeapon,true);
        nowWeapon = weapon2;
        Instantiate(nowWeapon, weaponpoint);
        attack = power[level];
    }
    public void Weapon3()
    {
        Destroy(nowWeapon.gameObject);
        nowWeapon = weapon3;
        Instantiate(nowWeapon, weaponpoint);
        attack = power[level];
    }
    public void Remove()
    {
        Destroy(gameObject);
    }
    public void Damage()
    {
        Debug.Log("�_���[�W");
        hp -= takendamage;
        if (hp <= 0) Destroy(gameObject);
    }
}
