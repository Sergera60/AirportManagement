// See https://aka.ms/new-console-template for more information



using AM.ApplicationCore.Domain;

Console.WriteLine("Hello, World!");

Plane plane = new Plane { Capacity=100 ,PlaneType=PlaneType.Boring , ManufactureDate = DateTime.Now,
    PlaneId = 1

}; 
Console.WriteLine(plane.ToString());