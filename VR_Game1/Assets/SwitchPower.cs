using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPower : MonoBehaviour
{
    //Change Power Booleans
    public bool isFire = false;
    public bool isEarth = false;
    //public bool isWind = false;
    //public bool isWater = false;
    public int whichPower;

    public List<GameObject> objects;

    public void SelectPower(string objectName)
    {
        foreach (var item in objects)
        {
            print("Sono nel foreach, item: " + item.name);
            item.SetActive(objectName == item.name);
        }
        /*{
            print("L'oggetto è: " + objectName + " l'item è: " + item.name);
            if (objectName == item.name && item.name == "Square")
            {
                print("Sono in SelectPowerSquare");
                isEarth = true;
                isFire = false;
                //whichPower = 1;
                //ChangePower();
            }

            if (objectName == item.name && item.name == "Triangle")
            {
                print("Sono in SelectPowerTriangle");
                isEarth = false;
                isFire = true;
                //whichPower = 2;
                //ChangePower();
            }
        }
        */
    }
    /*
    public void SelectEarth()
    {
        print("I am in the SelectHeart function");
        whichPower = 1;
        ChangePower();
    }
    
    public void SelectFire()
    {
        print("I am in the SelectFire function");
        whichPower = 2;
        ChangePower();
    }
   
    void ChangePower()
    {
        switch (whichPower)
        {
            case 1:
                isEarth = true;
                isFire = false;
               // isWater = false;
               // isWind = false;
                print("Sono nello switch case 1. Bool: isEarth: " + isEarth + "isFire: " + isFire);
                break;
            case 2:
                isEarth = false;
                isFire = true;
               // isWater = false;
               // isWind = false;
                print("Sono nello switch case 2. Bool: isEarth " + isEarth + "isFire: " + isFire);
                break;
           
            case 3:
                isEarth = false;
                isFire = false;
                isWater = true;
                isWind = false;
                break;
            case 4:
                isEarth = false;
                isFire = false;
                isWater = false;
                isWind = true;
                break; 
            
        }
    }
   */
}
