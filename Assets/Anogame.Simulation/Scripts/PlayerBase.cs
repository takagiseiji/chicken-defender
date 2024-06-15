using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace anogame_strategy
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public int PlayerNumber;
        public virtual void Play(StrategyBase _gameManager)
		{
            // �����Ă���
            show_player();

            play(_gameManager);
		}
        public abstract void play(StrategyBase _gameManager);

        private void show_player()
		{
            GameObject obj = GameObject.Find("SituationText");
            if( obj != null && obj.GetComponent<Text>() != null)
			{
                obj.GetComponent<Text>().text = $"�^�[��:Player{PlayerNumber+1}";
            }
		}

    }

}