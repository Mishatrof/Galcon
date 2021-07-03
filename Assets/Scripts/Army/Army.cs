using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Army : MonoBehaviour
{
    public abstract Transform Target { get; set; }
    public abstract int Speed { get; }

    public abstract void SetDestinationArmy(Transform Target);
  
   
 
}
