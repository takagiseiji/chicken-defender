using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    TrunSystem trunSystem;
    //�{�����̗̑�
    int chickenhouse = 5;
    //2�^�[���ŗN���ꍇ�̐�������ϐ�
    int eggtrun;
    //���A�Ђ悱�A�{�̐� �n�߂ɓ���鐔�͏����̗��̐�
    public int egg = 0;
    public int chick = 0;
    public int chicken = 0;
    int beforechick = 0;
    int beforeegg = 0;

    //�����̐�
    public int bow2 = 0;
    public int bow3 = 0;
    public int sword2 = 0;
    public int sword3 = 0;
    //�f�ނ��Ǘ����鐔�l��p�ӂ���@��������̂͂悭�Ȃ����炱�ꂮ�炢����
    //�f�ނ̎��W�͂��̃^�[�����I������������̃^�[���J�n�ɓ��肷�邪�ǂ̂悤�ɂ�����s����
    //�h����������ۊǂ���֐��������Ă������������_�����s���@���͏ꏊ
    //�{�̑��₵���̕��@�őf�ގ��W����a����肵�ĂƂ����l�������ǂ���͎n�߂̌{�̐��Ƃ����낢�뒲���������Ȃ��ƍs���Ȃ�����
    //�ЂƂ܂��Ȃ��ōs��
    //�f��
    public int wood = 0;//�|�̕K�{�f��
    public int iron = 0;//���ƃN���X�{�E�ɕK�p
    public int leather = 0;//��ڂ̋|�ƌ�
    public int gold = 0;//�Ō�̌��̑f��
    public int rope = 0;//�|�̕K�p�f��
    //�ꏊ ���̂Ƃ���񂩏������ǒǉ�����Ȃ炠�ƈꂩ���@���̏ꏊ�œ�͑f�ނ��Ƃ��̂�����
    public int forest = 0;
    public int mine = 0;
    public int silverax;
    public int goldax;
    public int silverpickaxe;
    public int goldpickaxe;
    //�o�Ă���{�����X�g�ŊǗ�����@���_����߂����Ƀ��X�g����ׂĎ��s�\��@�ǂ�����ċ߂����ɂ���̂�������Ȃ�
    //������3D�^���[�f�B�t�F���X�̋��ނ̓���ɓ��ɋ߂����̂��U��������̂�����������Q�l�ɏo����Ǝv��
    //���Ƌ|�ŕ����Ă��Č�������\��@�������S�č��킹�ċ��_����߂����ɂ���̂����肩��
    // Start is called before the first frame update
    void Start()
    {
        trunSystem = GetComponent<TrunSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TrunStart()//�^�[���͂���
    {//���񂽂܂��𑝂₵�Ă��邪�����ʌő�(����r�Ȃ�)���o���悤�ɂ����ꍇ���܂̃X�e�[�W�͈̔͂ł͋�������
        //���̂��ߍŏ����猈�܂����������o����悤�ɂ���̂�����ȋC�����邯�ǂ���͓��
        //���̏ꍇ�͐������Ȃ����邵���Ȃ������@�Ƃ������R�X�g�֌W���Ⴄ���̂ɂ����������������@�ׂ��������܂�ȋC�͂���
        //�ЂƂ܂��͌{�����̂܂܂ł���
        Debug.Log("���X�^�[�g");
        egg += 4;
        chick = beforeegg;
        chicken += beforechick;
        beforeegg = egg;
        beforechick = chick;
        eggtrun++;
        //����̌v�Z���ǂ����邩�������@���^�[��������������@�Q�^�[���Ɉ��Ƃ����ɂ������鐔������
        //������ڈ���2,3���� �h�������邩�疈�^�[�����������������Ǝv���@��̈��h���o���邩�ǂ������炢�������̂���
        //����Ȃ��Ɣh�����Ȃ��ꍇ�������邱�ƂɂȂ邩���@���������ꂾ�Ɠr���Ŕh�����Ԃɍ���Ȃ��ċ����o���Ȃ��Ƃ����邩��
        //�����ǎn�߂̏P���܂Ŏ��Ԃ��邩�炻��܂łɑ��₷���Ƃ��o����΂������ǂ��Ċ���
        //���̂��߈��̃^�[�����������瑽�߂ɗ��Ⴆ��Ƃ�(5�^�[���Ɉ��Ƃ�)�V��ł����Ȃ��ƕ�����Ȃ������U�������
        if (eggtrun == 5)//���^�[����������ǉ��ŖႦ��
        {
            egg +=2;
            eggtrun = 0;
        }
        //Debug.Log("�X�^�[�g");
        //Getmaterial();//�ЂƂ܂��f�ނ̓���̓^�[���J�n���Ɏ��s
        //�����̍Ō�ɗ��ƂЂ悱�̐�������
        //TrunEnd();
    }
    public void TrunEnd()//�^�[���I���
    {
        trunSystem.Ptrunend();
        //�����Ń^�[���Ǘ��̎����̃^�[�����I��������Ƃ�\�����̂��o��
    }
    public void Housedamege()
    {
        chickenhouse--;
        if (chickenhouse == 0)
        {
            trunSystem.GameOver();
        }
    }
    public void Getmaterial()//���f����邩�m�F�̂��߂ɂ�������s����{�^�������@�����o���������
    {//�f�ރ����_�������ǉ^�v�f�ɂȂ��Ă��܂�����Œ�ɂ��邩������
        //�����_���̏ꍇ�ǂꂮ�炢�ɂ��邩�����@�ő�l�͍Œ�ł�3�ȏ�@�Œ�Ȃ�Q�@6�͑������邩��
        for(int i = 0; i < forest; i++)
        {
            int material = Random.Range(0, 4);
            wood += material;
            //material = Random.Range(0, 4);
            //leather += material;//�G���痎����悤�ɂ��Ĕh���ł͂Ƃ�Ȃ����邩��
            material = Random.Range(0, 4);
            rope += material;
        }
        for(int i = 0; i < mine; i++)
        {
            int material = Random.Range(0, 6);
            iron += material;
            int r = Random.Range(0, 2);//��������m����50%�͍����C������@�R����1���炢�ł����C������
            if (r == 1)
            {
                material = Random.Range(1, 4);
                gold += material;
            }
        }
        forest = 0;
        mine = 0;
    }
}
