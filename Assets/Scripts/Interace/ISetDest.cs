using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISetDest 
{
    int Speed { get; }

    void SetDestinationArmy(Transform Target);
}
