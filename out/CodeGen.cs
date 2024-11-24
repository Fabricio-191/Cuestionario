using System;
using System.IO;
using System.Collections.Generic; 

// generating .bat file

namespace Cuestionario {
	public class CodeGenerator {
		private string separator = "* ";
		private string questionColor = "Cyan";
		private string optionsColor = "White";
		private string selectedOptionColor = "Yellow";
		
		private string code = "";
		private int max_score = 0;

		public void setSeparator(string separator) {
			this.separator = separator;
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

		public void addFinalScore() {
			addPrint("Your score is $score out of " + max_score, "Magenta");
		}

		private Dictionary<Parser.Type, string> inputsTypesMap = new Dictionary<Parser.Type, string> {
			{Parser.Type.NUMBER, "int"},
			{Parser.Type.STRING, "string"},
		};

		public void addQuestion(
			string question, string correctAnswer, int value, bool includes,
			string name, Parser.Type inputType, string[] options
		) {
			if(options == null){
				addPrint(question, questionColor);
				addCode("\n$last_answer = [" + inputsTypesMap[inputType] + "] (Read-Host \"Respuesta\")\n");
			}else{
				string optionsStr = "";

				for(int i = 0; i < options.Length; i++){
					optionsStr += "\"" + options[i] + "\"";
					if(i < options.Length - 1){
						optionsStr += ", ";
					}
				}

				addCode("$last_answer = Show-Menu \"" + question + "\" @(" + optionsStr + ")\n");
			}

			if(name != null){
				addCode("$" + name + " = $last_answer\n");
			}
			addPrint("\n\n");

			if(correctAnswer == null){
				// no correct answer
				addCode("\n\n\n");
				return;
			};

			if(inputType == Parser.Type.STRING){
				if(includes){
					addCode("if ($last_answer.ToLower() -like \"*" + correctAnswer + "*\")");
				}else{
					addCode("if ($last_answer.ToLower() -eq \"" + correctAnswer + "\")");
				}
			}else{
				addCode("if ($last_answer -eq " + correctAnswer + ")");
			}

			addCode("{ $score += " + value + " }\n\n\n\n");
			max_score += value;
		}

		public void writeCode(string filename) {
			string baseCode = @"
";



			File.WriteAllText(filename, baseCode + code);
		}
	}
}

