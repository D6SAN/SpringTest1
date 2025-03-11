using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    // �ړ����x
    [SerializeField,Header("Player�X�s�[�h")] private float _speed;
    //�W�����v�� 
    [SerializeField,Header("�W�����v��")] private float _jumpPower;
    //�������Z�p�̗v�f�擾
    private Rigidbody2D _rigidbody2D;
    //���͏�Ԃ̕ۑ�
    private Vector2 _velocity = Vector2.zero;
    // input�V�X�e��
    private PlayerControl _playerControl;
    private bool _isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //���͏󑼂̕ۑ�
        _playerControl = new PlayerControl();
        //���͏�Ԃ̗L��
        _playerControl.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        // controller�̓��͂��擾����
        var dir = _playerControl.Player.Move.ReadValue<Vector2>();
        // ����object�̏�Ԃ��擾����
        _velocity = _rigidbody2D.velocity;
        //���ړ��̑��x���Đݒ肷��
        _velocity.x = dir.x * _speed * Time.deltaTime;
        //�I�u�W�F�N�g�̑��x���Đݒ肷��
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
