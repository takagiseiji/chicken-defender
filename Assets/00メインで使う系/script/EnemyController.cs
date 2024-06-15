using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{//どこが完成したかメモ 移動、拠点攻撃 明日やること　移動系をGroundの方に映す　敵がちゃんと鶏を攻撃するかの確認
    public int hp;
    public float speed=1;
    //bool movetrue = false;
    public Route route;//routeを入れる変数
    public int pointIndex;//どのPointから移動中なのかを示すメンバ変数
    public EnemyManager enemyManager;
    public GameObject target;
    int attackcount = 0;
    public bool movetrue = false;
    bool nextposition = false;
    public Vector3 beforeposition;
    Rigidbody rb;
    bool farst = true;
    
    //敵を倒した際何もないのはよくない気もする　アークナイツが倒したら増えてるか分からないけどスキルで増やせて敵を倒すとスキルのポイントがたまる
    //このように敵を倒したときの恩恵を考える必要があるかもしれない
    //案1素材を落とす　確定　特殊固体については検討中　一定ターンでおけるようにする
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
        //進行歩行を向いて進む為のコルーチンを呼び出す
        //StartCoroutine(Waittime());
    }
    void Farststart()//生成された時だけ実行
    {
        //Debug.Log("移動前");
        //transform.position = route.points[0].transform.position;
    }
    public void AAA()
    {
        GroundEnemyAction groundEnemyAction = GetComponent<GroundEnemyAction>();
        //StartCoroutine(groundEnemyAction.Action());//非アクティブだみたいなこと言われる
        //StartCoroutine(Waittime());
    }

    // Update is called once per frame
    void Update()
    {
        
        /*Vector3 rayposition = transform.position;
        rayposition.y += 0.1f;
        Ray ray = new Ray(rayposition, transform.forward);
        Debug.DrawRay(rayposition, transform.forward, Color.red);*/
        //移動は関数でやろうとしたけどそうすると一瞬で移動するものになってしまう
        //正面にずっと動くことが出来るのであればそれに値を入れて決まった距離か時間移動したら止まるとかできるけど
        //これはupdateでも出来る
        //関数内でやる場合はずっと繰り返すようにしてそこにif文入れて条件揃ったらbreakを考えたけどそれならupdateだけでいい気もする
        //一様updateで動くようにする

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
    //ボタンで呼び出そうとしたけど無理だった　もしかしたら別スクリプトから呼べない可能性もある
    //現在はAAAをボタンで呼んでそこから実行しているけど　もし別スクリプトから呼べなければ中身をactionにして別関数から呼ぶことになる
    public IEnumerator Waittime()
    {
        yield return new WaitForSeconds(1f);//これを入れないと向くのが先になってしまう　もし始めしか使わないならここにまとめたい
        Look();
        //transform.LookAt(route.points[pointIndex + 1].transform.position);
        Debug.Log("スタート");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("きゅうけい終了");
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
            Debug.Log("始め行動終了");
        }
        else
        {
            Actionendend();
        }
        Look();
    }
    //沸いたらすぐ動くことで動かなくなるからコールチンを使う
    //ポイントに付いた次の行動のときに回転しかしなかったりx軸の移動のところで少ししか動かなくなったりする理由は分からない
    //ダメだったのでActionの砲をコールチンにして時間おいてから実行にする方法検討中　こちらでは別関数でMoveを呼び出すことで代用
    public void Move()
    {
        //たまに向くだけだったり一マス以下しか進まないことがある
        
        Debug.Log("行動開始");
        beforeposition = transform.position;
        movetrue = true;
        //if (nextposition == true)//nextpositionがtrueだったら実行
        //{
        //    pointIndex++;//目的地に付いたら回転した　うまく入ってないかも　同じ座標になったらの方がいいかも
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
    void OnTriggerEnter(Collider collider)//鶏小屋の判定
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
//Invoke("Moveend", 1f);//移動終了の関数を作って一定時間たったら呼び出すが簡単かも
/*var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
//次の目的地と前の目的地の距離を計算し値を代入 次のポイントに付いたか確認
transform.LookAt(route.points[pointIndex + 1].transform);//次の目標を向く
transform.position += v.normalized * speed * Time.deltaTime;//移動系 normalizedは移動速度の一定化のために使用

var pv = transform.position - route.points[pointIndex].transform.position;//前のポイントから今いる位置の距離
if (pv.magnitude >= v.magnitude)//pvがv以上なら実行 目的地に着く、通り過ぎると実行　平方根使うから計算コスト高め
{//ここはそのまま使うと思う　しかし次の目的地と同じ座標になるまで正面に移動させて同じになったら次の目的地に移動でいいとおもう
    pointIndex++;
}*/
/*//ターンで動きたいから別関数で再定義する
//移動はターンでやるから毎回決まった分だけ正面に移動するようにすればいい
var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
//次の目的地と前の目的地の距離を計算し値を代入 次のポイントに付いたか確認
transform.LookAt(route.points[pointIndex + 1].transform);//次の目標を向く
transform.position += v.normalized * speed * Time.deltaTime;//移動系 normalizedは移動速度の一定化のために使用

var pv = transform.position - route.points[pointIndex].transform.position;//前のポイントから今いる位置の距離
if (pv.magnitude >= v.magnitude)//pvがv以上なら実行 目的地に着く、通り過ぎると実行　平方根使うから計算コスト高め
{//ここはそのまま使うと思う　しかし次の目的地と同じ座標になるまで正面に移動させて同じになったら次の目的地に移動でいいとおもう
    pointIndex++;
    if (pointIndex >= route.points.Length - 1)
    {
        //Destroy(gameObject);
        //enemyManager.enemynumber.Remove(gameObject);//一様書いているけどもしかしたらここは無くてもちゃんとリストから消えるかも
        //enemyManager.enemyscount--;//エネミーカウントの数を減らす
        //小屋にダメージ
    }
}*/
//var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
//次の目的地と前の目的地の距離を計算し値を代入 次のポイントに付いたか確認 この下二個は移動系だからここじゃないかも
//transform.LookAt(route.points[pointIndex + 1].transform);//次の目標を向く
//transform.position += v.normalized * speed * Time.deltaTime;//移動系 normalizedは移動速度の一定化のために使用

//var pv = transform.position - route.points[pointIndex].transform.position;//前のポイントから今いる位置の距離
/*transform.LookAt(route.points[pointIndex].transform);
float beforeposition = transform.forward.magnitude;
for (; ; )//無限ループのせいで実行することが出来なくなるかも　実際これをメモ化すると動くようになる
//エラー以前に動かないから正確には分からない
//動くことの方が重要だからupdateで動かす コールチンを使えば出来そうだけどupdateの方が簡単に出来るから完成するまではupdateのまま行こうかな
//理想というかわがまま詰め込んだ感じ
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
