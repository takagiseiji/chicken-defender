using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordChicken : MonoBehaviour
{
    //実行時今の状態だと000に始まった後かってに移動する　なぜかわからない
    public Range range;
    public float timeBetweenShots = 1f;//これと下は使わない　そのためこれを使った部分改造　Updateで攻撃管理時に使う
    public float shotCounter;
    Transform mytransform;
    Animator anim;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        mytransform = GetComponent<Transform>();
        range = GetComponent<Range>();
        anim = GetComponent<Animator>();//もし動かなければスクリプトを鶏に入れるか鶏のAnimatorを取得する
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0 && target != null)
        {
            shotCounter = timeBetweenShots;
            this.gameObject.transform.LookAt(target);
            anim.SetTrigger("Attack");//Attacktriggerを指定すれば動く
            Debug.Log("attack");
            target.GetComponent<EnemyController>().Damage();//エネミーのダメージ関数を実行 ここに書いているけどアニメーションが終わった後が
            //いい場合別関数で用意してアニメーションの終わりに動くようにする
            //攻撃の際ジャンプ後移動するのは弓と違いｘ軸も動くからでUpdateから外せば大丈夫だと思われるから書き換えないがダメだったら書き換える
            
        }
        if (range.enemiesInRange.Count > 0)
        {
            float minDistance = range.range + 1f;//一番近い距離を保存　射程より1多い値を代入
            foreach (EnemyController enemy in range.enemiesInRange)//射程内の敵(EnemyController持ち)がいなくなるまで実行
            {//上記でEnemyController enemyこう書くことによりenemyで使えるようになった
                if (enemy != null)//EnemyControllerが存在すれば実行
                {
                    //上空にいる敵を優先させる(今のところ上に湧く敵の高さ同じにする予定だから一番高いので大丈夫)その後距離を求める
                    //同じだった場合は距離を求める　else ifを使う　始めが高さ
                    float distance = Vector3.Distance(transform.position, enemy.transform.position);//自身と敵の距離を代入
                    if (distance < minDistance) //代入した距離がminDistanceより小さければ実行
                    {
                        minDistance = distance;//minDistanceに代入(上書き)
                        target = enemy.transform;//targetの座標を代入(上書き)

                    }
                }

            }
        }
        else
        {
            target = null;
        }
    }
    void loock()//向く動作実験用関数
    {

    }
}
