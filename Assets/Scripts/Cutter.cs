using UnityEngine;

public class Cutter : MonoBehaviour
{
    private Vector3 randomAngle; //Impact angle of a fruit piece
    public GameObject knife;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Slice" && knife.GetComponent<Knife>().isCutting) //если фрукт соприкоснулся с резаком и нож резал
        {
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            collider.gameObject.GetComponent<Rigidbody>().AddTorque(-Vector3.up * 8900f, ForceMode.Impulse); //кручение
            randomAngle = new Vector3(Random.Range(-0.3f, -0.6f), Random.Range(0.2f, 0.3f), Random.Range(-0.5f, 0.5f)); //случайный угол
            collider.gameObject.GetComponent<Rigidbody>().AddForce(randomAngle * Random.Range(650, 1500), ForceMode.Impulse); //назнач. случайный угол кускам фруктов
            knife.GetComponent<Knife>().SetCuttingState(true);
            GameSystem.System.LEVEL.OnVegetableCut();

            Destroy(collider.gameObject, 4f); //уничтожить куски фруктов через 4 секунды
            Destroy(collider.gameObject.transform.parent.gameObject, 4f);
        }
    }
}
