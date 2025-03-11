using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkyFloorView : MonoBehaviour
{
    private Vector3 _startPos;

    private Vector3 _endPos;
    private float _timer = 0f;
    //�ړ�����
    private int _direction = 0;
    //�ړ����O���t
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
    /// �ړ��R���[�`��
    /// </summary>
    /// <param name="stPos"></param>
    /// <param name="edPos"></param>
    /// <returns></returns>

    private IEnumerator MoveFloorASync(Vector3 stPos, Vector3 edPos)
    {
        _timer = 0;

        while(_timer < 1f)
        {
            _timer += Time.deltaTime;//���Ԃ����Z
            _timer = Mathf.Min(1f, _timer);//1�b���߂����Ƃ��ɍő�P�b�𒴂��Ȃ��悤�ɐݒ肷��
            transform.position = Vector3.Lerp(stPos, edPos, _timer);
            yield return null;�@�@//1�t���[���ҋ@

        }
        //�ړ��̌�����ς���
        _direction = 1 - _direction;
        _isAction = false;
    }


}

