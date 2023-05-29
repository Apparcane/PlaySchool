using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMove : MonoBehaviour
{
    // ���������� �����
    private float
         gravity = 9f,
         speedScale = 10f,
         jumpForce = 5f,
         turnSpeed = 220;
    // ���������� ����� ��� �������� ��������� �� ���� ����
    private float
        verticalSpeed = 0f,
        mX = 0f,
        mY = 0f,
        currentAngleX = 0f;
    private CharacterController contr;
    public Camera camera;
    void Start()
    {
        // ������� ������
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        contr = GetComponent<CharacterController>();
    }
    void Update()
    {
        //��������� ������� ��� ���� �� ���������
        RotateCharacter();
        MovePlayer();
    }
    private void RotateCharacter()
    {
        mX = Input.GetAxis("Mouse X");
        mY = Input.GetAxis("Mouse Y");

        //������� �� �� Y
        transform.Rotate(new Vector3(0f, mX * turnSpeed * Time.deltaTime, 0f));

        //������� �� �� X
        currentAngleX += mY * turnSpeed * Time.deltaTime * -1f;
        currentAngleX = Mathf.Clamp(currentAngleX, -90f, 60f);
        camera.transform.localEulerAngles = new Vector3(currentAngleX, 0f, 0f);

    }
    private void MovePlayer()
    {
        // ��������� ���������� ������ ��� ���� ���������, ���� ���� �������� �������� ���� Horizontal �� Vertical 
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        //������������ ���������� ������ � ���������
        velocity = transform.TransformDirection(velocity) * speedScale;
        //������ ��������� ��������
        if (contr.isGrounded)
        {
            verticalSpeed = 0f;
            if (Input.GetButton("Jump"))
            {
                verticalSpeed = jumpForce;
            }
        }

        //���� ������ ��� ���������
        verticalSpeed -= gravity * Time.deltaTime;
        velocity.y = verticalSpeed;
        contr.Move(velocity * Time.deltaTime);
    }

    private void GiveBomb()
    {
        Transform parentObject = transform;
        Transform BombObject = parentObject.Find("Bomb");
        Transform ArmObject = parentObject.Find("RightArm");
        


    }
}
