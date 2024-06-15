using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/*
 * CinemachineVirtualCamera
 * Dead Zone (width/height) 0.45
 * 
 * CinemachineConfiner2D
 * Damping : 0f
 * 
 * �Ȃɂ����쒆�͓����Ȃ��悤�ɂƂ�������
 * 
 * */
namespace anogame_strategy
{
	public class CameraTargetController : MonoBehaviour
	{
		public CinemachineVirtualCamera m_virtualCamera;
		public Vector3 mousePos;

		private void Update()
		{
			mousePos = Input.mousePosition;

			Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
			transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);
		}
	}
}
