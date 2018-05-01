using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BuilderDP
{
    class Program
    {
        static void Main(string[] args)
        {

            var shop = new Shop();
            shop.Construct(new ScooterBuilder());
            shop.ShowVehicle();

            shop.Construct(new CarBuilder());
            shop.ShowVehicle();

            shop.Construct(new MotorCycleBuilder());
            shop.ShowVehicle();

            Console.Read();
        }
    }

    public enum PartType
    {
        Frame,
        Engine,
        Wheel,
        Door
    }

    public enum VehicleType
    {
        Car,
        Scooter,
        MotorCycle
    }

    public class Vehicle
    {
        private VehicleType _vehicleType;
        private Dictionary<PartType, string> _parts = new Dictionary<PartType, string>();

        public Vehicle(VehicleType vehicleType)
        {
            _vehicleType = vehicleType;
        }

        //INDEXER PROPERTY
        public string this[PartType key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n----------------------");
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame = {0}", this[PartType.Frame]);
            Console.WriteLine(" Engine = {0}", this[PartType.Engine]);
            Console.WriteLine(" Wheels = {0}", this[PartType.Wheel]);
            Console.WriteLine(" Doors = {0}", this[PartType.Door]);
        }

    }

    public abstract class VehicleBuilder
    {
        public Vehicle Vehicle { get; set; }
        public VehicleBuilder(VehicleType vehicleType)
        {
            Vehicle = new Vehicle(vehicleType);
        }

        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder() : base(VehicleType.MotorCycle)
        {
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "0";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "500 CC";
        }

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "Motorcycle Frame";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "2";
        }
    }

    class CarBuilder : VehicleBuilder
    {
        public CarBuilder() : base(VehicleType.Car)
        {
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "4";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "2500 CC";
        }

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "Car Frame";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "4";
        }
    }

    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder() : base(VehicleType.Scooter)
        {
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "0";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "50 CC";
        }

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "Scooter Frame";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "2";
        }
    }

    class Shop
    {
        private VehicleBuilder _builder;
        public void Construct(VehicleBuilder builder)
        {
            _builder = builder;
            _builder.BuildDoors();
            _builder.BuildEngine();
            _builder.BuildFrame();
            _builder.BuildWheels();
        }

        public void ShowVehicle()
        {
            _builder.Vehicle.Show();
        }
    }
}
