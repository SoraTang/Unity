using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Keep : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);//�ڼ����³���ʱ�����ٽű����صĶ���
        //��ʽ�� DontDestroyOnLoad(this.gameObject);
    }
}


