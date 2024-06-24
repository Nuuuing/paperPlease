using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketSpawner : MonoBehaviour
{
    public int poolSize = 5;
    public GameObject ticketPrefab;
    public Transform parentTransform;
    private int currentTicketIndex = 0;

    private List<GameObject> ticketPool;
    private bool isActivating = false;

    private void Awake()
    {
        ticketPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject ticket = Instantiate(ticketPrefab, parentTransform);
            ticket.SetActive(false);
            ticketPool.Add(ticket);
        }
    }

    public void ActivateTicket()
    {
        if (isActivating)
            return;

        isActivating = true;

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z); // �������� �ٷ� �Ʒ� ��ġ

        for (int i = 0; i < poolSize; i++)
        {
            int index = (currentTicketIndex + i) % poolSize;

            if (!ticketPool[index].activeInHierarchy)
            {
                ticketPool[index].transform.position = spawnPosition;
                ticketPool[index].transform.SetParent(transform.parent);
                ticketPool[index].SetActive(true);

                currentTicketIndex = (index + 1) % poolSize;
                isActivating = false;
                return;
            }
        }

        // ��� Ƽ���� Ȱ��ȭ�� ������ �� ó��
        Debug.LogWarning("All tickets are already active. Cannot activate a new ticket.");
        isActivating = false;
    }
}
