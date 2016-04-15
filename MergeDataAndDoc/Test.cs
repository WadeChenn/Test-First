using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeDataAndDoc
{
    [TestFixture]
    class Test
    {
        [Test]
        public void T1()
        {
            StringReader input_1 = new StringReader("中文姓名身份證字號年數\nTomc12342342年");
            StringReader input_2 = new StringReader("${中文姓名}先生(身份證字號${身份證字號})為本校專任教師，聘期${年數}");
            StringWriter output = new StringWriter();
            Program.NewMethod(input_1, input_2, output);
            Assert.That( output.ToString(),Is.EqualTo("Tomc先生(身份證字號)4324321為本校專任教師，聘期2年\r\n"));
        }
        [Test]
        public void T2()
        {
            StringReader input_1 = new StringReader("中文姓名身份證字號年數\nEvice45679871年");
            StringReader input_2 = new StringReader("${中文姓名}先生(身份證字號${身份證字號})為本校專任教師，聘期${年數}");
            StringWriter output = new StringWriter();
            Program.NewMethod(input_1, input_2, output);
            Assert.That(output.ToString(), Is.EqualTo("Evice先生(身份證字號)7897654為本校專任教師，聘期1年\r\n"));
        }

    }
}
