using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    // 移動速度
    [SerializeField,Header("Playerスピード")] private float _speed;
    //ジャンプ力 
    [SerializeField,Header("ジャンプ力")] private float _jumpPower;
    //物理演算用の要素取得
    private Rigidbody2D _rigidbody2D;
    //入力状態の保存
    private Vector2 _velocity = Vector2.zero;
    // inputシステム
    private PlayerControl _playerControl;
    private bool _isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //入力状他の保存
        _playerControl = new PlayerControl();
        //入力状態の有効
        _playerControl.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        // controllerの入力を取得する
        var dir = _playerControl.Player.Move.ReadValue<Vector2>();
        // 今のobjectの状態を取得する
        _velocity = _rigidbody2D.velocity;
        //横移動の速度を再設定する
        _velocity.x = dir.x * _speed * Time.deltaTime;
        //オブジェクトの速度を再設定する
        _rigidbody2D.velocity = _velocity;
        if (_isGround)
        {
            if(_playerControl.Player.junp.triggered)
            {
                _isGround = false ;
                _rigidbody2D.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);

            }


        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
            
        }
    }

}
