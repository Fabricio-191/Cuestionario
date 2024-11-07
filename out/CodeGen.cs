using System;
using System.IO;

// generating .bat file

namespace Cuestionario {
	public class CodeGenerator {
		private string code = "set /a score=0\n\n";

		private int max_score = 0;

		public void addCode(string code) {
			// Console.WriteLine(code);
			this.code += code;
		}

		public void addPrint(string message) {
			addCode("echo " + message + "\n");
		}

		public void addAnswerCheck(string correctAnswer, int value, bool includes) {
			addCode("set /p last_answer=\"Respuesta: \"\n\n");
			if(correctAnswer == "") return;

			if(includes){
				addCode("if not x%last_answer:" + correctAnswer.ToLower() + "=% == x%last_answer%");
			}else{
				addCode("if \"%last_answer%\" == " + correctAnswer.ToLower());
			}
			addCode(" (\n\tset /a score+=" + value + "\n)\n");
			max_score += value;
		}

		public void addFinalScore() {
			addPrint("Your score is %score% out of " + max_score);
		}

		public void writeCode(string filename) {
			File.WriteAllText(filename, code);
		}
	} // end CodeGenerator
} // end namespace