using System;
using System.IO;

// generating .bat file

namespace Cuestionario {
	public class CodeGenerator {
		private string code = "set /a score=0\nset /a last_answer=0\n";
		
		public void addCode(string code) {
			Console.WriteLine(code);
			this.code += code;
		}

		public void addPrint(string message) {
			addCode("echo " + message + "\n");
		}

		public void addQuestion(string question, string correctAnswer, int value) {
			addPrint(question);
			addCode("set /p last_answer=\"Respuesta: \"\n");
			addCode("if %last_answer% == " + correctAnswer + " (\n\tset /a score+=" + value + "\n)\n");
		}

		public void addFinalScore() {
			addPrint("Your score is %score% out of %max_score%");
		}

		public void writeCode(string filename) {
			File.WriteAllText(filename, code);
		}
	} // end CodeGenerator
} // end namespace