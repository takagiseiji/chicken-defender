using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dispatch : MonoBehaviour
{    //派遣のスクリプト
    //素材のとれぐわいの調整が難しそう
    //どれる量は使う量に依存擦ればいいが出来るなら場所によってとれるものを変えるの検討中
    //基本ランダムでつるはしや斧を使うことで決まった量を取れるようにする　一回だけか何回も使えるかは検討中だけどそれによって素材変わる
    //つるはしや斧使うと固定値+ランダム分検討中だからランダムの量多くて3でもいいかも
    //金のと鉄のツールで分けて固定値変えるのありかも
    // Start is called before the first frame update
    public PlayerManager player;
    public TextMeshProUGUI mine;
    public TextMeshProUGUI forest;
    public TextMeshProUGUI silveraxcount;
    public TextMeshProUGUI goldaxcount;
    public TextMeshProUGUI silverpickaxecount;
    public TextMeshProUGUI goldpickaxecount;
    public GameObject nochicken;
    public GameObject nomatelial;
    bool nochickentrue = false;
    bool nomatelialtrue = false;
    float noUItime = 0;
    int silverax = 0;
    int goldax = 0;
    int silverpickaxe = 0;
    int goldpickaxe = 0;
    void Start()
    {
        //player = GetComponent<PlayerManager>();
        nochicken.SetActive(false);
        nomatelial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (nochickentrue == true)
        {
            noUItime -= Time.deltaTime;
            nochicken.SetActive(true);
            if (noUItime <= 0)
            {
                nochicken.SetActive(false);
            }
        }
        if (nomatelialtrue == true)
        {
            noUItime -= Time.deltaTime;
            nomatelial.SetActive(true);
            if (noUItime <= 0)
            {
                nomatelial.SetActive(false);
            }
        }
    }
    public void Forest()
    {
        if (player.chicken >= 3)
        {
            player.forest++;
            TextForest();
        }
        else
        {
            nochickentrue = true;
            noUItime = 1;
        }
        
    }
    public void Minusforest()
    {
        if (player.forest >= 1)
        {
            player.forest--;
            TextForest();
            Debug.Log("マイナス");
        }
        
    }
    void TextForest()
    {
        forest.text = ""+player.forest;
    }
    public void Silverax()
    {
        if (player.silverax > silverax)
        {
            silverax++;
            TextSilverax();
        }
        else
        {
            nomatelialtrue = true;
        }
    }
    public void MinusSilverax()
    {
        if (silverax >= 1)
        {
            silverax--;
            TextSilverax();
        }
    }
    public void TextSilverax()
    {
        silveraxcount.text = "" + silverax;
    }
    public void Goldax()
    {
        if (player.goldax >goldax)
        {
            goldax++;
            TextGoldax();
        }
        else
        {
            nomatelialtrue = true;
        }
    }
    public void MinusGoldax()
    {
        if (goldax >= 1)
        {
            goldax--;
            TextGoldax();
        }
    }
    public void TextGoldax()
    {
        goldaxcount.text = "" + goldax;
    }
    public void Mine()
    {
        player.mine++;
        TextMine();
    }
    public void MInusmine()
    {
        if (player.mine >= 1)
        {
            player.mine--;
            TextMine();
        }
        
    }
    void TextMine()
    {
        mine.text = "" + player.mine;
    }
    public void Silverpickaxe()
    {
        if (player.silverpickaxe >silverpickaxe)
        {
            silverpickaxe++;
            TextSilverpickaxe();
        }
        else
        {
            nomatelialtrue = true;
        }
    }
    public void MinusSilverpickaxe()
    {
        if (silverpickaxe >= 1)
        {
            silverpickaxe--;
            TextSilverpickaxe();
        }
    }
    public void TextSilverpickaxe()
    {
        silverpickaxecount.text = "" + silverpickaxe;
    }
    public void Goldpickaxe()
    {
        if (player.goldpickaxe >goldpickaxe)
        {
            goldpickaxe++;
            TextGoldpickaxe();
        }
        else
        {
            nomatelialtrue = true;
        }
    }
    public void MinusGoldpickaxe()
    {
        if (goldpickaxe >= 1)
        {
            goldpickaxe--;
            TextGoldpickaxe();
        }
    }
    public void TextGoldpickaxe()
    {
        goldpickaxecount.text = "" + goldpickaxe;
    }

   
}
