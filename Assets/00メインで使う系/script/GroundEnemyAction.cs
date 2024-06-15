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
                Debug.Log("発見");
                target = hit.collider.gameObject;
                Attack();
            }
            else
            {
                Debug.Log("移動1");
                enemyController.Move();
            }
        }
        else
        {
            Debug.Log("移動2");
            enemyController.Move();
        }
        /*Vector3 a = transform.position;
        a.y += 1;
        transform.position = a;*/
        Debug.Log("アクション終了");
    }

    
    // Update is called once per frame
    void Update()
    {

        //if (raytrue == true)
        //{//rayが一瞬で消えたから動かないと思って用意したけどどうにか出来たら要らなくなる
        //    rayposition = transform.position;
        //    rayposition.y += 0.25f;//rayの位置が下すぎたからあげるために使用
        //    ray = new Ray(rayposition, transform.forward);
        //    Debug.DrawRay(rayposition, transform.forward, Color.red, raylength);//rayが見えるように
        //    if (Physics.Raycast(ray, out hit, raylength))
        //    {
        //        Debug.Log("Rayが当たったオブジェクトの名前: " + hit.collider.gameObject.name);
        //        if (hit.collider.CompareTag("chicken"))
        //        {//ひとまずこれだけどEnemyControllerにAttack追加してそっちにするかも」
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
    void OnTriggerEnter(Collider collider)//鶏小屋の判定
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
        //地上は正面だけにする予定だから向くのは要らないかも
        //transform.LookAt(target.transform);//敵の方向を向く
        Debug.Log("アタック");
        target.GetComponent<Chicken>().Damage();//鶏へのダメージ
        

    }
    //public void Move()
    //{
    //    //Debug.Log("行動開始");
    //    beforeposition = transform.position;
    //    movetrue = true;
    //    //if (nextposition == true)//nextpositionがtrueだったら実行
    //    //{
    //    //    pointIndex++;//目的地に付いたら回転した　うまく入ってないかも　同じ座標になったらの方がいいかも
    //    //}
    //}
    public void Actionend()
    {
        enemyController.Actionendend();
    }
}
//public IEnumerator Action()
//{

//    Debug.Log("アクション");
//    aaa.SetActive(true);
//    raytrue = true;
//    //rayposition = transform.position;
//    //rayposition.y += 0.25f;//下rayの位置がすぎたからあげるために使用
//    //ray = new Ray(rayposition, transform.forward);
//    //Debug.DrawRay(transform.position, transform.forward, Color.red);//rayが見えるように
//    ////一瞬過ぎて見つけれていない可能性ある　その場合はUpdateですこし起動する
//    Debug.Log("ray終了");
//    if (Physics.Raycast(ray, out hit))
//    {
//        if (!hit.collider.CompareTag("enemy"))
//        {
//            Debug.Log("Rayが当たったオブジェクトの名前: " + hit.collider.gameObject.name);
//            if (hit.collider.CompareTag("chicken"))
//            {
//                Debug.Log("発見");
//                target = hit.collider.gameObject;
//                yield return new WaitForSeconds(1.0f);//ここ出来るだけ分からないぐらいの時間にしたい　仮で今は１秒にしている
//                Attack();
//                //attackcount++;
//            }
//            else
//            {
//                Debug.Log("移動");
//                //yield return new WaitForSeconds(1.0f);//ここ出来るだけ分からないぐらいの時間にしたい　仮で今は１秒にしている
//                enemyController.Move();
//                attackcount = 0;
//            }
//        }

//    }
//    else
//    {
//        Debug.Log("移動");
//        //yield return new WaitForSeconds(1.0f);//ここ出来るだけ分からないぐらいの時間にしたい　仮で今は１秒にしている
//        enemyController.Move();
//        attackcount = 0;
//    }
//    Debug.Log("アクション終了");
//    yield return new WaitForSeconds(1.0f);
//    raytrue = false;
//}