using System;
using System.IO;
using System.Collections.Generic; 

// generating .bat file

namespace Cuestionario {
	public class CodeGenerator {
		private string code = @"function Show-Menu {
    param (
		[string]$Question,
        [string[]]$Options
    )

    $selectedIndex = 0
    $key = $null

    while ($true) {
        # Limpiar pantalla
		Clear-Host
		Write-Host $Question -ForegroundColor Cyan

        # Mostrar opciones
        for ($i = 0; $i -lt $Options.Count; $i++) {
            if ($i -eq $selectedIndex) {
                Write-Host ""-> $($Options[$i])"" -ForegroundColor Yellow
            } else {
                Write-Host ""   $($Options[$i])"" -ForegroundColor White
            }
        }

        # Capturar tecla presionada
        $key = $Host.UI.RawUI.ReadKey(""NoEcho,IncludeKeyDown"").VirtualKeyCode

        # Navegación con flechas
        switch ($key) {
            38 { # Flecha hacia arriba
                if ($selectedIndex -gt 0) { $selectedIndex-- }
            }
            40 { # Flecha hacia abajo
                if ($selectedIndex -lt ($Options.Count - 1)) { $selectedIndex++ }
            }
            13 { # Enter
                return $Options[$selectedIndex]
            }
        }
    }
}

$score=0

";

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

		public void addOptions(string question, List<string> options) {
		}

		public void addFinalScore() {
			addPrint("Your score is $score out of " + max_score);
		}

		private void checkIntegerInput(){
			addCode("if ($last_answer -notmatch \"^\\d+$\"){\n");
			addCode("  Throw \"Invalid input. Please enter a number\"\n");
			addCode("}\n\n");
		}

		public void addQuestion(string question, string correctAnswer, int value, bool includes, string name, Parser.Type inputType, string[] options) {
			if(options == null){
				addPrint(question);
				addCode("\n$last_answer = Read-Host \"Respuesta\"\n");
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
		}

		public void writeCode(string filename) {
			File.WriteAllText(filename, code);
		}
	}
}

