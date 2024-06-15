using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowChicken : MonoBehaviour
{
    //動画だとprojectiletower
    public Range range;
    float a = 0f;
    Transform mytransform;//これを使うことになった　別から参照する場合名前変える
    public GameObject arrow;
    public Transform firepoint;
    public float timeBetweenShots = 1f;//これと下は使わない　そのためこれを使った部分改造
    public float shotCounter;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        mytransform = GetComponent<Transform>();
        range = GetComponent<Range>();
        //loock();//向くかどうか確認用
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);//これは確か時間がづれているのか確認していた
        shotCounter -= Time.deltaTime;//shotCounterを前回のUpdateからの経過時間分引く Time.deltaTimeのすこし説明メモにある
        if (shotCounter <= 0 && target != null)//shotCounterが0かつtargetが存在すれば実行
        {
            shotCounter = timeBetweenShots;//次の発射までの時間リセット　1秒
            //mytransform.rotation = Quaternion.LookRotation(target.position - mytransform.position);//Quaternionを使用した場合の向き
            //mytransform.rotation=Quaternion.Euler(0f,)
            //VEctorでやっぱり実行する　Quaternionの勉強してから使う　後なんかこれはapdateとかのずっと行われるもので使いそう
            //これでターゲットの方を向き続け狙い続けるLoocAtだとかくかくした感じになる
            //みた動画ではさらにこれをslapを使うものに変更していた今度調べる
            //(大体今いる位置と目標の位置の間に1フレーム(Update)ごとに移動だと読みとった)(だんだん遅くなる)
            //いろいろ書いてありコピペしたいけど長いからなしで　タワーディフェンスのセクション6の23.Turning The Cannonに書いてある
            //ターゲットの位置が下すぎたり上すぎると斜め向きになるからそれを直すコードも書いていたけどターン制だから向いた後斜め下、上を直す
            //今回はx軸を直す
            this.gameObject.transform.LookAt(target);//ターゲットの方向に向く
            Vector3 angle = mytransform.eulerAngles;
            angle.x = 0f; angle.z = 0f;
            mytransform.eulerAngles = angle;
            //ひとまずこれでいくが無理だった場合はひとまず教材のものにするか毎回値を変数に入れて1Vecter3宣言下変数に入れてそれのxの値を変えて
            //再度代入するも検討中  もしかしたら失敗したからやり直しもしかしたら取れてないかも　Quaternionの勉強後決めるそれまで動画道理にする
            //もし動画道理だと動かない場合変える　確認方法はスタートで一度だけ向く関数を実行する
            //Vector3 angle=
            firepoint.LookAt(target);//発砲位置がターゲットの方向を向く　念のために書いておく

            //Instantiateはオブジェクトを生成する関数
            Instantiate(arrow, firepoint.position, firepoint.rotation);//かっこの中の値にオブジェクトを生成
            //近すぎるからすぐ消えていて見えなかっただけかもしれないけど見えなかったからもしかしたら生成が出来ていないかもしれない
        }
        if (range.enemiesInRange.Count > 0)//エネミーを管理する配列が空じゃなければ実行
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
