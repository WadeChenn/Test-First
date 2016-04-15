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
            StringReader input_1 = new StringReader("haha");
            StringReader input_2 = new StringReader("haha");
            StringWriter output = new StringWriter();
            Program.NewMethod(input_1, input_2, output);
            Assert.That( output.ToString(),Is.EqualTo("haha"));
        }

    }
}
