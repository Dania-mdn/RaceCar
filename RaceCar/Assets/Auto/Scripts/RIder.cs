using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIder : MonoBehaviour
{
    public bool statick;
    void Start()
    {
        if(statick)
            EnableKinematicsRecursively(transform);
    }

    void EnableKinematicsRecursively(Transform parent)
    {
        // �������� ���������� ��� ����������� ���� �������
        Rigidbody rb = parent.GetComponent<Rigidbody>();
        FixedJoint fj = parent.GetComponent<FixedJoint>();
        CharacterJoint cj = parent.GetComponent<CharacterJoint>();
        CapsuleCollider cc = parent.GetComponent<CapsuleCollider>();

        if (rb != null)
        {
            rb.isKinematic = true;
        }
        if (fj != null)
        {
            Destroy(fj);
        }
        if (cj != null)
        {
            Destroy(cj);
        }
        if (cc != null)
        {
            Destroy(cc);
        }

        // ���������� �������� ���� ����� ��� ������� ��������� �������
        foreach (Transform child in parent)
        {
            EnableKinematicsRecursively(child);
        }
    }
}
