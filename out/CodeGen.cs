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

		public void addQuestion(string question) {
			addPrint(question);
		}

		public void input() {
			addCode("set /a last_answer=\n");
		}

		public void addCheckAnswer(string correctAnswer) {
			addCode("if %last_answer% == " + correctAnswer + " (set /a score+=1)\n");
		}

		public void addFinalScore() {
			addPrint("Your score is %score% out of %max_score%");
		}

		public void writeCode(string filename) {
			File.WriteAllText(filename, code);
		}
	} // end CodeGenerator
} // end namespace