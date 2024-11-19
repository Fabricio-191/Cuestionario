using System;
using System.IO;
using System.Collections.Generic; 

// generating .bat file

namespace Cuestionario {
	public class CodeGenerator {
		private string code = "$score=0\n\n";

		private int max_score = 0;
		private string separator = "* ";

		public void setSeparator(string separator) {
			this.separator = separator;
		}

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

		public void addPrint(string message, string color) {
			addCode("Write-Host \"" + message + "\" -ForegroundColor " + color + " \n");
		}

		public void addOption(string option) {
			addPrint(separator + option);
		}

		// -ForegroundColor Green

		public void addFinalScore() {
			addPrint("Your score is $score out of " + max_score);
		}

		private void checkIntegerInput(){
			addCode("if ($last_answer -notmatch \"^\\d+$\"){\n");
			addCode("  Throw \"Invalid input. Please enter a number\"\n");
			addCode("}\n\n");
		}

		public void addQuestion(string correctAnswer, int value, bool includes, string name, Parser.Type inputType) {
			// gen.addQuestion(question, correct, value, includes);
			addCode("\n$last_answer = Read-Host \"\nRespuesta\"\n");
			if(inputType == Parser.Type.integer){
				checkIntegerInput();
			}

			if(name != null){
				addCode("$" + name + " = $last_answer\n");
			}

			if(correctAnswer == null){
				// no correct answer
				addCode("\n\n\n");
				return;
			};

			if(includes){
				addCode("if ($last_answer.ToLower() -like \"*" + correctAnswer + "*\")");
			}else{
				addCode("if ($last_answer.ToLower() -eq \"" + correctAnswer + "\")");
			}
			addCode("{ $score += " + value + " }\n\n\n\n");
			max_score += value;

			addPrint("\n\n");
		}

		public void writeCode(string filename) {
			File.WriteAllText(filename, code);
		}
	}
}

