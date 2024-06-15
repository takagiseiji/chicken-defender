using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrunSystem : MonoBehaviour
{
    float truntime = 10f;
    bool playertrun = false;
    bool enemytrun = false;
    
    public GameObject trunobject;
    //public TextMeshProUGUI truntext;
    public int truncount = 0;//������1�ɂ��Ă���{�Ԃ�0�̗\��
    //���Ԃɓ��������@�͍ŏ��ɑS�ĕ����Ă���ꍇ�͂Ȃ�ƂȂ������邯��
    //����̓^�[���ŏ����Â킭���畦�������ƌő̂�ۑ����Ă��镦���̂Ɏg�����X�N���v�g���d�v����
    //�����̒��Ɉړ��x����������������Ȃ������ꂼ��̈ړ��p�̃X�N���v�g�������@��������Ȃ�
    PlayerManager playerManager;
    EnemyManager enemyManager;//�ЂƂ܂�����ŃG�l�~�[�̃^�[���Ǘ����邯�Ǖς�邩������Ȃ�
    //public Text enemyText;
    private void Start()
    {
        //�G�̃^�[������n�߂��ق����i�s���[�g��蕪����₷�����U�߂��Ă��銴�ł�Ǝv���@������񕦂�������
        playerManager = GetComponent<PlayerManager>();
        enemyManager = GetComponent<EnemyManager>();
        trunobject.SetActive(false);
        enemyManager.TrunStart();
    }
    //�^�[�����𐔂�����̒ǉ�
    //�^�[���I�����ǂ����邩�����Ă邯�ǐ����ǂ��炩���Ăяo�������ȋC������
    //���̂��ߑ��̂�����Ƃ�����������������
    //���Ǝn�߂ǂ����悤���������@Update�ɕb���������Ĉ�莞�Ԃ���������s�Ƃ�������
    //�R���[�`��������
    //�������͍ŏ�����v���C���[�̃^�[���Ŗ���^�[���\�������邩������
    //UI�\�L�̏ꍇ�ǂ����Ŏ��ԍ��Ȃ��Ƃ����Ȃ��@���̂Ƃ��낱����Update��if����bool�łǂ��炩���f���ăJ�E���g����̌�����
    public void Ptrunend()
    {
        Debug.Log("p�^�[����");
        enemytrun = true;
    }
    public void Etrunend()
    {
        Debug.Log("e�^�[����");
        playertrun = true;
    }
    private void Update()
    {
        if (playertrun == true)
        {
            truntime -= Time.deltaTime;
            //Debug.Log("p�X�^�[�g�O");
                //playerManager.TrunStart();
                
                //playertrun = false;
                //truncount++;
            if (truntime <= 0)
            {
                trunobject.SetActive(false);
                Debug.Log("p�X�^�[�g�O");
                playerManager.TrunStart();
                truntime = 10f;
                playertrun = false;
                truncount++;
            }
        }else if (enemytrun == true)
        {
            //enemyManager.TrunStart();
            truntime -= Time.deltaTime;
            if (truntime <= 0)
            {
                enemyManager.TrunStart();
                truntime = 10f;
                enemytrun = false;
            }
        }
    }
    public void GameOver()
    {
        //�Q�[���I�[�o�[�֘A�̂��̂�\������ ���Ԃ��~�߂�UI�\�� �|�����G�̐��Ǝc��̐���\��
    }
    public void GameClear()
    {
        Debug.Log("�N���A");
        //�Q�[���N���A�֘A�̂��̂�\������
    }
    float count = 1;
    public void Count()
    {
        trunobject.SetActive(true);
        //text�̕\����ύX����
        truntime = 3f;
        playertrun = true;
    }
}
