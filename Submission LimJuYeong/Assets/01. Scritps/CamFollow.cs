using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // ������ ���
    public float speed; // ī�޶� �̵� �ӷ�

    // ī�޶� ���� ���� �ȿ����� �����̵��� ����
    public Vector2 center; // 2���� ���Ϳ� ��ġ 
    public Vector2 size; // ���� ������
    float height; // ����
    float width; // ����

    void Start()
    {
        // ��ũ���� ����, ���� ������ �̿��ؼ� ��������� ���� ũ�⸦ ���ϱ�
        // ���� ���� = ���� ���� * ��ũ�� ���� / ��ũ�� ����
        height = Camera.main.orthographicSize; // ���̴� ����׷��� ����� �� ���� ī�޶� ũ�̿� �����̴�.
        width = height * Screen.width / Screen.height;
    }


    void LateUpdate() // LateUpdate�� Update �޼ҵ尡 ������ LateUpdate�� �̷������
                      // �׷���, ��Ȯ�� ��ġ�� �ľ��� �� ����.
    {
        // ���� ī�޶� ��ġ ����
        // ī�޶��� position ���� �÷��̾��� position���� ����
        // Vector3Lerp�� A�� B ������ ���� ���� ��ȯ
        // A�� B�� �����̶�� ��ȯ�� ���ʹ� +��(0.0~1.0)�� ���� ����
        // ī�޶��� ��ġ�� �� ������ ���ݾ� �÷��̾ �ٰ���
        // �̶� Time.deltaTime�� ���� speed ���� �����ϰ� ���ϱ�
        // speed�� ���� ���� ī�޶��� �̵��ӵ��� ����
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);

        // Mathf.Clamp(value,min,max)
        // vlaue���� min�� max�� ���̸� value�� ��ȯ�ϰ�
        // vlue���� min���� ������ min�� max���� ũ�� max�� ��ȯ 
        float lx = size.x * 0.5f - width;
        
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = size.y * 0.5f - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // ���� �� �� �ֵ��� ������� ���� ���������� ����
        Gizmos.DrawWireCube(center,size); // center�� �߽����� sizeũ���� ť�긦 ǥ��
    }
}
