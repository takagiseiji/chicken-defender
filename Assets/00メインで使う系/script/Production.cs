using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : MonoBehaviour
{
    //���Y
    //�f�ނɊւ�����̂��o������if���Ŋm�F����
    public PlayerManager playerManager;
    public GameObject nomatelial;
    bool nomatelialtrue=false;
    float nomatelialtime = 1;
    // Start is called before the first frame update
    void Start()
    {
        //playerManager = GetComponent<PlayerManager>();
        nomatelial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (nomatelialtrue == true)
        {
            
            nomatelial.SetActive(true);
            nomatelialtime -= Time.deltaTime;
            if (nomatelialtime <= 0)
            {
                nomatelial.SetActive(false);
            }
        }
    }
    //�S�̓I�ɋ|�̐��Y�������y�ɂȂ��Ă���@�o����Ȃ瓯�����炢�ɂ��������������g�����g��Ȃ������ł���
    //�ň��������Ȃ��ƃN���A�o���Ȃ��悤�ɂ���̂�����
    public void Bow2()
    {
        if (playerManager.wood >= 1 && playerManager.rope >= 1 && playerManager.leather >= 1)
        {
            playerManager.bow2++;//�����Ȃ�����������������++�������Ȃ���������Ȃ�
            //�f�ނ̃}�C�i�X������
            playerManager.wood--;//�Q�ł���������
            playerManager.rope--;//2�ł���������
            playerManager.leather--;//�����|��t���邾���Ȃ�v��Ȃ�����P�ł���������
        }
        else
        {
            nomatelialtime = 1;
            nomatelialtrue = true;
        }


    }
    public void Bow3()
    {
        if (playerManager.wood >= 1 && playerManager.rope >= 1 && playerManager.iron >= 1)
        {
            playerManager.bow3++;
            playerManager.wood-=2;//�m��
            playerManager.rope--;//�Q�ł���������
            playerManager.gold--;//�K�v�f�ނ̗ʂ𑝂₷���������������ăR�X�g������ׂ� ��U�S����Ȃ��ċ��Ƃ����ݒ�ɂ���@�R�X�g������
        }
        else
        {
            nomatelialtime = 1;
            nomatelialtrue = true;
        }
    }
    public void Sword2()
    {
        if (playerManager.wood >= 1 && playerManager.rope >= 1 && playerManager.iron >= 1)
        {
            playerManager.sword2++;
            playerManager.wood--;
            playerManager.rope--;
            playerManager.iron--;
        }
        else
        {
            nomatelialtime = 1;
            nomatelialtrue = true;
        }

    }
    public void Sword3()
    {
        if (playerManager.wood >= 1 && playerManager.gold >= 1 && playerManager.iron >= 1)
        {
            playerManager.sword3++;
            playerManager.wood--;//�m��
            playerManager.gold--;//�m��
            playerManager.iron-=2;//��ł����������R�ȏ�͑�������
        }
        else
        {
            nomatelialtime = 1;
            nomatelialtrue = true;
        }

    }
}
