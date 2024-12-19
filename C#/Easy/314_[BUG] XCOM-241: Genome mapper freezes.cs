/*Challenge link:https://www.codewars.com/kata/64d55f26529cad3a7a8c6752/train/csharp
Question:
Only after the performance issue gets fixed and the related bug [XCOM-251] gets resolved, the research team will be able to move to the second stage of tests and verify correctness of performed mapping.

Additional info
Strand format: SLC (singly-linked chain of alien DNA nucleobases). Nucleobases are represented as following records:

public record SlcBase(SlcBase next, char nucleobase) {}
Mapping: HOPE-LUNA mapping (H maps to L, O to U, P to N, E to A, and vice versa). Lowercase inputs map to uppercase output.
Throughput: It's necessary to be able to process hundreds of strands of ~200k nucleobases.

Notes
This bug is CRITICAL and must be fixed ASAP! The captured specimen is the first with DNA containing the nucleotides P and N, making it crucial for research into PSI capabilities. The body of the sectoid psionic will decompose in three days, rendering it unusable for further study!

Related
[XCOM-251] Mapping for some nucleotide bases does not work (open)
*/

//***************Solution********************

using System.Collections.Generic;
using System.Text;

//public record SlcBase(SlcBase next, char nucleobase) {}
namespace XCom.Dna.Mapping{
public class HopeLunaMapper{
        private readonly Dictionary<char, char> mapping = new Dictionary<char, char>{
            ['H'] = 'L', ['L'] = 'H', ['O'] = 'U', ['U'] = 'O',
            ['P'] = 'N', ['N'] = 'P', ['E'] = 'A', ['A'] = 'E'
        };
        
        public string MapStrand(SlcBase baseNode){
            StringBuilder s = new();
          
            //convert charactger to upper and append to string builder s
            for (SlcBase current = baseNode; current != null; current = current.Next)
                s.Append(mapping[char.ToUpper(current.Nucleobase)]);
          
            return s.ToString(); 
}}}

//****************Sample Test*****************
using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace XCom.Dna.Mapping
{
    [TestFixture]
    public class HopeLunaMapperTests
    {
        private HopeLunaMapper mapper;

        [SetUp]
        public void SetUpTest()
        {
            mapper = new HopeLunaMapper();
        }

        [Test, Order(1)]
        public void TestEdge_Null()
        {
            SlcBase strand = null;
            string actual = mapper.MapStrand(strand);
            Assert.That("", Is.EqualTo(actual));
        }

        [Test, Order(2)]
        public void TestLunaHopeBases()
        {
            SlcBase strand = StringToStrand("LUNAHOPE");
            string actual = mapper.MapStrand(strand);
            Assert.That("HOPELUNA", Is.EqualTo(actual));
        }

        [Test, Order(3)]
        public void TestShortDna()
        {
            string src = "LUNAHOPE".Repeat(100);
            string tgt = "HOPELUNA".Repeat(100);
            SlcBase strand = StringToStrand(src);

            for (int test = 1; test <= 100; ++test)
            {
                string actual = mapper.MapStrand(strand);
                Assert.That(tgt, Is.EqualTo(actual));
            }
        }

        [Test, Order(4)]
        public void TestLongDna()
        {
            string src = "LUNAHOPE".Repeat(20_000);
            string tgt = "HOPELUNA".Repeat(20_000);
            SlcBase strand = StringToStrand(src);

            for (int test = 1; test <= 100; ++test)
            {
                string actual = mapper.MapStrand(strand);
                Assert.That(tgt, Is.EqualTo(actual));
            }
        }
 
        private readonly static (string, string)[] SEGMENTS = [
          ( "HOPE", "LUNA" ), ( "hope", "LUNA" ),
          ( "LUNA", "HOPE" ), ( "luna", "HOPE" ),
          ( "NULL", "POHH" ), ( "null", "POHH" ),
          ( "POHH", "NULL" ), ( "pohh", "NULL" ),
          ( "nALa", "PEHE" ), ( "HAlo", "LEHU" ),
          ( "pEPe", "NANA" ), ( "NaNa", "PEPE" ),
          ( "HuAn", "LOEP" ), ( "plan", "NHEP" ),
        ];

        [Test, Order(5)]
        public void TestRealSamples() {

          Random rnd = new Random();

          for(int test = 1; test <= 100; ++test) {
            StringBuilder src = new StringBuilder();
            StringBuilder tgt = new StringBuilder();

            int segments = rnd.Next(test * 100, test * 200);
            for(int i=0; i<segments; ++i) {
              var (segsrc, segtgt) = SEGMENTS[rnd.Next(0, SEGMENTS.Length)];
              src.Append(segsrc);
              tgt.Append(segtgt);
            }

            SlcBase strand = StringToStrand(src.ToString());
            string actual = mapper.MapStrand(strand);
            Assert.That(tgt.ToString(), Is.EqualTo(actual));
          }
        }         
      
        private SlcBase StringToStrand(String str) {
          SlcBase current = null;
          int len = str.Length;
          for(int i=1; i<=len; ++i) {
            current = new SlcBase(current, str[^i]);
          }
          return current;
        }
    }
    internal static class StringExtensions {
      internal static string Repeat(this string s, int n) {
        return string.Join("", Enumerable.Repeat(s, n));
      }
    }
  
}
