using UnityEngine;
using System.Collections.Generic;

public class CarShowroom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Car car = new Clown();

        (car as Clown)?.EjectClown();

        Clown clownCar = new Clown();
        F1 F1Car = new F1();

        clownCar.SetOwner("Oscar");
        F1Car.SetOwner("Andrew");

        Race(clownCar, F1Car);

        List<Car> cars = new List<Car>();
        cars.Add(clownCar);
        cars.Add(F1Car);
        cars.Add(car);

        int i = Random.Range(0, cars.Count);
        Car raceCar1 = cars[i];
        cars.RemoveAt(i);
        i = Random.Range(0, cars.Count);
        Race(raceCar1, cars[i]);

    }

    // Update is called once per frame
    void Race(Car car1, Car car2)
    {
        if(car1.speed >  car2.speed) 
        {
            Debug.Log("The winner is: " + car1.VictorySpeech());
        }
        else
        {
            Debug.Log("The winner is: " + car2.VictorySpeech());
        }
    }
}

