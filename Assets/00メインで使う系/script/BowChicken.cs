using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowChicken : MonoBehaviour
{
    //���悾��projectiletower
    public Range range;
    float a = 0f;
    Transform mytransform;//������g�����ƂɂȂ����@�ʂ���Q�Ƃ���ꍇ���O�ς���
    public GameObject arrow;
    public Transform firepoint;
    public float timeBetweenShots = 1f;//����Ɖ��͎g��Ȃ��@���̂��߂�����g������������
    public float shotCounter;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        mytransform = GetComponent<Transform>();
        range = GetComponent<Range>();
        //loock();//�������ǂ����m�F�p
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);//����͊m�����Ԃ��Â�Ă���̂��m�F���Ă���
        shotCounter -= Time.deltaTime;//shotCounter��O���Update����̌o�ߎ��ԕ����� Time.deltaTime�̂��������������ɂ���
        if (shotCounter <= 0 && target != null)//shotCounter��0����target�����݂���Ύ��s
        {
            shotCounter = timeBetweenShots;//���̔��˂܂ł̎��ԃ��Z�b�g�@1�b
            //mytransform.rotation = Quaternion.LookRotation(target.position - mytransform.position);//Quaternion���g�p�����ꍇ�̌���
            //mytransform.rotation=Quaternion.Euler(0f,)
            //VEctor�ł���ς���s����@Quaternion�̕׋����Ă���g���@��Ȃ񂩂����apdate�Ƃ��̂����ƍs������̂Ŏg������
            //����Ń^�[�Q�b�g�̕������������_��������LoocAt���Ƃ����������������ɂȂ�
            //�݂�����ł͂���ɂ����slap���g�����̂ɕύX���Ă������x���ׂ�
            //(��̍�����ʒu�ƖڕW�̈ʒu�̊Ԃ�1�t���[��(Update)���ƂɈړ����Ɠǂ݂Ƃ���)(���񂾂�x���Ȃ�)
            //���낢�돑���Ă���R�s�y���������ǒ�������Ȃ��Ł@�^���[�f�B�t�F���X�̃Z�N�V����6��23.Turning The Cannon�ɏ����Ă���
            //�^�[�Q�b�g�̈ʒu������������シ����Ǝ΂ߌ����ɂȂ邩�炻��𒼂��R�[�h�������Ă������ǃ^�[�����������������΂߉��A��𒼂�
            //�����x���𒼂�
            this.gameObject.transform.LookAt(target);//�^�[�Q�b�g�̕����Ɍ���
            Vector3 angle = mytransform.eulerAngles;
            angle.x = 0f; angle.z = 0f;
            mytransform.eulerAngles = angle;
            //�ЂƂ܂�����ł����������������ꍇ�͂ЂƂ܂����ނ̂��̂ɂ��邩����l��ϐ��ɓ����1Vecter3�錾���ϐ��ɓ���Ă����x�̒l��ς���
            //�ēx��������������  �����������玸�s���������蒼����������������ĂȂ������@Quaternion�̕׋��㌈�߂邻��܂œ��擹���ɂ���
            //�������擹�����Ɠ����Ȃ��ꍇ�ς���@�m�F���@�̓X�^�[�g�ň�x���������֐������s����
            //Vector3 angle=
            firepoint.LookAt(target);//���C�ʒu���^�[�Q�b�g�̕����������@�O�̂��߂ɏ����Ă���

            //Instantiate�̓I�u�W�F�N�g�𐶐�����֐�
            Instantiate(arrow, firepoint.position, firepoint.rotation);//�������̒��̒l�ɃI�u�W�F�N�g�𐶐�
            //�߂����邩�炷�������Ă��Č����Ȃ�����������������Ȃ����ǌ����Ȃ�������������������琶�����o���Ă��Ȃ���������Ȃ�
        }
        if (range.enemiesInRange.Count > 0)//�G�l�~�[���Ǘ�����z�񂪋󂶂�Ȃ���Ύ��s
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
