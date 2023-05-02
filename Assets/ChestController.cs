using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChestController : MonoBehaviour
{
    public GameObject chestObject; // reference na truhlu
    public GameObject itemObject; // reference na objekt, kter� se m� odebrat po sebr�n�

    private bool isOpen = false; // zda je truhla otev�en�

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            if (!isOpen)
            {
                isOpen = true;
                GenerateItem(); // zavol� metodu pro vygenerov�n� p�edm�tu
            }
        }
    }

    private void GenerateItem()
    {
        GameObject newItem = Instantiate(itemObject, chestObject.transform.position, Quaternion.identity); // vytvo�� nov� objekt na pozici truhly
        newItem.transform.SetParent(null); // odebere objekt z truhly
        chestObject.SetActive(false); // skryje truhlu
    }
}

