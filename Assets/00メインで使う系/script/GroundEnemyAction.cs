using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyAction : MonoBehaviour
{

    bool movetrue = false;
    Vector3 beforeposition;
    public Vector3 rayposition;
    public GameObject target;
    public GameObject aaa;
    public EnemyController enemyController;
    public Route route;
    public int pointIndex=0;
    public int attackcount;
    public bool raytrue = false;
    public float raylength = 1f;
    //bool look = false;

    Ray ray;
    RaycastHit hit = new RaycastHit();
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        //AfterStart();
        //enemyController.Start();
        aaa.SetActive(false);
        //beforeposition.x = beforeposition.y=beforeposition.z=0;
    }
    public void Test()
    {
        //StartCoroutine(Action());
    }

    public void AfterStart()
    {
        
    }

    //public void Look()
    //{
    //    transform.LookAt(enemyController.route.points[enemyController.pointIndex + 1].transform.position);
    //    //transform.LookAt(route.points[pointIndex + 1].transform.position);
    //    Debug.Log("look");
    //    aaa.SetActive(true);
    //    //StartCoroutine(Action());
    //}
    public void Action()
    {
        Debug.Log("action");
        //raytrue = true;
        rayposition = transform.position;
        rayposition.y = 0.25f;
        ray = new Ray(rayposition, transform.forward);
        //Debug.DrawRay(transform.position, transform.forward, Color.red, raylength);
        if (Physics.Raycast(ray, out hit,1))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.CompareTag("chicken"))
            {
                Debug.Log("����");
                target = hit.collider.gameObject;
                Attack();
            }
            else
            {
                Debug.Log("�ړ�1");
                enemyController.Move();
            }
        }
        else
        {
            Debug.Log("�ړ�2");
            enemyController.Move();
        }
        /*Vector3 a = transform.position;
        a.y += 1;
        transform.position = a;*/
        Debug.Log("�A�N�V�����I��");
    }

    
    // Update is called once per frame
    void Update()
    {

        //if (raytrue == true)
        //{//ray����u�ŏ��������瓮���Ȃ��Ǝv���ėp�ӂ������ǂǂ��ɂ��o������v��Ȃ��Ȃ�
        //    rayposition = transform.position;
        //    rayposition.y += 0.25f;//ray�̈ʒu�������������炠���邽�߂Ɏg�p
        //    ray = new Ray(rayposition, transform.forward);
        //    Debug.DrawRay(rayposition, transform.forward, Color.red, raylength);//ray��������悤��
        //    if (Physics.Raycast(ray, out hit, raylength))
        //    {
        //        Debug.Log("Ray�����������I�u�W�F�N�g�̖��O: " + hit.collider.gameObject.name);
        //        if (hit.collider.CompareTag("chicken"))
        //        {//�ЂƂ܂����ꂾ����EnemyController��Attack�ǉ����Ă������ɂ��邩���v
        //            target = hit.collider.gameObject;
        //            Attack();
        //            //raytrue = false;
        //        }
        //        else
        //        {
        //            enemyController.Move();
        //            //raytrue = false;
        //            //movetrue = true;
        //        }
        //    }
        //}
        /*if (movetrue == true)
        {
            //Debug.Log("Gmove");
            transform.position += transform.forward * enemyController.speed * Time.deltaTime;
            if (beforeposition.x + 1 <= transform.position.x)
            {
                movetrue = false;
                beforeposition.x = (int)(transform.position.x - 1);
                transform.position = beforeposition;
            }
            else if (beforeposition.x - 1 >= transform.position.x)
            {
                movetrue = false;
                beforeposition.x = (int)(transform.position.x + 1);
                transform.position = beforeposition;
            }
            else if (beforeposition.z + 1 <= transform.position.z)
            {
                movetrue = false;
                beforeposition.z = (int)(transform.position.z - 1);
                transform.position = beforeposition;
            }
            else if (beforeposition.z - 1 >= transform.position.z)
            {
                movetrue = false;
                beforeposition.z = (int)(transform.position.z + 1);
                transform.position = beforeposition;
            }


        }*/
    }
    void OnTriggerEnter(Collider collider)//�{�����̔���
    {
        //if (collider.CompareTag("Finish"))
        //{
        //    Houseattack();
        //}
        /*if (collider.CompareTag("points"))
        {
            pointIndex++;
        }*/
    }
    public void Attack()
    {
        //�n��͐��ʂ����ɂ���\�肾��������̂͗v��Ȃ�����
        //transform.LookAt(target.transform);//�G�̕���������
        Debug.Log("�A�^�b�N");
        target.GetComponent<Chicken>().Damage();//�{�ւ̃_���[�W
        

    }
    //public void Move()
    //{
    //    //Debug.Log("�s���J�n");
    //    beforeposition = transform.position;
    //    movetrue = true;
    //    //if (nextposition == true)//nextposition��true����������s
    //    //{
    //    //    pointIndex++;//�ړI�n�ɕt�������]�����@���܂������ĂȂ������@�������W�ɂȂ�����̕�����������
    //    //}
    //}
    public void Actionend()
    {
        enemyController.Actionendend();
    }
}
//public IEnumerator Action()
//{

//    Debug.Log("�A�N�V����");
//    aaa.SetActive(true);
//    raytrue = true;
//    //rayposition = transform.position;
//    //rayposition.y += 0.25f;//��ray�̈ʒu�����������炠���邽�߂Ɏg�p
//    //ray = new Ray(rayposition, transform.forward);
//    //Debug.DrawRay(transform.position, transform.forward, Color.red);//ray��������悤��
//    ////��u�߂��Č�����Ă��Ȃ��\������@���̏ꍇ��Update�ł������N������
//    Debug.Log("ray�I��");
//    if (Physics.Raycast(ray, out hit))
//    {
//        if (!hit.collider.CompareTag("enemy"))
//        {
//            Debug.Log("Ray�����������I�u�W�F�N�g�̖��O: " + hit.collider.gameObject.name);
//            if (hit.collider.CompareTag("chicken"))
//            {
//                Debug.Log("����");
//                target = hit.collider.gameObject;
//                yield return new WaitForSeconds(1.0f);//�����o���邾��������Ȃ����炢�̎��Ԃɂ������@���ō��͂P�b�ɂ��Ă���
//                Attack();
//                //attackcount++;
//            }
//            else
//            {
//                Debug.Log("�ړ�");
//                //yield return new WaitForSeconds(1.0f);//�����o���邾��������Ȃ����炢�̎��Ԃɂ������@���ō��͂P�b�ɂ��Ă���
//                enemyController.Move();
//                attackcount = 0;
//            }
//        }

//    }
//    else
//    {
//        Debug.Log("�ړ�");
//        //yield return new WaitForSeconds(1.0f);//�����o���邾��������Ȃ����炢�̎��Ԃɂ������@���ō��͂P�b�ɂ��Ă���
//        enemyController.Move();
//        attackcount = 0;
//    }
//    Debug.Log("�A�N�V�����I��");
//    yield return new WaitForSeconds(1.0f);
//    raytrue = false;
//}