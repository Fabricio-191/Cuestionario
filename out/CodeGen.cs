using System;
using System.IO;

// generating .bat file

namespace Cuestionario {
	public class CodeGenerator {
		private string code = "$score=0\n\n";

		private int max_score = 0;

		private void addCode(string code) {
			// Console.WriteLine(code);
			this.code += code;
		}

		public void addPrint(string message) {
			addCode("Write-Host " + message + "\n");
		}

		public void addFinalScore() {
			addPrint("Your score is $score out of " + max_score);
		}

		public void addAnswerCheck(string correctAnswer, int value, bool includes) {
			addCode("$last_answer = Read-Host \"Respuesta\"\n\n");
			if(correctAnswer == "") return; // no correct answer

			if(includes){
				addCode("if ($last_answer.ToLower() -like " + correctAnswer.ToLower() + ")");
			}else{
				addCode("if ($last_answer.ToLower() -eq " + correctAnswer.ToLower() + ")");
			}
			addCode("{ $score += " + value + " }\n\n");
			max_score += value;
		}

		public void writeCode(string filename) {
			File.WriteAllText(filename, code);
		}
	}
}

