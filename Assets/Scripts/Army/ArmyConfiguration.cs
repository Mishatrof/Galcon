using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyConfiguration : Army , ISetDest
{
    public Transform target;
    public PlanetSide myside;

    public override Transform Target {
        get 
        {
            return target;
        }
        set
        {
            target =  value;
        }
    }
   
    public override int Speed { get => 3; }
    public override void SetDestinationArmy(Transform Target)
    {
        this.Target = Target;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Target.gameObject)
        {
            var curentPlanet = collision.gameObject.GetComponent<PlanetSide>();
            if (curentPlanet.side == myside.side)
            {
                collision.gameObject.GetComponent<PlanetConfig>().AddArmy();
            }
            else
            {
                collision.gameObject.GetComponent<PlanetConfig>().MinusArmy(this);
            }
            Destroy(gameObject);
        }
        

    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.position,Speed * Time.deltaTime);
    }

   
}
