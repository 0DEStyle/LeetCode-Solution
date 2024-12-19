/*Challenge link:https://www.codewars.com/kata/61bbd54e14d129001be6f4c7
Question:
You are an intern working in the software development department of the X-COM agency, responsible for fighting off a large-scale invasion of extraterrestrials. Your task for today is described with the bug report below. At the same time, your colleague works on adding more tests, because current ones are, apparently, insufficient.

[XCOM-302] Stun gun sends pulses which are too strong
Type: Bug 🪳
Priority: Major ⚡
Component: Stun gun
Reporter: mib-k
Assignee: Assigned to you

Description of the bug
The prototype of stun gun handed out recently to agents for field testing can be tampered with and set to voltages exceeding allowed range of 30kV. Despite of built-in protections, the gun poses a risk to operators, and its effect can go beyond non-lethal incapacitation and leave subjects electrocuted.

Expected behavior
Voltage modulator of the stun gun should emit a series of gradually dimnishing electrical impulses. Power of the first impulse is equal to the setting on the Power knob of the gun. The max allowed power level for hand-held devices is specified as 30kV. If the device is tampered with and its shock power is set to a value higher than allowed max, the device should behave as if set to 30kV.
After pressing the trigger and releasing the initial shock pulse, the gun continues emitting impulses, each of the power decreased by the decrement setting from the previous one, until it reaches 0 (or below) and then stops.
There must be no failure when the gun is fired, but its electrodes fail to attach to any target.
Related issues
[XCOM-292] Stun gun cords are too short (fixed)
[XCOM-294] Stun gun wires are too long and tangle easily (open)
[XCOM-295] Prevent negative voltage to protect operator from reverse current (fixed)
[XCOM-299] Tests for stun gun are not sufficient! (in progress)
[XCOM-304] Stun gun breaks apart when accidentally discharged at no target (open)
*/

//***************Solution********************

namespace XCom.Weaponry;

public class StunVoltageModulator {
  //30kV 30 000
  private const int MAX_VOLTAGE = 30000;
  
  public void EmitShockPulse(uint initialVoltage, uint decrement, IStunee stunee) {
    initialVoltage = System.Math.Min(initialVoltage, MAX_VOLTAGE);
    
    for(var level = initialVoltage + decrement; level > (level -= decrement) && level > 0;)
      stunee?.Shock(level);
  }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace XCom.Weaponry
{
    [TestFixture, Order(1)]
    public class StunGunTest
    {
        private readonly StunVoltageModulator voltageModulator = new StunVoltageModulator();

        [Test, Order(1), Description("Max voltage is capped at 30kV")]
        public void TestMaxCapVoltage()
        {
            var meter = new ShockMeter();
            Assert.DoesNotThrow(() => voltageModulator.EmitShockPulse(40_000u, 10_000u, meter));          
            CollectionAssert.AreEquivalent(new[] { 30_000u, 20_000u, 10_000u }, meter.RecordedPulses);
            Assert.IsNull(meter.Error, "Incorrectly handled exception");
        }      
      
        [Test, Order(2), Description("Target survives severe shock with many pulses")]
        public void TestSevereShock_ManyPulses()
        {
            var subject = new Sectoid();
            Assert.DoesNotThrow(() => voltageModulator.EmitShockPulse(1500u, 100u, subject));
            Assert.IsNull(subject.Error, "Incorrectly handled exception");
        }

        [Test, Order(3), Description("Target survives severe shock with a single pulse")]
        public void TestSevereShock_SinglePulse()
        {
            var subject = new Sectoid();
            Assert.DoesNotThrow(() => voltageModulator.EmitShockPulse(1500u, 1500u, subject));
            Assert.IsNull(subject.Error, "Incorrectly handled exception");
        }

        [Test, Order(4), Description("Target survives a series of tingling pulses")]
        public void TestTinglingSeries()
        {
            var subject = new Sectoid();
            Assert.DoesNotThrow(() => voltageModulator.EmitShockPulse(50u, 4u, subject));
            Assert.IsNull(subject.Error, "Incorrectly handled exception");
        }

        [Test, Order(5), Description("Nothing breaks when accidentally discharged at no target")]
        public void TestAccidentalDischarge()
        {
            Assert.DoesNotThrow(() => voltageModulator.EmitShockPulse(200u, 200u, null));
        }

        [Test, Order(6), Description("Unaligned settings")]
        public void TestUnalignedSettings()
        {
            var meter = new ShockMeter();
            Assert.DoesNotThrow(() => voltageModulator.EmitShockPulse(1000u, 300u, meter));          
            CollectionAssert.AreEquivalent(new[] { 1000u, 700u, 400u, 100u }, meter.RecordedPulses);
            Assert.IsNull(meter.Error, "Incorrectly handled exception");
        }        
      
        [Test, Order(7), Description("Repeated rapid use test (100 shots with various settings)")]
        public void TestRepeatedRapidUse()
        {
          var rnd = new Random();
          for(int i=0; i<100; ++i)
          {
            var  meter = new ShockMeter();
            uint initial    = (uint)rnd.Next(50, 30000);
            uint pulseCount = (uint)rnd.Next(3, 25);
            uint decrement  = initial / pulseCount;
            List<uint> expected = new();
            
            var level = initial;
            while(level >= decrement) {
              expected.Add(level);
              level -= decrement;
            }
            if(level > 0)
              expected.Add(level);
            
            Assert.DoesNotThrow(() => voltageModulator.EmitShockPulse(initial, decrement, meter));
            CollectionAssert.AreEquivalent(expected, meter.RecordedPulses);
            Assert.IsNull(meter.Error, "Incorrectly handled exception");
          }
        }
      
        private class ShockMeter : IStunee
        {
            public List<uint> RecordedPulses { get; } = new List<uint>();
            public Exception Error { get; private set; }
            public void Shock(uint pulse) {
              
              try {              
                if(RecordedPulses.Count == 0) {
                  if (pulse > 30000) throw new MalfunctionException("Voltage of the initial pulse exceeded 30kV");
                } else {
                  if(pulse > RecordedPulses[^1]) throw new MalfunctionException("Voltage increase detected");
                }
                RecordedPulses.Add(pulse);
              } catch (Exception ex) {
                Error = ex;
                throw;
              }
            }
        }      
        private class Sectoid : IStunee
        {
            private const uint lethalPulse = 2000;
            public Exception Error { get; private set; }
            public void Shock(uint pulse)
            {
              try {
                if (pulse >= lethalPulse)
                    throw new ShockedToDeathException("Test subject dies due to exceeded shock level");
              } catch(Exception ex) {
                Error = ex;
                throw;
              }
            }
        }
      
        public class MalfunctionException : System.Exception
        {
            public MalfunctionException(string message) : base(message) { }
        }
        public class ShockedToDeathException : System.Exception
        {
            public ShockedToDeathException(string message) : base(message) { }
        }
    }
}
