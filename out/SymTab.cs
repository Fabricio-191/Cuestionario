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

		// search the name in all open scopes and return its object node
		public int getType(string name) {
			if (variables.ContainsKey(name)) {
				return variables[name];
			}
			
			parser.SemErr(name + " is undeclared");
		
			return 0;
		}

	} // end SymbolTable
} // end namespace