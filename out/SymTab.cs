using System;
using System.Collections.Generic; 

namespace Cuestionario {
	public class SymbolTable {
		public Dictionary<string, int> variables = new Dictionary<string, int>();
		
		Parser parser;
		
		public SymbolTable(Parser parser) {
			this.parser = parser;
			this.variables["score"] = 1; // int
		}

		public void setVariable(string name, int type) {
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