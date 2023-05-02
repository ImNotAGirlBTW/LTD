using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChestController : MonoBehaviour
{
    public GameObject chestObject; // reference na truhlu
    public GameObject itemObject; // reference na objekt, který se má odebrat po sebrání

    private bool isOpen = false; // zda je truhla otevøená

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            if (!isOpen)
            {
                isOpen = true;
                GenerateItem(); // zavolá metodu pro vygenerování pøedmìtu
            }
        }
    }

    private void GenerateItem()
    {
        GameObject newItem = Instantiate(itemObject, chestObject.transform.position, Quaternion.identity); // vytvoøí nový objekt na pozici truhly
        newItem.transform.SetParent(null); // odebere objekt z truhly
        chestObject.SetActive(false); // skryje truhlu
    }
}

