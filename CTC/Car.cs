using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class Car : ICloneable
    {
        public int CarId { get; set; }
        public string Image { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string ColourOutside { get; set; }
        public string TrimColour { get; set; }
        public int PowerInHp { get; set; }
        public int Acceleration { get; set; }
        public int TopSpeedInKmh { get; set; }
        public int HandlingRange { get; set; }
        public int BreakingForce { get; set; }
        public int Weight { get; set; }
        public int Rating { get; set; }
        public double Value { get; set; }
        public int? BumperId { get; set; }
        public Bumper? Bumper { get; set; }
        public int? ExhaustId { get; set; }
        public Exhaust? Exhaust { get; set; }
        public int? NitroId { get; set; }
        public Nitro? Nitro { get; set; }
        public int TyreId { get; set; }
        public Tyre Tyre { get; set; }
        public int? RearSpoilerId { get; set; }
        public RearSpoiler? RearSpoiler { get; set;}
        public int RimId { get; set; }
        public Rim Rim { get; set; }
        public int EngineId { get; set; }
        public Engine Engine { get; set; }
        public int BreakId { get; set; }
        public Break Break { get; set; }
        public bool Electric { get; set; }


        public int GetCalcPowerInH()
        {
            // Calculates the power attribute in horsepower.
            int calcPowerInHp = PowerInHp;

            calcPowerInHp += Engine.ImpactPowerInHp;
            if (Exhaust != null)
            {
                calcPowerInHp += Exhaust.ImpactPowerInHp;
            }

            return calcPowerInHp;
        }
        public int GetCalcAcceleration()
        {
            // Calculates the acceleration attribute.
            int calcAcceleraton = Acceleration;

            if(Exhaust != null)
            {
                calcAcceleraton += Exhaust.ImpactAcceleration;
            }
            calcAcceleraton += Engine.ImpactAcceleration;

            return calcAcceleraton;
        }
        public int GetCalcTopSpeedInKmh()
        {
            // Calculates the TopSpeed attribute in Kilometers per hour.
            int calcTopSpeedInKmh = TopSpeedInKmh;

            calcTopSpeedInKmh += Engine.ImpactTopSpeed;

            return calcTopSpeedInKmh;
        }
        public int GetCalcHandlingRange()
        {
            // Calculates the HandlingRange attribute.
            int calcHandlingRange = HandlingRange;

            if (RearSpoiler != null)
            {
                calcHandlingRange += RearSpoiler.ImpactHandling;
            }
            calcHandlingRange += Tyre.ImpactHandling;

            return calcHandlingRange;
        }
        public int GetCalcBreakingForce()
        {
            // Calculates the BreakingForce attribute.
            int calcBreakingForce = BreakingForce;

            calcBreakingForce += Tyre.ImpactBreakingForce;
            calcBreakingForce += Break.ImpactBreakingForce;

            return calcBreakingForce;
        }
        public int GetCalcWeight()
        {
            // Calculates the Weight attribute.
            int calcWeight = Weight;

            if (Bumper != null)
            {
                calcWeight += Bumper.Weight;
            }
            if(RearSpoiler!=null)
            {
                calcWeight += RearSpoiler.Weight;
            }
            calcWeight += Rim.Weight;
            calcWeight += Tyre.Weight;
            calcWeight += Break.Weight;
            calcWeight += Engine.Weight;

            return calcWeight;
        }
        public int GetCalcRating()
        {
            // Calculates the Rating attribute.
            int calcRating = Rating;

            if(Exhaust != null)
            {
                calcRating += Exhaust.ImpactRating;
            }
            if (Bumper != null)
            {
                calcRating += Bumper.ImpactRating;
            }
            if(RearSpoiler != null)
            {
                calcRating += RearSpoiler.ImpactRating;
            }
            calcRating += Rim.ImpactRating;
            calcRating += Tyre.ImpactRating;
            calcRating += Break.ImpactRating;
            if(Nitro != null)
            {
                calcRating += Nitro.ImpactRating;
            }
            calcRating += Engine.ImpactRating;

            return calcRating;
        }
        public double GetCalcValue()
        {
            // Calculates the Value attribute.
            double calcValue = Value;

            if (Exhaust != null)
            {
                calcValue += Exhaust.Price;
            }
            if (Bumper != null)
            {
                calcValue += Bumper.Price;
            }
            if (RearSpoiler != null)
            {
                calcValue += RearSpoiler.Price;
            }
            calcValue += Rim.Price;
            calcValue += Tyre.Price;
            calcValue += Break.Price;
            if (Nitro != null)
            {
                calcValue += Nitro.Price;
            }
            calcValue += Engine.Price;

            calcValue = Math.Round(calcValue, 2);

            return calcValue;
        }
        public override string ToString()
        {
            return $"{Brand.Name} {Model}";
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
