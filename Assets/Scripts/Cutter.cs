using UnityEngine;

public class Cutter : MonoBehaviour
{
    private Vector3 randomAngle; //Impact angle of a fruit piece
    public GameObject knife;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Slice" && knife.GetComponent<Knife>().isCutting) //���� ����� ������������� � ������� � ��� �����
        {
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            collider.gameObject.GetComponent<Rigidbody>().AddTorque(-Vector3.up * 8900f, ForceMode.Impulse); //��������
            randomAngle = new Vector3(Random.Range(-0.3f, -0.6f), Random.Range(0.2f, 0.3f), Random.Range(-0.5f, 0.5f)); //��������� ����
            collider.gameObject.GetComponent<Rigidbody>().AddForce(randomAngle * Random.Range(650, 1500), ForceMode.Impulse); //������. ��������� ���� ������ �������
            knife.GetComponent<Knife>().SetCuttingState(true);
            GameSystem.System.LEVEL.OnVegetableCut();

            Destroy(collider.gameObject, 4f); //���������� ����� ������� ����� 4 �������
            Destroy(collider.gameObject.transform.parent.gameObject, 4f);
        }
    }
}
