using System;
using System.Collections.Generic; 

namespace Cuestionario {
	public class SymbolTable {
		public Dictionary<string, int> variables = new Dictionary<string, int>();
		
		Parser parser;
		
		public SymbolTable(Parser parser) {
			this.parser = parser;
			this.variables["score"] = 1; // int
			this.variables["last_answer"] = 1; // int
		}

		public void setVariable(string name, int type) {
			if(name == "score" || name == "last_answer") {
				parser.SemErr(name + " is a reserved variable");
				return;
			}
			variables[name] = type;
		}

		public int getType(string name) {
			if (variables.ContainsKey(name)) {
				return variables[name];
			}
			
			parser.SemErr(name + " is undeclared");
		
			return 0; // undefined type
		}

	} // end SymbolTable
} // end namespace