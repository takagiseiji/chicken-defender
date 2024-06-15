using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{//動画だとTower
    //攻撃距離系の物しか書いていないからこの名前だけど今後増える場合別の名前になる(たぶんArrowが付くだけだと思う)
    //攻撃判定をとるもの　範囲は全て0で武器ごとに距離を足すか　それぞれUnity上で値変える
    public float range = 1f;
    public float length = 1f;
    public float height = 3f;
    public float width = 1f;
    public Vector3 size;

    public LayerMask whatIsEnemy;
    public Collider[] colliderInRange;
    //EnemyControllerは敵のスクリプト名に置き換えるらしいがそのまま使おうかな
    public List<EnemyController> enemiesInRange = new List<EnemyController>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //これ等はターンが回ってきたら動く関数に移動される エネミートリガーにしたから少し変更しないといけないかも
        Quaternion q = transform.rotation;
        //colliderInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);
        colliderInRange = Physics.OverlapBox(transform.position, new Vector3(length, height, width), q, whatIsEnemy);
        enemiesInRange.Clear();//追加する前にすでに入っているものを無くす
        //ここから下もしっかりは覚えていないが自分なりの解釈を書く　今度復習
        foreach (Collider col in colliderInRange)//colliderInRangeの中身が空になるまで　別colliderに入れることで確認　入らなければ終了
        {
            enemiesInRange.Add(col.GetComponent<EnemyController>());//enemiesInRangeに取得した物を追加
                                                                    //Updateでやっているから実行毎にすべてクリアしてもう一度確認している
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size*2);
    }
}
