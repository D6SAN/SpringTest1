using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkyFloorView : MonoBehaviour
{
    private Vector3 _startPos;

    private Vector3 _endPos;
    private float _timer = 0f;
    //移動方向
    private int _direction = 0;
    //移動中グラフ
    private bool _isAction = false;




    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        _endPos = transform.position + Vector3.right * 2f;
    }

    // Update is called once per frame
   

    void Update()
    {
        if (_isAction) return;
        if (_direction == 0)
        {
            StartCoroutine(MoveFloorASync(_startPos, _startPos));
        }
        else
        {
            StartCoroutine(MoveFloorASync(_endPos, _startPos));
        }
    }

    /// <summary>
    /// 移動コルーチン
    /// </summary>
    /// <param name="stPos"></param>
    /// <param name="edPos"></param>
    /// <returns></returns>

    private IEnumerator MoveFloorASync(Vector3 stPos, Vector3 edPos)
    {
        _timer = 0;

        while(_timer < 1f)
        {
            _timer += Time.deltaTime;//時間を加算
            _timer = Mathf.Min(1f, _timer);//1秒を過ぎたときに最大１秒を超えないように設定する
            transform.position = Vector3.Lerp(stPos, edPos, _timer);
            yield return null;　　//1フレーム待機

        }
        //移動の向きを変える
        _direction = 1 - _direction;
        _isAction = false;
    }


}

