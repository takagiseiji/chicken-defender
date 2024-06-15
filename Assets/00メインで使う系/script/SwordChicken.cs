using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordChicken : MonoBehaviour
{
    //���s�����̏�Ԃ���000�Ɏn�܂����ォ���ĂɈړ�����@�Ȃ����킩��Ȃ�
    public Range range;
    public float timeBetweenShots = 1f;//����Ɖ��͎g��Ȃ��@���̂��߂�����g�������������@Update�ōU���Ǘ����Ɏg��
    public float shotCounter;
    Transform mytransform;
    Animator anim;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        mytransform = GetComponent<Transform>();
        range = GetComponent<Range>();
        anim = GetComponent<Animator>();//���������Ȃ���΃X�N���v�g���{�ɓ���邩�{��Animator���擾����
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0 && target != null)
        {
            shotCounter = timeBetweenShots;
            this.gameObject.transform.LookAt(target);
            anim.SetTrigger("Attack");//Attacktrigger���w�肷��Γ���
            Debug.Log("attack");
            target.GetComponent<EnemyController>().Damage();//�G�l�~�[�̃_���[�W�֐������s �����ɏ����Ă��邯�ǃA�j���[�V�������I������オ
            //�����ꍇ�ʊ֐��ŗp�ӂ��ăA�j���[�V�����̏I���ɓ����悤�ɂ���
            //�U���̍ۃW�����v��ړ�����̂͋|�ƈႢ���������������Update����O���Α��v���Ǝv���邩�珑�������Ȃ����_���������珑��������
            
        }
        if (range.enemiesInRange.Count > 0)
        {
            float minDistance = range.range + 1f;//��ԋ߂�������ۑ��@�˒����1�����l����
            foreach (EnemyController enemy in range.enemiesInRange)//�˒����̓G(EnemyController����)�����Ȃ��Ȃ�܂Ŏ��s
            {//��L��EnemyController enemy�����������Ƃɂ��enemy�Ŏg����悤�ɂȂ���
                if (enemy != null)//EnemyController�����݂���Ύ��s
                {
                    //���ɂ���G��D�悳����(���̂Ƃ����ɗN���G�̍��������ɂ���\�肾�����ԍ����̂ő��v)���̌㋗�������߂�
                    //�����������ꍇ�͋��������߂�@else if���g���@�n�߂�����
                    float distance = Vector3.Distance(transform.position, enemy.transform.position);//���g�ƓG�̋�������
                    if (distance < minDistance) //�������������minDistance��菬������Ύ��s
                    {
                        minDistance = distance;//minDistance�ɑ��(�㏑��)
                        target = enemy.transform;//target�̍��W����(�㏑��)

                    }
                }

            }
        }
        else
        {
            target = null;
        }
    }
    void loock()//������������p�֐�
    {

    }
}
