using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation
{
    public class IncrementalRandomTest : IncrementalCompilationTestBase
    {
        private const int TestCount = 10;
        private const int SourceLength = 1000;

        private RandomSourceGenerator _sourceGenerator = new RandomSourceGenerator();
        private static Random s_random = new Random();

        [Fact]
        public void TypeRandomSources()
        {
            int count = 10;
            int length = 1000;
            for (int i = 0; i < count; i++)
            {
                var source = _sourceGenerator.NextSource(s_random.Next(length));
                IncrementalType(source);
            }
        }

        [Fact]
        public void ParseLongSource()
        {
            int length = 100000;
            var source = _sourceGenerator.NextSource(length);
            var source1 = SourceText.From(source);
            var tree1 = IncrementalParse(source1, null, false);
            (var source2, var tree2) = IncrementalParseWithInsertedText((source1, tree1), length, "a", assertEmptyDiagnostics: false);
            (var source3, var tree3) = IncrementalParseWithInsertedText((source2, tree2), length, "b", assertEmptyDiagnostics: false);
            (var source4, var tree4) = IncrementalParseWithInsertedText((source3, tree3), length, "}", assertEmptyDiagnostics: false);
        }


        [Fact]
        public void ParseVeryLongSource()
        {
            int length = 1000000;
            var source = _sourceGenerator.NextSource(length);
            var source1 = SourceText.From(source);
            var tree1 = IncrementalParse(source1, null, false);
            (var source2, var tree2) = IncrementalParseWithInsertedText((source1, tree1), length, "a", assertEmptyDiagnostics: false);
            (var source3, var tree3) = IncrementalParseWithInsertedText((source2, tree2), length, "b", assertEmptyDiagnostics: false);
            (var source4, var tree4) = IncrementalParseWithInsertedText((source3, tree3), length, "}", assertEmptyDiagnostics: false);
        }

        [Fact]
        public void File01()
        {
            string source = @"namespace A { metamodel M; class B { string S; multi_list<object> O; C C; } class C { B B; } association B.C with C.B; }";
            IncrementalType(source);
        }

        [Fact]
        public void File02()
        {
            string source = @"namespace A { metamodel M; class B { string S; multi_list<object> O; C C; } association B.C with C.B; class C { B B; } }";
            IncrementalType(source);
        }

        [Fact]
        public void File03()
        {
            string source = @"namespace A { metamodel M; association B.C with C.B; class B { string S; multi_list<object> O; C C; } class C { B B; } }";
            IncrementalType(source);
        }

        [Fact]
        public void File04()
        {
            var source = @"    [   
     ++
    108107     _118 
     	  		116118	  
     
    *=   /*116111*/ //104103
     ";
            IncrementalType(source);
        }

        [Fact]
        public void File05()
        {
            var source = "wP     &=    byte  \r\n  multi_list  vC set \t   double \tbyte     int\r\n    - \r\n    Uri uN  ) oM\r\n m0\r\n\t//g7\r\n \t  kl    '    \r\n cp\t    /*cT*/    sI\r\n   qi \r\n subsets\t \t\tvl\r\n\r\n  \r\n/*w6*/     null \t   ft\r\n_S\r\n  &\r\n\r\nobject <\r\n \r\n   abstract \r\n+=  | \r\nes   !=\r\n &  \tgz\r\n*=  '\r\n   typedef  \t\t     [ \t  -= @'   set\r\nassociation    \r\n  inherited  \r\n : \t w8          Uri     &   //ki\r\n int        mM  \t  /*qY*/\t    pl     rF ~     ?\t  n3\t  n1\r\n    \t    //wd\r\n  \t |     jr \t\r\nenum\t   --       ri \r\n\r\n||   p4 \r\nhT  \r\n  cV \t bn   ]\t\t   \t  sh //oS\r\n   ++ \r\n extern     &&  \r\n m3\r\n \tqL \t \t  any\t  \t |=    \tfN  ^= \r\n  \r\n v5     \t\r\n  association fu +=\t |     containment   iD\t    \tnone    null  \t \t//bK\r\n <  t9\t   kC      ]P     multi_set\t with\t\r\n \r\n extern      \r\n set\t  \t\r\n true   iC \t s8\tth namespace multi_list  \r\n  _M\r\n \r\n--  jC   f4   class\r\n \r\n{ ta   \t   //rT\r\n \t  kn\t ! \t   ri\t\r\n mk  \r\n true \r\n] bm namespace     \r\nobject \r\n  iD     set\t   cq \t \r\njB    \r\n\tmulti_set     mY    redefines /*dZ*/    Prefix   \t^= s9    \t  is\r\n^Q /  a9 \r\n++  % \r\n\t  \r\nstruct\r\n\r\n derived   \r\n  \r\n]M synthetized  \r\n\r\n \t>     tE   //rB\r\n \r\n\r\nlong\r\n   using _c    //dj\r\n\t //kJ\r\n nk\t&    pb lV   \r\n   \" namespace \treadonly   is  \r\n \r\nlt    ^i    \r\n  <<=\t \t  oP     gn //qM\r\n     as  e_ \tfM [ yn tv with  \r\n  object   bool    null ^=  \t kY\t\t  \r\n\t  /*cW*/      e2 \t ^  \t  tq \r\n\t\t ]W     \t \tox  pm     eN  hI  /*qr*/  \t @'\r\n;  \t abstract \tinherited     t8   -   lazy      }    //th\r\n    Prefix  using\r\n   }   \r\nw5 ny\r\n&  typedef     nL\r\n    \tlL     !=\t\t \r\n  . \t  \r\n   kw\r\n    multi_set  int     /*oJ*/ //^A\r\n \r\n  >=\r\n //\\A\r\n\r\nPrefix   //h_\r\n [A      \r\n   n8\r\n\t\t \tobject    \r\n  \t  hV  qh        .\t  \r\n abstract     sy \r\n lazy     subsets\r\n \t\t\r\nbase ^v   i7 \r\ntypedef   bD  \r\n sC //rX\r\n     kO  <=   \r\n typedef    \t   >  cX  \t  v1\r\n enum     subsets    eY \r\n\t\tca  /*kl*/    void   error    inherited \r\n  union   \r\n[ \t null  abstract\t mL     \"   !=   \t\tmetamodel\t \to7   j5    mt    mS     \r\ncs ^=\t     \t h6  \t \t//el\r\n\r\nextern   x2   ++\t      /      \r\n\t byte\r\n    \t /*dU*/\r\npn \t  g9 \r\n     ;\r\n  \r\n//k6\r\n   \terror \t  //q9\r\n     hd   \r\n^=   true\t    \t abstract\t  Prefix  abstract  \r\n ^X \r\n   \r\n   dM / \r\n\r\n ok bu\r\n   abstract as  //ps\r\n     [ //b3\r\n\r\n \r\nqj \r\n \t abstract \\X     < //[_\r\n       \r\n  qI\r\n       | error\r\nnk   \tdouble  \r\n||  \r\n /*dD*/\t  av     lB\t     namespace \t  //hG\r\n     lu  \r\nxE    multi_set  qm _M pC dT\r\n     \r\nlong\t   \t\r\nbW       \tnamespace\t      *=  \t  d8    ]M\r\n %  \t\ths    iB     od   || /*m2*/    '\r\n with h0\r\n        ni     jp \t extern \t //mc\r\n fj \t&&  oO     &=  \t  ++  \r\n  float    byte    \r\nhT  \t ++     g7   long  pe\t  kp   ++     /*     as\r\n   \r\n /*kl*/ \r\n\t \t>=   //`6\r\n      qj    rM tG uf   <<=  oe   r5\terror   n4\r\n  \t@'      \r\n %=     zf     lB\r\n\r\n \r\n\r\nlV \t  \r\nerror   \r\n   \t ! cQ   \t cm  mB \r\n\t  t3   *= \r\n  redefines\r\n\r\nfloat  eu    \r\n:\t  /*va*/\r\n\r\n ^\r\ntypeof\t  xg  long \t  > \t       any &= \r\n?? qS\t\r\n  \r\n   static \r\nmulti_list \t        hI   false    pt     bool\r\n  \r\nobject  \r\n<=\t\r\n   const \t//qJ\r\n\t^=\r\n  \tusing\t  \t//uU\r\n\t\r\n class\r\n  \t ^\t \t r4      ab\t  vL\r\ndL \r\n  g1   \r\nfloat <= \t\t|    l1\t    l9     -- vh\r\nud\t       >  \r\n\r\n bool    \r\nhE     ||\r\n   symbol\t       aK     hX  \r\n synthetized \r\n gO\t\r\n  @\" \t \r\n/       string  Uri\r\n       qe  \r\n >=     \tkF  !\r\n  \r\n\r\n@\"   \t\t-    \r\n    ru true ik   \r\nfalse   /\r\n   oZ  <<= list   ps\t  n7  |=       \r\n\r\n double      \r\n n2   /*a8*/ \r\n  readonly\t `e  n9    multi_set   bool     bH\t\t  sJ  \t t6 association h4  ^s     -= \t]t |   \t\r\n_b /*iM*/  \t  ut\r\n  -= ++\r\n\r\n  \r\n//qA\r\n    \t\\i  false   q7 \t}   /*ra*/\r\n--\t oz\t  \r\n false %=    \r\nnk  float    const string   \r\n /*_Z*/     |  //tY\r\n\r\n bool\r\n struct   @'   \r\n string     ||    _K\r\n xO \r\nsymbol\r\ncontainment     struct mb\r\n \r\n\t  xg    {\r\n \tlazy   \t    rM void     string\r\n\t &&  \t\r\nsB \t//kI\r\n kB\r\n\r\n  error\r\n   pu  null \t  lazy\t\r\n \t^ d8    \r\ncontainment       cR\t /*p3*/  \t  b_ \t\r\n+  //bo\r\n k7 multi_list    \t   o3  \t  br   &=  \r\n^=  a0   rY   != \t true   )  //jj\r\n\r\n   struct \r\n  iL  ^U\t\t//tE\r\n rg \r\n  \t'  <\t\r\n  \r\n! fX    ^c  derived  \r\n== == \t  \tclass\t\t \t \t\r\n:   long \r\n\t\tany      re\t  Uri `g\t  \r\n//hX\r\n    false \r\n   <<= \r\n  inherited   ]W\tzV bool \t \tua  \r\n  jw \r\n\r\npn *=        &\r\n abstract \t  \r\n) \t     //r6\r\n\t  readonly   dw\t  \t ]G  jd\ttn    //ei\r\n   ll    it //dY\r\n      \r\nfj \t    <= static q4\r\n  bq long     \r\n ) \t \r\n *=\t    ra     yF\r\n long\t  : \t  byte   \t{ \ttypedef \r\n /*f3*/ \r\n \\p       \t. )   > cd   \r\n\tbyte   >=   xc //xw\r\n   synthetized\t  !  \te8 \t union\t to\t\r\n\r\nny\r\n ) /*  \r\n  ig  //tY\r\n oP  subsets\t\r\nusing \r\n  l4\tvg     bK  pM     double \r\nr2\r\n\t vR \r\n   \r\n\tdx \t   \t \r\n//\\D\r\n hd    \r\n xR    cx  abstract    //s3\r\n  rS   /=\r\n  \r\n {  c5    jt ]g \r\n j2\r\n    \r\n  bool bK   `m   \r\n float \t&& \r\n{ synthetized  \tint \r\n hp  \r\n ]B \r\n \t   Prefix\t- \r\n multi_set   @\" +   k1\r\n    ' \r\n /*]P*/  base \t  false     gp \r\n\ted  //h8\r\n    ]\r\n\t\r\n   ^R  '\r\n  readonly  \\z      \r\nbase wY    ||";
            IncrementalType(source);
        }
    }
}
