using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{//�ǂ����������������� �ړ��A���_�U�� ������邱�Ɓ@�ړ��n��Ground�̕��ɉf���@�G�������ƌ{���U�����邩�̊m�F
    public int hp;
    public float speed=1;
    //bool movetrue = false;
    public Route route;//route������ϐ�
    public int pointIndex;//�ǂ�Point����ړ����Ȃ̂������������o�ϐ�
    public EnemyManager enemyManager;
    public GameObject target;
    int attackcount = 0;
    public bool movetrue = false;
    bool nextposition = false;
    public Vector3 beforeposition;
    Rigidbody rb;
    bool farst = true;
    
    //�G��|�����ۉ����Ȃ��̂͂悭�Ȃ��C������@�A�[�N�i�C�c���|�����瑝���Ă邩������Ȃ����ǃX�L���ő��₹�ēG��|���ƃX�L���̃|�C���g�����܂�
    //���̂悤�ɓG��|�����Ƃ��̉��b���l����K�v�����邩������Ȃ�
    //��1�f�ނ𗎂Ƃ��@�m��@����ő̂ɂ��Ă͌������@���^�[���ł�����悤�ɂ���
    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        //enemyManager = enemymaneger.GetComponent<EnemyManager>();
        transform.position = route.points[0].transform.position;
        Look();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        //Invoke("Farststart", 0.01f);
        farst = true;
        Move();
        //�i�s���s�������Đi�ވׂ̃R���[�`�����Ăяo��
        //StartCoroutine(Waittime());
    }
    void Farststart()//�������ꂽ���������s
    {
        //Debug.Log("�ړ��O");
        //transform.position = route.points[0].transform.position;
    }
    public void AAA()
    {
        GroundEnemyAction groundEnemyAction = GetComponent<GroundEnemyAction>();
        //StartCoroutine(groundEnemyAction.Action());//��A�N�e�B�u���݂����Ȃ��ƌ�����
        //StartCoroutine(Waittime());
    }

    // Update is called once per frame
    void Update()
    {
        
        /*Vector3 rayposition = transform.position;
        rayposition.y += 0.1f;
        Ray ray = new Ray(rayposition, transform.forward);
        Debug.DrawRay(rayposition, transform.forward, Color.red);*/
        //�ړ��͊֐��ł�낤�Ƃ������ǂ�������ƈ�u�ňړ�������̂ɂȂ��Ă��܂�
        //���ʂɂ����Ɠ������Ƃ��o����̂ł���΂���ɒl�����Č��܂������������Ԉړ�������~�܂�Ƃ��ł��邯��
        //�����update�ł��o����
        //�֐����ł��ꍇ�͂����ƌJ��Ԃ��悤�ɂ��Ă�����if������ď�����������break���l�������ǂ���Ȃ�update�����ł����C������
        //��lupdate�œ����悤�ɂ���

        if (movetrue == true)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            if (beforeposition.x + 1 <= transform.position.x )
            {
                beforeposition.x = (int)(transform.position.x-1);
                Moveend();
            }
            else if(beforeposition.x - 1 >= transform.position.x)
            {
                beforeposition.x = (int)(transform.position.x+1);
                Moveend();
            }
            else if (beforeposition.z + 1 <= transform.position.z)
            {
                beforeposition.z = (int)(transform.position.z-1);
                Moveend();
            }
            else if (beforeposition.z - 1 >= transform.position.z)
            {
                beforeposition.z = (int)(transform.position.z+1);
                Moveend();
            }
            
            
        }
    }
    //�{�^���ŌĂяo�����Ƃ������ǖ����������@������������ʃX�N���v�g����ĂׂȂ��\��������
    //���݂�AAA���{�^���ŌĂ�ł���������s���Ă��邯�ǁ@�����ʃX�N���v�g����ĂׂȂ���Β��g��action�ɂ��ĕʊ֐�����ĂԂ��ƂɂȂ�
    public IEnumerator Waittime()
    {
        yield return new WaitForSeconds(1f);//��������Ȃ��ƌ����̂���ɂȂ��Ă��܂��@�����n�߂����g��Ȃ��Ȃ炱���ɂ܂Ƃ߂���
        Look();
        //transform.LookAt(route.points[pointIndex + 1].transform.position);
        Debug.Log("�X�^�[�g");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("���イ�����I��");
        Move();
        
    }

    public void Look()
    {
        transform.LookAt(route.points[pointIndex + 1].transform.position);
        //Debug.Log("look");
    }

    void Moveend()
    {
        movetrue = false;
        transform.position = beforeposition;
        if (farst == true)
        {
            farst = false;
            Debug.Log("�n�ߍs���I��");
        }
        else
        {
            Actionendend();
        }
        Look();
    }
    //�������炷���������Ƃœ����Ȃ��Ȃ邩��R�[���`�����g��
    //�|�C���g�ɕt�������̍s���̂Ƃ��ɉ�]�������Ȃ�������x���̈ړ��̂Ƃ���ŏ������������Ȃ��Ȃ����肷�闝�R�͕�����Ȃ�
    //�_���������̂�Action�̖C���R�[���`���ɂ��Ď��Ԃ����Ă�����s�ɂ�����@�������@������ł͕ʊ֐���Move���Ăяo�����Ƃő�p
    public void Move()
    {
        //���܂Ɍ����������������}�X�ȉ������i�܂Ȃ����Ƃ�����
        
        Debug.Log("�s���J�n");
        beforeposition = transform.position;
        movetrue = true;
        //if (nextposition == true)//nextposition��true����������s
        //{
        //    pointIndex++;//�ړI�n�ɕt�������]�����@���܂������ĂȂ������@�������W�ɂȂ�����̕�����������
        //}
        
    }
    
    public void Damage()
    {
        hp--;
        if (hp == 0)
        {
            enemyManager.EnemyDead();
            Destroy(gameObject);
            //Moveend();
        }

    }
    public void Houseattack()
    {
        Destroy(gameObject);
        Actionendend();
    }
    void OnTriggerEnter(Collider collider)//�{�����̔���
    {
        if (collider.CompareTag("Finish"))
        {
            Houseattack();
        }
        if (collider.CompareTag("points"))
        {
            pointIndex++;
        }
    }
    public void Actionendend()
    {
        enemyManager.Nextenemys();
    }
}
//Invoke("Moveend", 1f);//�ړ��I���̊֐�������Ĉ�莞�Ԃ�������Ăяo�����ȒP����
/*var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
//���̖ړI�n�ƑO�̖ړI�n�̋������v�Z���l���� ���̃|�C���g�ɕt�������m�F
transform.LookAt(route.points[pointIndex + 1].transform);//���̖ڕW������
transform.position += v.normalized * speed * Time.deltaTime;//�ړ��n normalized�͈ړ����x�̈�艻�̂��߂Ɏg�p

var pv = transform.position - route.points[pointIndex].transform.position;//�O�̃|�C���g���獡����ʒu�̋���
if (pv.magnitude >= v.magnitude)//pv��v�ȏ�Ȃ���s �ړI�n�ɒ����A�ʂ�߂���Ǝ��s�@�������g������v�Z�R�X�g����
{//�����͂��̂܂܎g���Ǝv���@���������̖ړI�n�Ɠ������W�ɂȂ�܂Ő��ʂɈړ������ē����ɂȂ����玟�̖ړI�n�Ɉړ��ł����Ƃ�����
    pointIndex++;
}*/
/*//�^�[���œ�����������ʊ֐��ōĒ�`����
//�ړ��̓^�[���ł�邩�疈�񌈂܂������������ʂɈړ�����悤�ɂ���΂���
var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
//���̖ړI�n�ƑO�̖ړI�n�̋������v�Z���l���� ���̃|�C���g�ɕt�������m�F
transform.LookAt(route.points[pointIndex + 1].transform);//���̖ڕW������
transform.position += v.normalized * speed * Time.deltaTime;//�ړ��n normalized�͈ړ����x�̈�艻�̂��߂Ɏg�p

var pv = transform.position - route.points[pointIndex].transform.position;//�O�̃|�C���g���獡����ʒu�̋���
if (pv.magnitude >= v.magnitude)//pv��v�ȏ�Ȃ���s �ړI�n�ɒ����A�ʂ�߂���Ǝ��s�@�������g������v�Z�R�X�g����
{//�����͂��̂܂܎g���Ǝv���@���������̖ړI�n�Ɠ������W�ɂȂ�܂Ő��ʂɈړ������ē����ɂȂ����玟�̖ړI�n�Ɉړ��ł����Ƃ�����
    pointIndex++;
    if (pointIndex >= route.points.Length - 1)
    {
        //Destroy(gameObject);
        //enemyManager.enemynumber.Remove(gameObject);//��l�����Ă��邯�ǂ����������炱���͖����Ă������ƃ��X�g��������邩��
        //enemyManager.enemyscount--;//�G�l�~�[�J�E���g�̐������炷
        //�����Ƀ_���[�W
    }
}*/
//var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
//���̖ړI�n�ƑO�̖ړI�n�̋������v�Z���l���� ���̃|�C���g�ɕt�������m�F ���̉���͈ړ��n�����炱������Ȃ�����
//transform.LookAt(route.points[pointIndex + 1].transform);//���̖ڕW������
//transform.position += v.normalized * speed * Time.deltaTime;//�ړ��n normalized�͈ړ����x�̈�艻�̂��߂Ɏg�p

//var pv = transform.position - route.points[pointIndex].transform.position;//�O�̃|�C���g���獡����ʒu�̋���
/*transform.LookAt(route.points[pointIndex].transform);
float beforeposition = transform.forward.magnitude;
for (; ; )//�������[�v�̂����Ŏ��s���邱�Ƃ��o���Ȃ��Ȃ邩���@���ۂ��������������Ɠ����悤�ɂȂ�
//�G���[�ȑO�ɓ����Ȃ����琳�m�ɂ͕�����Ȃ�
//�������Ƃ̕����d�v������update�œ����� �R�[���`�����g���Ώo������������update�̕����ȒP�ɏo���邩�犮������܂ł�update�̂܂܍s��������
//���z�Ƃ������킪�܂܋l�ߍ��񂾊���
{
    transform.position += transform.forward * Time.deltaTime * speed;

    if (beforeposition + 1 == transform.forward.magnitude)
    {
        break;
    }

}
if (route.points[pointIndex].transform.position == transform.position)
{
        pointIndex++;
}
Moveend();*/
