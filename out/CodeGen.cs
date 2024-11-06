using System;
using System.IO;

// generating .bat file

namespace Cuestionario {
	public class CodeGenerator {
		private string code;
		
		public void addCode(string code) {
			Console.WriteLine(code);

			this.code += code;
		}

		public void addPrint(string message) {
			addCode("echo " + message + "\n");
		}

		public void writeCode(string filename) {
			File.WriteAllText(filename, code);
		}
	} // end CodeGenerator
} // end namespace