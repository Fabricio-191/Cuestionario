using System;
using System.IO;

// generating .bat file

namespace Cuestionario {
	public class CodeGenerator {
		private string code = "$score=0\n\n";

		private int max_score = 0;

		private string expr = "";

		public void addToExpr(string s){
			expr += s;
		}

		public void addVariableReference(string variable) {
			addToExpr("$" + variable);
		}

		public string getExpr(){
			string expr1 = expr;
			expr = "";
			return expr1;
		}

		public void addCode(string code) {
			// Console.WriteLine(code);
			this.code += code;
		}

		public void addIf(string condition) {
			addCode("if (" + condition + ")");
		}

		public void addPrint(string message) {
			addCode("Write-Host \"" + message + "\"\n");
		}

		public void addOption(string option) {
			addPrint("* " + option);
		}

		public void addFinalScore() {
			addPrint("Your score is $score out of " + max_score);
		}

		public void addAnswerCheck(string correctAnswer, int value, bool includes) {
			addCode("\n$last_answer = Read-Host \"Respuesta\"\n");
			if(correctAnswer == ""){
				// no correct answer
				addCode("\n\n\n");
				return;
			};

			if(includes){
				addCode("if ($last_answer.ToLower() -like \"*" + correctAnswer.ToLower() + "*\")");
			}else{
				addCode("if ($last_answer.ToLower() -eq \"" + correctAnswer.ToLower() + "\")");
			}
			addCode("{ $score += " + value + " }\n\n\n\n");
			max_score += value;
		}

		public void writeCode(string filename) {
			File.WriteAllText(filename, code);
		}
	}
}

