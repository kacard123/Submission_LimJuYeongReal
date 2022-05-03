using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestRenderer : MonoBehaviour
{
    [System.Serializable]
    public class QuestDataProperty
    {
        public Sprite sprite;
        public string description;
    }

    public Button previousPageButton, nextPageButton;
    public Image questImg;
    public TextMeshProUGUI descriptionTxt;

    public List<QuestDataProperty> questData;

    int currentPage; //=0�ʱⰪ / �� ������ ���� �� �������� �ִ����� ��´�

    
    void Start()
    {
        UpdateUI();
    }


    //���� �������� �´� ��ư�� ���¸� �ִ´�
    //������ �Ѿ �������� �־�� ��ư�� ���� ������
    void UpdateUI()
    {   //���� ������ �տ� �����Ͱ� �ֳ� ����
        //false�� ������ interactable�� �� ��
        previousPageButton.interactable = currentPage > 0;
        nextPageButton.interactable = currentPage < questData.Count - 1;
        //�������� �̵��� �������� �ִٴ� �ǹ�
        UpdateContent();
    }
    //���� �������� �´� ������ ����
    void UpdateContent()
    {
        //questData ���� �տ��ִ� ����� ��������Ʈ�� ���� ��
        questImg.sprite = questData[currentPage].sprite;

        StopAllCoroutines(); //�ڷ�ƾ�Լ��� �۵�->�ٽ� ÷���� ȣ���ؾ���...?->���ó��
        StartCoroutine(AppearTextOneByOne(0.05f));//�ð����� ~�� /  ���� �ٽ� ȣ��
    }

    IEnumerator AppearTextOneByOne(float interval)
    {
        int index = 1;
        //���� ����ؾ� �� ���� -> questData�� currentPage
        string description = questData[currentPage].description;

        while (index <= description.Length)
        {
            descriptionTxt.text = description.Substring(0, index); //0~index ������
            yield return new WaitForSeconds(interval); //interval��ŭ �����ϴ� ��� / �ð����ֱ�
            index++;

        }
    }

    //��ư�� Ŭ���ϸ� ���� �������� �̵�
    public void OnClickPrevButton()
    {
        Debug.Log("click prev button");

        currentPage--;

        UpdateUI();
    }

    // ��ư�� Ŭ���ϸ� ��� �������� �̵�
    public void OnClickNextButton()
    {
        Debug.Log("click next button");

        currentPage++;

        UpdateUI();
    }
}