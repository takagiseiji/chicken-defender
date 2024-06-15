using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyAction : MonoBehaviour
{
    //飛んでいる系の敵のコード
    //基本地上のを持ってきて少しだけいじれば完成だが攻撃はrayではなくてenemyrangeのコードを維持て使えばいい

    //攻撃に使えると思う
    /*else if (attackcount == 0)　//ここは範囲内にいた奴だけど正面だけ行動にするから要らないかも
       {
           //targetにリストの一番上の鶏の情報を入れる
           if (enemyRange.enemiesInRange.Count > 0)
           {
               target = enemyRange.enemiesInRange[0].gameObject;
               yield return new WaitForSeconds(1.0f);//ここ出来るだけ分からないぐらいの時間にしたい　仮で今は１秒にしている
               Attack();
               attackcount++;
           }*/
    /*else
    {
        yield return new WaitForSeconds(1.0f);//ここ出来るだけ分からないぐらいの時間にしたい　仮で今は１秒にしている 要らないかも
        enemyController.Move();
        attackcount = 0;
    }

}*/
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
